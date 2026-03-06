using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class FacilityRepository
    {
        /// <summary>
        /// To retrieve the facility information
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>Facility Information</returns>
        /// <summary>
        /// Get operation
        /// </summary>
        public Facility Get(short facilityId)
        {
            return Repository.Find(f => f.FacilityId == facilityId).FirstOrDefault();
        }

        /// <summary>
        /// To retrieve queryable collection of facilities based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
	    /// <summary>
	    /// Find operation
	    /// </summary>
	    public IQueryable<Facility> Find(Expression<Func<Facility, bool>> predicate)
        {
            return Repository.Find(predicate);
        }

        /// <summary>
        /// To retrieve queryable collection of customers
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>Queryable collection of customers</returns>
        /// <summary>
        /// GetCustomersByFacility operation
        /// </summary>
        public IQueryable<Customer> GetCustomersByFacility(short facilityId)
        {
            return Repository.Find(f => f.FacilityId == facilityId).SelectMany(f => f.Customers).Where(c => c.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Active);
        }

        /// <summary>
        /// To retrieve queryable collection of customers
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <param name="searchTerm">Search criteria</param>
        /// <returns>Queryable collection of customers</returns>
        /// <summary>
        /// GetCustomersByFacility operation
        /// </summary>
        public IQueryable<Customer> GetCustomersByFacility(short facilityId, string searchTerm)
        {
            return Repository.Find(f => f.FacilityId == facilityId).SelectMany(f => f.Customers).Where(c => c.Text.Contains(searchTerm)).Where(c => c.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Active);
        }

        /// <summary>
        /// To retrieve queryable collection of customer with name who has delivery points
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>Queryable collection of customer with name</returns>
        /// <summary>
        /// GetCustomersWithDeliveryPointsByFacility operation
        /// </summary>
        public IList<CustomerWithName> GetCustomersWithDeliveryPointsByFacility(short facilityId)
        {
            var context = (OperativeModelContainer)Repository.UnitOfWork.Context;

            if (facilityId > 0)
            {

                var query = context.
                    Customer.
                    Where(i =>
                        i.FacilityId == facilityId &&
                        (
                            i.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Active ||
                            i.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Stop
                        ) && i.CustomerDefinition.DeliveryPoint.Any(k => k.ArchivedUserId == null)).
                    GroupBy(i => i.CustomerDefinitionId).
                    Select(i => i.OrderByDescending(c => c.Revision).FirstOrDefault()).
                    Select(i => new
                    {
                        Customer = i,
                        CustomerGroup = i.CustomerGroup,
                    });

                var customers = query.
                    ToList().
                    Select(i => new CustomerWithName()
                    {
                        Customer = i.Customer,
                        Name = i.Customer.Text,
                        GroupName = (i.CustomerGroup == null ? null : i.CustomerGroup.Text),
                    });

                return customers.OrderBy(c => c.Name).ToList();
            }
            else
            {
                var query = Repository.
                    All().
                    SelectMany(f => f.Customers).
                    Where(c => c.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Active).
                    Select(cust => new CustomerWithName()
                    {
                        Customer = cust,
                        Name = cust.Text,
                        GroupName = cust.CustomerGroup.Text
                    }).
                    Distinct();

                return query.OrderBy(c => c.Name).ToList();
            }
        }

        /// <summary>
        /// To retrieve queryable collection of customer with name
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>Queryable collection of customer with name</returns>
        /// <summary>
        /// GetCustomersNamedByFacility operation
        /// </summary>
        public IList<CustomerWithName> GetCustomersNamedByFacility(short facilityId)
        {
            var context = (OperativeModelContainer)Repository.UnitOfWork.Context;

            if (facilityId > 0)
            {
                var query = context.
                    Customer.
                    Where(i =>
                        i.FacilityId == facilityId &&
                        (
                            i.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Active ||
                            i.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Stop
                        )).
                    GroupBy(i => i.CustomerDefinitionId).
                    Select(i => i.OrderByDescending(c => c.Revision).FirstOrDefault()).
                    Select(i => new
                    {
                        Customer = i,
                        CustomerGroup = i.CustomerGroup,
                    });

                var customers = query.
                    ToList().
                    Select(i => new CustomerWithName()
                    {
                        Customer = i.Customer,
                        Name = i.Customer.Text,
                        GroupName = (i.CustomerGroup == null ? null : i.CustomerGroup.Text),
                    });

                return customers.ToList();
            }
            else
            {
                var query = Repository.
                    All().
                    SelectMany(f => f.Customers).
                    Where(c => c.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Active).
                    Select(cust => new CustomerWithName()
                    {
                        Customer = cust,
                        Name = cust.Text,
                        GroupName = cust.CustomerGroup.Text
                    }).
                    Distinct();

                return query.ToList();
            }
        }

        /// <summary>
        /// To retrieve queryable collection of delivery points by facility
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>Queryable collection of delivery points</returns>
        /// <summary>
        /// GetDeliveryPointsByFacility operation
        /// </summary>
        public IQueryable<DeliveryPoint> GetDeliveryPointsByFacility(short facilityId)
        {
            return Repository.Find(f => f.FacilityId == facilityId && f.Archived == null).SelectMany(f => f.Customers).Select(sc => sc.CustomerDefinition).SelectMany(cd => cd.DeliveryPoint).Where(dp => dp.Archived == null);
        }

        /// <summary>
        /// To retrieve queryable collection of stations by facility
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>Queryable collection of stations</returns>
        /// <summary>
        /// GetStationsByFacility operation
        /// </summary>
        public IQueryable<Station> GetStationsByFacility(short facilityId)
        {
            return Repository.Find(f => f.FacilityId == facilityId).SelectMany(f => f.Stations).Where(s => s.Archived == null);
        }

        /// <summary>
        /// To retrieve queryable collection of facilities
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>Queryable collection of facilities</returns>
        /// <summary>
        /// ReadAssociatedFacilitiesByFacility operation
        /// </summary>
        public IQueryable<Facility> ReadAssociatedFacilitiesByFacility(short facilityId)
        {
            return
                Repository.Find(f => f.FacilityId == facilityId).SelectMany(f => f.AssociatedFacilitiesChilds).Where(
                    f => f.Archived == null);
        }

        /// <summary>
        /// To retrieve queryable collection of user by facilities
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>Queryable collection of user by facilities</returns>
        /// <summary>
        /// ReadFacilityContracts operation
        /// </summary>
        public IQueryable<User> ReadFacilityContracts(short facilityId)
        {
            return
                Repository.Find(f => f.FacilityId == facilityId).SelectMany(f => f.Contactors).Where(
                    c => c.Archived == null);
        }

        /// <summary>
        /// To retrieve queryable collection of station types by facility
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>Queryable collection of station types by facility</returns>
        /// <summary>
        /// ReadStationTypesByFacility operation
        /// </summary>
        public IQueryable<StationType> ReadStationTypesByFacility(short facilityId)
        {
            return
                Repository.Find(f => f.FacilityId == facilityId).SelectMany(f => f.StationTypes);
        }

        /// <summary>
        /// To retrieve queryable collection of archived delivery points by facility
        /// </summary>
        /// <param name="facilityId">
        ///     Facility Id
        ///     Facility Id
        /// </param>
        /// <returns>Queryable collection of archived delivery points</returns>
        /// <summary>
        /// ReadArchivedDeliveryPointsByFacility operation
        /// </summary>
        public IQueryable<IFacilityArchived> ReadArchivedDeliveryPointsByFacility(short facilityId)
        {
            return
                Repository.Find(f => f.FacilityId == facilityId).SelectMany(f => f.Customers).Select(c => c.CustomerDefinition).SelectMany(cd => cd.DeliveryPoint).
                    Where(dp => dp.Archived != null).Select(arch => new FacilityArchivedData { ArchivedDate = (DateTime)arch.Archived, Identifier = arch.DeliveryPointId, Text = arch.Text, UserId = arch.ArchivedUserId, UserName = (arch.User.FirstName + " " + arch.User.Surname) }).Distinct();
        }

        /// <summary>
        /// To check the existence of facility
        /// </summary>
        /// <param name="text">Facility name</param>
        /// <param name="id">Facility Id</param>
        /// <returns>Flag indicating success or failure</returns>
        /// <summary>
        /// FacilityExists operation
        /// </summary>
        public bool FacilityExists(string text, int id)
        {
            if (id == 0)
            {
                return Repository.Find(f => f.Text.ToLower() == text.ToLower() && f.Archived == null).Count() > 0;
            }
            else
            {
                return Repository.Find(f => f.Text.ToLower() == text.ToLower() && f.FacilityId != id && f.Archived == null).Count() > 0;
            }

        }

        /// <summary>
        /// To check the existence of active customers in a facility
        /// </summary>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>Flag indicating success or failure</returns>
        /// <summary>
        /// FacilityHasActiveCustomers operation
        /// </summary>
        public bool FacilityHasActiveCustomers(short facilityId)
        {
            return Repository.Find(f => f.FacilityId == facilityId).SelectMany(f => f.Customers).Where(c => c.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Active || c.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Stop).Count() > 0;
        }

        /// <summary>
        /// Reads the facilities, associated customers and associated delivery points by user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <summary>
        /// ReadFacilitiesCustomersDeliveryPointsByUser operation
        /// </summary>
        public IList<Facility> ReadFacilitiesCustomersDeliveryPointsByUser(int userId, int tenancyId)
        {
            var context = (OperativeModelContainer)Repository.UnitOfWork.Context;

            var query = context.
                UserFacility.
                Where(i => i.UserId == userId && i.Facility.Owner.TenancyId == tenancyId).
                Select(i => new
                {
                    Facility = i.Facility,
                    Customers = i.Facility.Customers.Where(c => c.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Active),
                }).
                Select(i => new
                {
                    Facility = i.Facility,
                    Customers = i.Customers,
                    CustomerDefinitions = i.Customers.Select(c => c.CustomerDefinition),
                    DeliveryPoints = i.Customers.SelectMany(c => c.CustomerDefinition.DeliveryPoint).Where(dp => dp.Archived == null),
                }).
                Select(i => new
                {
                    Facility = i.Facility,
                    Customers = i.Customers,
                    CustomerDefinitions = i.CustomerDefinitions,
                    DeliveryPoints = i.DeliveryPoints,
                    UserDeliveryPoints = i.DeliveryPoints.Select(dp => dp.UserDeliveryPoints),
                });

            var facilities = query.
                ToList().
                OrderBy(i => i.Facility.Text).
                ThenBy(i => i.Customers.Select(c => c.Text)).
                ThenBy(i => i.DeliveryPoints.Select(dp => dp.Text)).
                Select(i => i.Facility);

            return facilities.ToList();
        }

        /// <summary>
        /// ReadTenancyDateTimeFormatData operation
        /// </summary>
        public DateTimeFormatData ReadTenancyDateTimeFormatData(int facilityId)
        {
            var context = (OperativeModelContainer)Repository.UnitOfWork.Context;

            return context.Facility.Where(i => i.FacilityId == facilityId)
                    .Select(i => i.Owner)
                    .Select(j => new DateTimeFormatData
                    {
                        TimeZoneId = j.TimeZoneId,
                        TimeZone = j.TimeZone.Text,
                        DateTimeFormatId = j.DateTimeFormatId,
                        ShortDateFormatId = j.DateTimeFormat.ShortDateFormatId,
                        LongDateFormatId = j.DateTimeFormat.LongDateFormatId,
                        ShortTimeFormatId = j.DateTimeFormat.ShortTimeFormatId,
                        LongTimeFormatId = j.DateTimeFormat.LongTimeFormatId,
                        ShortDateFormat = j.DateTimeFormat.ShortDateFormat.Text,
                        LongDateFormat = j.DateTimeFormat.LongDateFormat.Text,
                        ShortTimeFormat = j.DateTimeFormat.ShortTimeFormat.Text,
                        LongTimeFormat = j.DateTimeFormat.LongTimeFormat.Text
                    }).FirstOrDefault();

        }

    }
}