using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	/// <summary>
	/// InventoryCaseRequest
	/// </summary>
	public class InventoryCaseRequest
	{
		[Required]
		/// <summary>
		/// Gets or sets ExternalSystem
		/// </summary>
		public InventoryCaseExternalSystem ExternalSystem { get; set; }
	}

	/// <summary>
	/// InventoryCaseExternalSystem
	/// </summary>
	public class InventoryCaseExternalSystem
	{
		[Required]
		/// <summary>
		/// Gets or sets SMS
		/// </summary>
		public InventoryCaseSMS SMS { get; set; }
		/// <summary>
		/// Gets or sets Pega
		/// </summary>
		public InventoryCasePega Pega { get; set; }
	}

	/// <summary>
	/// InventoryCasePega
	/// </summary>
	public class InventoryCasePega
	{
		[Required]
		[MaxLength(50)]
		/// <summary>
		/// Gets or sets ExternalCaseId
		/// </summary>
		public string ExternalCaseId { get; set; }
	}

	/// <summary>
	/// InventoryCaseSMS
	/// </summary>
	public class InventoryCaseSMS
	{
		[Required]
		/// <summary>
		/// Gets or sets ProductList
		/// </summary>
		public List<InventoryCaseProduct> ProductList { get; set; }
	}

	/// <summary>
	/// InventoryCaseProduct
	/// </summary>
	public class InventoryCaseProduct : Product
	{
		[Required]
		[MaxLength(50)]
		/// <summary>
		/// Gets or sets Status
		/// </summary>
		public string Status { get; set; }

		[JsonIgnore]
		/// <summary>
		/// Gets or sets KnownStatus
		/// </summary>
		public InventoryCaseProductStatus KnownStatus { get; set; }
		/// <summary>
		/// Gets or sets TurnaroundId
		/// </summary>
		public int TurnaroundId { get; set; }
	}

	public enum InventoryCaseProductStatus
	{
		OnHold,
		OffHold
	}
}
