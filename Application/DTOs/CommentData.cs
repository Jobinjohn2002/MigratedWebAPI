using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class CommentData 
	{
        public CommentData()
        {

        }
        /// <summary>
        /// Gets or sets CreatedByName
        /// </summary>
        public string CreatedByName { get; set; }
	}
}
		