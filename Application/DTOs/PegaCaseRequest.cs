using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	/// <summary>
	/// PegaCaseRequest
	/// </summary>
	public class PegaCaseRequest
	{
		[Required]
		/// <summary>
		/// Gets or sets ExternalSystem
		/// </summary>
		public ExternalSystem ExternalSystem { get; set; }
	}

	/// <summary>
	/// ExternalSystem
	/// </summary>
	public class ExternalSystem
	{
		/// <summary>
		/// Gets or sets Torq
		/// </summary>
		public Torq Torq { get; set; }
		/// <summary>
		/// Gets or sets SMS
		/// </summary>
		public SMS SMS { get; set; }
		[Required]
		/// <summary>
		/// Gets or sets Steris
		/// </summary>
		public Steris Steris { get; set; }
		[Required]
		/// <summary>
		/// Gets or sets Pega
		/// </summary>
		public Pega Pega { get; set; }
	}

	/// <summary>
	/// Torq
	/// </summary>
	public class Torq
	{
		/// <summary>
		/// Gets or sets ExternalCaseId
		/// </summary>
		public string ExternalCaseId { get; set; }
		/// <summary>
		/// Gets or sets Surgery
		/// </summary>
		public Surgery Surgery { get; set; }
	}

	/// <summary>
	/// Pega
	/// </summary>
	public class Pega
	{
		[Required]
		[MaxLength(50)]
		/// <summary>
		/// Gets or sets ExternalCaseId
		/// </summary>
		public string ExternalCaseId { get; set; }
		/// <summary>
		/// Gets or sets ExternalCaseStatus
		/// </summary>
		public string ExternalCaseStatus { get; set; }
	}

	/// <summary>
	/// SMS
	/// </summary>
	public class SMS
	{
		/// <summary>
		/// Gets or sets ExternalCaseId
		/// </summary>
		public string ExternalCaseId { get; set; }
		/// <summary>
		/// Gets or sets ExternalCaseStatus
		/// </summary>
		public string ExternalCaseStatus { get; set; }
		/// <summary>
		/// Gets or sets MovementId
		/// </summary>
		public string MovementId { get; set; }
		/// <summary>
		/// Gets or sets Surgery
		/// </summary>
		public Surgery Surgery { get; set; }
		/// <summary>
		/// Gets or sets ProductList
		/// </summary>
		public List<Product> ProductList { get; set; }
	}

	/// <summary>
	/// Steris
	/// </summary>
	public class Steris
	{
		/// <summary>
		/// Gets or sets ExternalCaseId
		/// </summary>
		public string ExternalCaseId { get; set; }
		/// <summary>
		/// Gets or sets ExternalCaseStatus
		/// </summary>
		public string ExternalCaseStatus { get; set; }
		[Required]
		/// <summary>
		/// Gets or sets ExternalDeliveryPointId
		/// </summary>
		public int ExternalDeliveryPointId { get; set; }
	}

	/// <summary>
	/// Surgery
	/// </summary>
	public class Surgery
	{
		/// <summary>
		/// Gets or sets Account
		/// </summary>
		public Account Account { get; set; }
		/// <summary>
		/// Gets or sets Surgeon
		/// </summary>
		public Surgeon Surgeon { get; set; }
		public DateTime? DeliveryDate { get; set; }
		/// <summary>
		/// Gets or sets Campus
		/// </summary>
		public string Campus { get; set; }
		/// <summary>
		/// Gets or sets Room
		/// </summary>
		public string Room { get; set; }
		public DateTime? SurgeryDate { get; set; }
		/// <summary>
		/// Gets or sets BodySide
		/// </summary>
		public string BodySide { get; set; }
		/// <summary>
		/// Gets or sets Procedure
		/// </summary>
		public Procedure Procedure { get; set; }
		/// <summary>
		/// Gets or sets SurgicalNotes
		/// </summary>
		public string SurgicalNotes { get; set; }
		/// <summary>
		/// Gets or sets PrimarySalesRep
		/// </summary>
		public PrimarySalesRep PrimarySalesRep { get; set; }

	}

	/// <summary>
	/// Account
	/// </summary>
	public class Account
	{
		/// <summary>
		/// Gets or sets AccountId
		/// </summary>
		public string AccountId { get; set; }
		/// <summary>
		/// Gets or sets AccountName
		/// </summary>
		public string AccountName { get; set; }
		/// <summary>
		/// Gets or sets ZipCode
		/// </summary>
		public string ZipCode { get; set; }
	}

	/// <summary>
	/// Surgeon
	/// </summary>
	public class Surgeon
    {
		/// <summary>
		/// Gets or sets SurgeonId
		/// </summary>
		public string SurgeonId { get; set; }
		/// <summary>
		/// Gets or sets SurgeonName
		/// </summary>
		public string SurgeonName { get; set; }
    }

	/// <summary>
	/// Procedure
	/// </summary>
	public class Procedure
    {
		/// <summary>
		/// Gets or sets ProcedureId
		/// </summary>
		public string ProcedureId { get; set; }
		[MaxLength(50)]
		/// <summary>
		/// Gets or sets ProcedureDescription
		/// </summary>
		public string ProcedureDescription { get; set; }
    }
	/// <summary>
	/// PrimarySalesRep
	/// </summary>
	public class PrimarySalesRep
	{
		[MaxLength(50)]
		/// <summary>
		/// Gets or sets PrimaryEmail
		/// </summary>
		public string PrimaryEmail { get; set; }
		/// <summary>
		/// Gets or sets TeamId
		/// </summary>
		public string TeamId { get; set; }
		/// <summary>
		/// Gets or sets SalesAssociateId
		/// </summary>
		public string SalesAssociateId { get; set; }
	}

	/// <summary>
	/// Product
	/// </summary>
	public class Product
	{
		[Required]
		[MaxLength(100)]
		/// <summary>
		/// Gets or sets ProductDescription
		/// </summary>
		public string ProductDescription { get; set; }
		/// <summary>
		/// Gets or sets ProductId
		/// </summary>
		public string ProductId { get; set; }
		[Required]
		[MaxLength(50)]
		/// <summary>
		/// Gets or sets AssetId
		/// </summary>
		public string AssetId { get; set; }
	}
}
