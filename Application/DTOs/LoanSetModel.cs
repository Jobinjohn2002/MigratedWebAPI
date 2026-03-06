using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum LoansetDetailsTab
    {
        Details = 0,
        Edit = 1,
        Comments = 2
    }

    /// <summary>
    /// LoanSetModel
    /// </summary>
    public class LoanSetModel
    {
        /// <summary>
        /// Gets or sets Loanset
        /// </summary>
        public LoanSet Loanset { get; set; }
        /// <summary>
        /// Gets or sets LoansetId
        /// </summary>
        public int LoansetId { get; set; }
        /// <summary>
        /// Gets or sets LoansetStatusId
        /// </summary>
        public int LoansetStatusId { get; set; }
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// Gets or sets RecordedBy
        /// </summary>
        public string RecordedBy { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ContactNumber
        /// </summary>
        public string ContactNumber { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Supplier
        /// </summary>
        public string Supplier { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Manufacturer
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Gets or sets Hospital
        /// </summary>
        public string Hospital { get; set; }
        /// <summary>
        /// Gets or sets Theatre
        /// </summary>
        public string Theatre { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Consultant
        /// </summary>
        public string Consultant { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets PONumber
        /// </summary>
        public string PONumber { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ItemDescription
        /// </summary>
        public string ItemDescription { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Checker
        /// </summary>
        public string Checker { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Gets or sets NumberOfItems
        /// </summary>
        public int NumberOfItems { get; set; }
        [SmartPropertyValidation]
        public int? LocationId { get; set; }
        /// <summary>
        /// Gets or sets HasUsedBefore
        /// </summary>
        public bool HasUsedBefore { get; set; }
        /// <summary>
        /// Gets or sets LongTerm
        /// </summary>
        public bool LongTerm { get; set; }
        /// <summary>
        /// Gets or sets HasCEMark
        /// </summary>
        public bool HasCEMark { get; set; }
        /// <summary>
        /// Gets or sets HasDecontaminationCertificate
        /// </summary>
        public bool HasDecontaminationCertificate { get; set; }
        /// <summary>
        /// Gets or sets HasProcessingInstructions
        /// </summary>
        public bool HasProcessingInstructions { get; set; }
        /// <summary>
        /// Gets or sets HasTrayContentList
        /// </summary>
        public bool HasTrayContentList { get; set; }
        /// <summary>
        /// Gets or sets HasPhotoOfItems
        /// </summary>
        public bool HasPhotoOfItems { get; set; }
        /// <summary>
        /// Gets or sets LoanSetSaved
        /// </summary>
        public bool LoanSetSaved { get; set; }
        /// <summary>
        /// Gets or sets ShowGettingStarted
        /// </summary>
        public bool ShowGettingStarted { get; set; }
        /// <summary>
        /// Gets or sets ConfirmedTrayList
        /// </summary>
        public bool ConfirmedTrayList { get; set; }

        /// <summary>
        /// Gets or sets Contents
        /// </summary>
        public List<LoanSetContentsModel> Contents { get; set; }    

        /// <summary>
        /// Gets or sets Schedule
        /// </summary>
        public List<ScheduleDate> Schedule { get; set; }

        [SmartPropertyValidation]
        [DateOnly(AssumeDateOnlyTimeComponent.AssumeUtcMiddayForDateTime)]
        public DateTime? DeliveryDate { get; set; }

        [SmartPropertyValidation]
        [DateOnly(AssumeDateOnlyTimeComponent.AssumeUtcMiddayForDateTime)]
        public DateTime? ReturnDate { get; set; }

        /// <summary>
        /// Gets or sets RecordedDate
        /// </summary>
        public DateTime RecordedDate { get; set; }

        public LoanSetModel()
        {
            Contents = new List<LoanSetContentsModel>();
            Schedule = new List<ScheduleDate>();
        }

        /// <summary>
        /// ReorganiseSchedule operation
        /// </summary>
        public void ReorganiseSchedule()
        {
            Schedule = Schedule.OrderByDescending(s => s.Date.HasValue).ThenBy(s => s.Date).ToList();

            var idx = 0;
            Schedule.ForEach(s =>
            {
                s.ScheduleNumber = idx;
                idx++;
            });
        }

        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public IList<Comment> Comments { get; set; }
        /// <summary>
        /// Gets or sets Mode
        /// </summary>
        public string Mode { get; set; }
        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public LoansetDetailsTab SelectedTab { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public string Facility { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public LoanSetConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets RequestOriginator
        /// </summary>
        public int RequestOriginator { get; set; }
        /// <summary>
        /// Gets or sets Owner
        /// </summary>
        public User Owner { get; set; }
        /// <summary>
        /// Gets or sets LoanStatusName
        /// </summary>
        public string LoanStatusName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets HasPhoto
        /// </summary>
        public bool HasPhoto { get; set; }

        /// <summary>
        /// Gets or sets ExternalReference
        /// </summary>
        public string ExternalReference { get; set; }
        public Pathway.Enums.ExternalReferenceTypeIdentifier? ExternalTypeId { get; set; }
        /// <summary>
        /// Gets or sets HasBeenChecked
        /// </summary>
        public bool HasBeenChecked { get; set; }
        /// <summary>
        /// Gets or sets AnyDiscrepancies
        /// </summary>
        public bool AnyDiscrepancies { get; set; }

    }

    /// <summary>
    /// LoanSetContentsModel
    /// </summary>
    public class LoanSetContentsModel
    {
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Tray
        /// </summary>
        public string Tray { get; set; }
        /// <summary>
        /// Gets or sets DiscrepancyNumber
        /// </summary>
        public int DiscrepancyNumber { get; set; }
        public int? DiscrepancyId { get; set; }
        [SmartPropertyValidation]
        public int? ItemQty { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Details
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// Gets or sets Remove
        /// </summary>
        public bool Remove { get; set; }
        /// <summary>
        /// Gets or sets Mode
        /// </summary>
        public string Mode { get; set; }
        /// <summary>
        /// Gets or sets IsNew
        /// </summary>
        public bool IsNew { get; set; }
        public int? ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Barcode
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// Gets or sets isReadonly
        /// </summary>
        public bool isReadonly { get; set; }   
        /// <summary>
        /// Gets or sets AnyDiscrepancy
        /// </summary>
        public bool AnyDiscrepancy { get; set; }
        /// <summary>
        /// Gets or sets HasDeliveryPointAccess
        /// </summary>
        public bool HasDeliveryPointAccess { get; set; }
    }

    /// <summary>
    /// ScheduleDate
    /// </summary>
    public class ScheduleDate
    {
        /// <summary>
        /// Gets or sets ScheduleNumber
        /// </summary>
        public int ScheduleNumber { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ProcedureReference
        /// </summary>
        public string ProcedureReference { get; set; }
        /// <summary>
        /// Gets or sets ProcedurePlaceHolderReference
        /// </summary>
        public string ProcedurePlaceHolderReference { get; set; }
        /// <summary>
        /// Gets or sets ProcedureId
        /// </summary>
        public int ProcedureId { get; set; }
        [SmartPropertyValidation]
        public DateTime? Date { get; set; }
        /// <summary>
        /// Gets or sets Remove
        /// </summary>
        public bool Remove { get; set; }
        /// <summary>
        /// Gets or sets isReadonly
        /// </summary>
        public bool isReadonly { get; set; }
        /// <summary>
        /// Gets or sets Mode
        /// </summary>
        public string Mode { get; set; }
        /// <summary>
        /// Gets or sets IsNew
        /// </summary>
        public bool IsNew { get; set; }
    }
}