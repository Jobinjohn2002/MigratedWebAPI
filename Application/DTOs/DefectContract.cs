using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class DefectContract 
	{
	    #region Implementation of IDefect
        /// <summary>
        /// Gets or sets Barcode
        /// </summary>
        public string Barcode { get; set; }
	    #endregion
	}
}
		