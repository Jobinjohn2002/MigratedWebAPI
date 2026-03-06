using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// Delivery Note Repository
    /// </summary>
    /// <remarks></remarks>
    public partial class DeliveryNoteRepository
    {
        /// <summary>
        /// Gets the specified deliverynote id.
        /// </summary>
        /// <param name="deliveryNoteId">The deliverynote id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		/// <summary>
		/// Get operation
		/// </summary>
		public DeliveryNote Get(int deliveryNoteId)
        {
            return Repository.Find(dn => dn.DeliveryNoteId == deliveryNoteId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the last unprinted deliverynote by delivery point id.
        /// </summary>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetLastUnprintedDeliveryNoteByDeliveryPointId operation
        /// </summary>
        public DeliveryNote GetLastUnprintedDeliveryNoteByDeliveryPointId(int deliveryPointId)
        {
            return
                Repository.Find(dn => dn.DeliveryPointId == deliveryPointId && dn.PrintedStatus == false).
                    OrderByDescending(dn => dn.Printed).FirstOrDefault();
        }

        /// <summary>
        /// Gets the last unprinted deliverynote by del point id and facility id.
        /// </summary>
        /// <param name="deliveryPointId"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        /// <summary>
        /// GetLastUnprintedDeliveryNoteByDeliveryPointAndFacility operation
        /// </summary>
        public DeliveryNote GetLastUnprintedDeliveryNoteByDeliveryPointAndFacility(int deliveryPointId, short facilityId)
        {
            return
                Repository.Find(
                    dn =>
                        dn.DeliveryPointId == deliveryPointId && dn.FacilityId == facilityId &&
                        dn.PrintedStatus == false).OrderByDescending(dn => dn.Printed).FirstOrDefault();
        }

        /// <summary>
        /// Loads the deliverynote list by facility.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// LoadDeliveryNoteListByFacility operation
        /// </summary>
        public IQueryable<DeliveryNote> LoadDeliveryNoteListByFacility(short facilityId)
        {
            return Repository.Find(dn => dn.FacilityId == facilityId);
        }

        /// <summary>
        /// Loads the unprinted delivery note list by facility.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// LoadUnprintedDeliveryNoteListByFacility operation
        /// </summary>
        public IQueryable<DeliveryNote> LoadUnprintedDeliveryNoteListByFacility(short facilityId)
        {
            return Repository.Find(dn => dn.FacilityId == facilityId && dn.PrintedStatus == false).OrderBy(d => d.DeliveryPoint.Text);
        }

        /// <summary>
        /// Loads the delivery note list bycustomer definition id.
        /// </summary>
        /// <param name="customerDefinitionId">The customer definition id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// LoadDeliveryNoteListBycustomerDefinitionId operation
        /// </summary>
        public IQueryable<DeliveryNote> LoadDeliveryNoteListBycustomerDefinitionId(int customerDefinitionId)
        {
			return Repository.Find((dn => dn.DeliveryPoint.CustomerDefinitionId == customerDefinitionId));
        }

        /// <summary>
        /// Loads the delivery notes by date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// LoadDeliveryNotesByDate operation
        /// </summary>
        public IQueryable<DeliveryNote> LoadDeliveryNotesByDate(DateTime date, int deliveryPointId)
        {
            var endDate = date.AddDays(1);

            return Repository.Find(dn => dn.DeliveryPointId == deliveryPointId && dn.Printed >= date && dn.Printed <= endDate);
        }

        /// <summary>
        /// Loads the delivery notes by date and facility.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="facilityId">The stations facility Id</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// LoadDeliveryNotesByDate operation
        /// </summary>
        public IQueryable<DeliveryNote> LoadDeliveryNotesByDate(DateTime date, int facilityId, int deliveryPointId)
        {
            var endDate = date.AddDays(1);

            return Repository.Find(dn => dn.FacilityId == facilityId && dn.DeliveryPointId == deliveryPointId && dn.Printed >= date && dn.Printed <= endDate);
        }

        /// <summary>
        /// Loads the deliverynote list by delivery point.
        /// </summary>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// LoadDeliveryNoteListByDeliveryPoint operation
        /// </summary>
        public IQueryable<DeliveryNote> LoadDeliveryNoteListByDeliveryPoint(int deliveryPointId)
        {
            return Repository.Find((dn => dn.DeliveryPoint.DeliveryPointId == deliveryPointId));
        }

        /// <summary>
        /// Reads the deliverynote by external id.
        /// </summary>
        /// <param name="externalId">The external id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadDeliveryNoteByExternalId operation
        /// </summary>
        public DeliveryNote ReadDeliveryNoteByExternalId(int externalId,short facilityId)
        {
            return Repository.Find(dn => dn.ExternalId == externalId && dn.FacilityId == facilityId).FirstOrDefault();
        }

        /// <summary>
        /// ReadDeliveryNoteByExternalId operation
        /// </summary>
        public DeliveryNote ReadDeliveryNoteByExternalId(int externalid)
        {
            return Repository.Find(dn => dn.ExternalId == externalid).FirstOrDefault();
        }

      
    }
}