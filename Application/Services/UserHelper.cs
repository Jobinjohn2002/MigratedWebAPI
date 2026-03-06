using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class UserHelper
    {
        /// <summary>
        /// GetDeliveryPointAccess operation
        /// </summary>
        public static UserDeliveryPointDataContract GetDeliveryPointAccess(BaseRequestDataContract baseRequest)
        {
            var udpDataContract = new UserDeliveryPointDataContract
            {
                UserId = baseRequest.UserId,
                Customers = new List<CustomerDataContract>()
            };

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var userRepository = UserRepository.New(workUnit);
                var user = userRepository.Get(baseRequest.UserId);

                if (user != null)
                {
                    var userDeliveryPointRepo =
                        UserDeliveryPointRepository.New(workUnit);
                    var deliveryPointRepo =
                        DeliveryPointRepository.New(workUnit);

                    var deliveryPoints = userDeliveryPointRepo.ReadDeliveryPointsByUserId(user.UserId);

                    foreach (var dp in deliveryPoints)
                    {
                        var customer = deliveryPointRepo.GetCustomerByDeliveryPoint(dp.DeliveryPointId, true);

                        var deliveryPoint = deliveryPointRepo.Get(dp.DeliveryPointId);

                        if (customer == null || deliveryPoint == null)
                        {
                            continue;
                        }

                        if (udpDataContract.Customers.All(cust => cust.DefinitionId != customer.CustomerDefinitionId))
                        {
                            var tmpForceOrderToMatchDPSetting = CustomerSettings.GetEvaluatedForceOrderToMatchTurnaroundDeliveryPoint(customer.CustomerDefinitionId, customer.FacilityId, customer.Facility.Owner.TenancyId, workUnit);
                            udpDataContract.Customers.Add(new CustomerDataContract
                            {
                                DefinitionId = customer.CustomerDefinitionId,
                                Id = customer.CustomerId,
                                Name = customer.Text,
                                StatusId = customer.CustomerStatusId,
                                Status = customer.CustomerStatus.Text,
                                DeliveryPoints = new List<DeliveryPointDataContract>(),
                                DateTimeFormats = new DateTimeFormatDataContract(),
                                FacilityId = customer.FacilityId,
                                ForceOrderToMatchDPsetting = tmpForceOrderToMatchDPSetting,
                                IsHeader = false
                            });
                        }

                        udpDataContract.Customers.FirstOrDefault(
                            cust => cust.DefinitionId == deliveryPoint.CustomerDefinitionId)?
                            .DeliveryPoints.Add(new DeliveryPointDataContract
                            {
                                Id = deliveryPoint.DeliveryPointId,
                                Name = deliveryPoint.Text,
                                IsStockLocation = deliveryPoint.StockLocation,
                                CustomerDefinitionId = deliveryPoint.CustomerDefinitionId,
                                CustomerName =
                                    udpDataContract.Customers.FirstOrDefault(
                                        cust => cust.DefinitionId == deliveryPoint.CustomerDefinitionId)?.Name,
                                IsSelected = false
                            });

                    }
                }
                else
                {
                    udpDataContract.ErrorCode = (int)ErrorCodes.InvalidUser;
                }
            }

            return udpDataContract;
        }

        /// <summary>
        /// HasAnyPermission operation
        /// </summary>
        public static bool HasAnyPermission(int userId, PermissionIdentifier[] permissions)
        {
            {
                var userRepository = UserRepository.New(workUnit);
                var userRoles = userRepository.ReadPermissionsByUserId(userId);

                foreach (var permission in permissions)
                {
                    if (userRoles.Any(p => p.PermissionId == (int)permission))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}