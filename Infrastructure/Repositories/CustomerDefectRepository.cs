using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// CustomerDefectRepository
    /// </summary>
    /// <remarks></remarks>
    public partial class CustomerDefectRepository
    {
        /// <summary>
        /// Gets the specified customer defect id.
        /// </summary>
        /// <param name="customerDefectId">The customer defect id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public CustomerDefect Get(int customerDefectId)
        {
            return Repository.Find(customerDefect => customerDefect.CustomerDefectId == customerDefectId).FirstOrDefault();
        }

        /// <summary>
        /// Reads the customer defects detail by external id.
        /// </summary>
        /// <summary>
        /// GetAllByExternalId operation
        /// </summary>
        public IQueryable<CustomerDefect> GetAllByExternalId(string externalId, int deliveryPointId)
        {
            return Repository.Find(customerDefect => customerDefect.ExternalId == externalId && customerDefect.Turnaround.DeliveryPointId == deliveryPointId);
        }

        /// <summary>
        /// Reads the customer defects detail by external id.
        /// </summary>
        /// <param name="customerDefectId"></param>        
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetCustomerDefectByExternalId operation
        /// </summary>
        public CustomerDefect GetCustomerDefectByExternalId(int customerDefectId)
        {
            var customerDefect = Repository.Find(i => i.CustomerDefectId == customerDefectId).FirstOrDefault();

            var latestRevisionDefect = Repository.Find(c => c.ExternalId == customerDefect.ExternalId && c.TurnaroundId == customerDefect.TurnaroundId).OrderByDescending(i => i.Created).FirstOrDefault();
            latestRevisionDefect.Created = Repository.Find(c => c.ExternalId == customerDefect.ExternalId && c.TurnaroundId == customerDefect.TurnaroundId).OrderBy(o => o.Created).FirstOrDefault().Created;

            return latestRevisionDefect;
        }

        /// <summary>
        /// Reads the customer defects by user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadCustomerDefectsByUser operation
        /// </summary>
        public IQueryable<CustomerDefect> ReadCustomerDefectsByUser(int userId)
        {
            var udpRepository = UserDeliveryPointRepository.New(Repository.UnitOfWork);
            return udpRepository.Repository.Find(udp => udp.UserId == userId).Select(udp => udp.DeliveryPoint).Where(
                   dp => dp.Archived == null).SelectMany(dp => dp.Turnaround).SelectMany(t => t.CustomerDefect).GroupBy(cd => cd.TurnaroundId).Select(
                   g => g.OrderByDescending(f => f.Created).FirstOrDefault())
                   .Where(cd => (cd.CustomerDefectStatusId == (byte)CustomerDefectStatusIdentifier.CustomerDefectRaised || cd.CustomerDefectStatusId == (byte)CustomerDefectStatusIdentifier.CustomerResponseRequested));
        }

        /// <summary>
        /// Reads the defects by definition.
        /// </summary>
        /// <param name="definitionId">The definition id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadCustomerDefectsByDefinition operation
        /// </summary>
        public IQueryable<CustomerDefect> ReadCustomerDefectsByDefinition(int definitionId)
        {
            var latestList =
                Repository.Find(i => i.Turnaround.ContainerMaster.ContainerMasterDefinitionId == definitionId)
                    .GroupBy(i => i.ExternalId)
                    .SelectMany(c => c.OrderByDescending(r => r.Created).Take(1));

            var earliestList =
                Repository.Find(i => i.Turnaround.ContainerMaster.ContainerMasterDefinitionId == definitionId)
                    .GroupBy(i => i.ExternalId)
                    .SelectMany(c => c.OrderBy(r => r.Created).Take(1));

            var results = from latest in latestList
                          join earliest in earliestList on latest.ExternalId equals earliest.ExternalId
                          select new
                          {
                              latest.CustomerDefectId,
                              latest.CreatedUserId,
                              latest.TurnaroundId,
                              latest.ExternalId,
                              earliest.Created,
                              latest.LegacyFacilityOrigin,
                              latest.LegacyImported,
                              latest.CustomerDefectStatus,
                              latest.CustomerDefectStatusId,
                              latest.DetailsInformation,
                              latest.EmailCustomer,
                              latest.Facility,
                              latest.FacilityId,
                              latest.InternalDetailsInformation,
                              latest.MissingInformation,
                              latest.RespondedDirectly,
                              latest.ResponseInformation,
                              latest.Turnaround,
                              latest.User,
                              latest.CustomerDefectReasons
                          };

            var resultsList = results.ToList().Select(def => new CustomerDefect
            {
                CustomerDefectId = def.CustomerDefectId,
                CreatedUserId = def.CreatedUserId,
                TurnaroundId = def.TurnaroundId,
                ExternalId = def.ExternalId,
                Created = def.Created,
                LegacyFacilityOrigin = def.LegacyFacilityOrigin,
                LegacyImported = def.LegacyImported,
                CustomerDefectStatus = def.CustomerDefectStatus,
                CustomerDefectStatusId = def.CustomerDefectStatusId,
                DetailsInformation = def.DetailsInformation,
                EmailCustomer = def.EmailCustomer,
                Facility = def.Facility,
                FacilityId = def.FacilityId,
                InternalDetailsInformation = def.InternalDetailsInformation,
                MissingInformation = def.MissingInformation,
                RespondedDirectly = def.RespondedDirectly,
                ResponseInformation = def.ResponseInformation,
                Turnaround = def.Turnaround,
                User = def.User
            }).ToList();

            foreach (var i in resultsList)
            {
                i.EntityKeyValue = i.CustomerDefectId.ToString();
                var reasons = latestList.First(l => l.CustomerDefectId == i.CustomerDefectId).CustomerDefectReasons;
                foreach(var reason in reasons)
                {
                    i.CustomerDefectReasons.Add(reason);
                }
            }

            return resultsList.AsQueryable();
        }

        /// <summary>
        /// Reads the customer defects by customer by date.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadCustomerDefectsByCustomerByDate operation
        /// </summary>
        public IQueryable<CustomerDefect> ReadCustomerDefectsByCustomerByDate(int customerId, DateTime startDate, DateTime endDate)
        {
            var incrementedEndDate = endDate.AddDays(1);
            return Repository.Find(cd => cd.Created >= startDate && cd.Created <= incrementedEndDate &&
                                         (cd.CustomerDefectStatusId != (int)CustomerDefectStatusIdentifier.Closed ||
                                          cd.CustomerDefectStatusId != (int)CustomerDefectStatusIdentifier.Void));
        }

        /// <summary>
        /// Reads the customer defects by turnaround uid.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadCustomerDefectsByTurnaroundId operation
        /// </summary>
        public IQueryable<CustomerDefect> ReadCustomerDefectsByTurnaroundId(int turnaroundId)
        {
            var customerDefects = Repository.Find(cd => cd.TurnaroundId == turnaroundId).GroupBy(i => i.ExternalId).SelectMany(c => c.OrderByDescending(r => r.Created).Take(1));

            foreach (var customerDefect in customerDefects)
            {
                customerDefect.Created = Repository.Find(a => a.ExternalId == customerDefect.ExternalId).OrderBy(b => b.Created).First().Created;
            }

            return customerDefects;
        }

        /// <summary>
        /// Reads the customer defects by turnaround uid.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadOpenCustomerDefectsWithAutomaticQuarantineByTurnaroundId operation
        /// </summary>
        public IQueryable<CustomerDefect> ReadOpenCustomerDefectsWithAutomaticQuarantineByTurnaroundId(int turnaroundId)
        {
            var readOnlyCustomerDefects = Repository.Find(cd => cd.TurnaroundId == turnaroundId).GroupBy(i => i.ExternalId).SelectMany(c => c.OrderByDescending(r => r.Created).Take(1));
            return readOnlyCustomerDefects.Where(cd => cd.QuarantineAfterWash
                                      && cd.CustomerDefectStatusId != (int)CustomerDefectStatusIdentifier.Closed
                                      && cd.CustomerDefectStatusId != (int)CustomerDefectStatusIdentifier.Void);
        }

        /// <summary>
        /// Reads the customer defects reasons by customer defect id.
        /// </summary>
        /// <param name="customerDefectId">The customer defect id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadCustomerDefectsReasonsByCustomerDefectId operation
        /// </summary>
        public IQueryable<ICustomerDefectReason> ReadCustomerDefectsReasonsByCustomerDefectId(int customerDefectId)
        {
            return Repository.Find(cd => cd.CustomerDefectId == customerDefectId).SelectMany(cdr => cdr.CustomerDefectReasons);
        }

    /// <summary>
    /// Searches the customer defects.
    /// </summary>
    /// <param name="searchText">The search text.</param>
    /// <param name="start">The start.</param>
    /// <param name="end">The end.</param>
    /// <param name="status">The status.</param>
    /// <param name="reason">The reason.</param>
    /// <param name="userId">The user uid.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <summary>
    /// SearchCustomerDefects operation
    /// </summary>
    public IQueryable<CustomerDefect> SearchCustomerDefects(string searchText, DateTime? start, DateTime? end,
                                                                int? status, int? reason, int userId)
        {
            var userDeliveryPointRespository = UserDeliveryPointRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork()).Repository;

            var list =
                userDeliveryPointRespository.Find(udp => udp.UserId == userId).Select(udp => udp.DeliveryPoint).Where(
                    dp => dp.Archived == null).SelectMany(dp => dp.Turnaround).SelectMany(t => t.CustomerDefect);

            if (!string.IsNullOrEmpty(searchText))
            {
                list.Where(
                        cd =>
                            (cd.User.UserName == searchText) || (cd.ExternalId == searchText) ||
                            (cd.ExternalId == searchText) || (cd.Turnaround.ExternalId.ToString() == searchText) ||
                            (cd.Turnaround.LegacyId.ToString() == searchText));
            }

            if (start != null)
            {
                list.Where(cd => cd.Created >= start);
            }

            if (end != null)
            {
                list.Where(cd => cd.Created <= end);
            }

            if (status != null)
            {
                list.Where(cd => cd.CustomerDefectStatusId == status);
            }

            if (reason != null)
            {
                list = list.Where(cd => cd.CustomerDefectReasons.All(cdr => cdr.CustomerDefectReasonId == reason));
            }

            return list;
        }

        /// <summary>
        /// Reads the customer defects detail by turnaround uid.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadCustomerDefectsDetailByTurnaroundId operation
        /// </summary>
        public IQueryable<ICustomerDefectDetail> ReadCustomerDefectsDetailByTurnaroundId(int turnaroundId)
        {
            return
                Repository.Find(cd => cd.TurnaroundId == turnaroundId).Select(i => new CustomerDefectDetailData
                                                                                       {
                                                                                           CreatedBy = i.CreatedUserId,
                                                                                           CreatedDate = i.Created,
                                                                                           CreatedUser = i.User.UserName,
                                                                                           CustomerDefectId = i.CustomerDefectId,
                                                                                           DetailsInformation = i.DetailsInformation,
                                                                                           InternalDetailsInformation = i.InternalDetailsInformation,
                                                                                           MissingInformation =i.MissingInformation,
                                                                                           ResponseInformation = i.ResponseInformation,
                                                                                           StatusId = i.CustomerDefectStatusId,
                                                                                           StatusName = i.CustomerDefectStatus.Text,
                                                                                           TurnaroundId = i.TurnaroundId
                                                                                       });
        }

        /// <summary>
        /// Reads the customer defects by turnaround uid.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadAllCustomerDefectByFacility operation
        /// </summary>
        public IQueryable<ICustomerDefect> ReadAllCustomerDefectByFacility(short facilityId)
        {
            return Repository.Find(cd => cd.Turnaround.FacilityId == facilityId);
        }

        /// <summary>
        /// ReadCustomerDefectsByInstance operation
        /// </summary>
        public IQueryable<ICustomerDefect> ReadCustomerDefectsByInstance(int instanceId)
        {
            return Repository.Find(cd => cd.Turnaround.ContainerInstanceId == instanceId).GroupBy(i => i.ExternalId).SelectMany(c => c.OrderByDescending(r => r.Created).Take(1));
        }
    }
}