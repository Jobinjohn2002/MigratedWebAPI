using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class DefectData
	{
        /// <summary>
        /// Gets or sets Barcode
        /// </summary>
        public string Barcode { get; set; }

	    public DefectData()
        {
        }
		/// <summary>
		/// Gets or sets SeverityName
		/// </summary>
		public string SeverityName { get; set; }
		/// <summary>
		/// Gets or sets ClassificationName
		/// </summary>
		public string ClassificationName { get; set; }
		/// <summary>
		/// Gets or sets DefectStatusName
		/// </summary>
		public string DefectStatusName { get; set; }
		/// <summary>
		/// Gets or sets DeliveryPointName
		/// </summary>
		public string DeliveryPointName { get; set; }
		/// <summary>
		/// Gets or sets DefectTypeName
		/// </summary>
		public string DefectTypeName { get; set; }
		/// <summary>
		/// Gets or sets CustomerId
		/// </summary>
		public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
		/// <summary>
		/// Gets or sets CustomerName
		/// </summary>
		public string CustomerName { get; set; }
		public long? TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets DefectType
        /// </summary>
        public string DefectType { get; set; }
        /// <summary>
        /// Gets or sets SerialNumber
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets whether defect is customer defect or not.
        /// </summary>
        /// <value>true - customer defect, false - defect</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets IsCustomerDefect
        /// </summary>
        public bool IsCustomerDefect { get; set; }

        /// <summary>
        /// Gets or sets Container Instance Primary Id.
        /// </summary>
        /// <value>Container Instance Primary Id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets Container External Id.
        /// </summary>
        /// <value>Container External Id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerExternalId
        /// </summary>
        public string ContainerExternalId { get; set; }

        /// <summary>
        /// Turnaround events selected at service reports.
        /// </summary>
        /// <summary>
        /// Gets or sets SelectedTurnaroundEvents
        /// </summary>
        public List<int> SelectedTurnaroundEvents { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public List<CommentData> Comments { get; set; }
        /// <summary>
        /// Gets or sets TotalRows
        /// </summary>
        public int TotalRows { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Facility id in which the Turnaround is being processed .
        /// </summary>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
    }
}