using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderItem
    /// </summary>
    public class OrderItem
    {
        [SmartPropertyValidation]
        public int? ItemID { get; set; }
        /// <summary>
        /// Gets or sets ItemExternalID
        /// </summary>
        public string ItemExternalID { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        public int? InstanceID { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public ContainerInstance ContainerInstance { get; set; }

        public string ContainerInstancePrimaryId => ContainerInstance?.PrimaryId;

        public int? TurnaroundID { get; set; }
        public long? TurnaroundExternalID { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public OrderLineStatus Status { get; set; }
        public int? TurnaroundLastEventId { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
    }

    /// <summary>
    /// OrderDate
    /// </summary>
    public class OrderDate
    {
        [SmartPropertyValidation]
        public DateTime? Date { get; set; }
        public DateTime? ProcedureDate { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets AlternateID
        /// </summary>
        public string AlternateID { get; set; }
        public int? OrderIdToUpdate { get; set; }
    }

    /// <summary>
    /// OrderModel
    /// </summary>
    public class OrderModel
    {
        public OrderModel()
        {
            Dates = new List<OrderDate>();
            Lines = new List<OrderItem>();
        }

        [SmartPropertyValidation]
        public int? DeliveryPointID { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Dates
        /// </summary>
        public List<OrderDate> Dates { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Lines
        /// </summary>
        public List<OrderItem> Lines { get; set; }

        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public IEnumerable<GroupedListItem> DeliveryPoints { get; set; }

        /// <summary>
        /// OrganiseDates operation
        /// </summary>
        public void OrganiseDates()
        {
            if (Dates != null)
                Dates = Dates.OrderBy(d => d.Date.HasValue).ThenBy(d => d.Date).ToList();
        }

        /// <summary>
        /// Gets or sets ShowGettingStarted
        /// </summary>
        public bool ShowGettingStarted { get; set; }
        /// <summary>
        /// Gets or sets UseWizard
        /// </summary>
        public bool UseWizard { get; set; }

        public Guid? BatchNumberToUpdate { get; set; }
        public int? OrderId { get; set; }
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets Template
        /// </summary>
        public OrderTemplateModel Template { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public OrderTemplateConfirmation Confirmation { get; set; }
    }

    /// <summary>
    /// OrderTemplateModel
    /// </summary>
    public class OrderTemplateModel
    {
        public OrderTemplateModel()
        {
            Lines = new List<OrderTemplateItem>();
        }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Lines
        /// </summary>
        public List<OrderTemplateItem> Lines { get; set; }

        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public IEnumerable<ListItem> Customers { get; set; }

        /// <summary>
        /// Gets or sets ShowGettingStarted
        /// </summary>
        public bool ShowGettingStarted { get; set; }
        /// <summary>
        /// Gets or sets UseWizard
        /// </summary>
        public bool UseWizard { get; set; }

        public Guid? BatchNumber { get; set; }
        public int? OrderTemplateId { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets OrderTemplateName
        /// </summary>
        public string OrderTemplateName { get; set; }
    }

    /// <summary>
    /// OrderTemplateItem
    /// </summary>
    public class OrderTemplateItem
    {
        [SmartPropertyValidation]
        public int? ItemID { get; set; }
        /// <summary>
        /// Gets or sets ItemExternalID
        /// </summary>
        public string ItemExternalID { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        public int? OrderTemplateLineId { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets Availability
        /// </summary>
        public string Availability { get; set; }
    }
}