using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerDefectDetailData
    /// </summary>
    public class CustomerDefectDetailData
    {
        public CustomerDefectDetailData()
        { }

        public CustomerDefectDetailData(ICustomerDefectDetail data)
        {
            TurnaroundId = data.TurnaroundId;
            CustomerDefectId = data.CustomerDefectId;
            CreatedDate = data.CreatedDate;
            CreatedBy = data.CreatedBy;
            CreatedUser = data.CreatedUser;
            StatusId = data.StatusId;
            StatusName = data.StatusName;
            MissingInformation = data.MissingInformation;
            DetailsInformation = data.DetailsInformation;
            InternalDetailsInformation = data.InternalDetailsInformation;
            ResponseInformation = data.ResponseInformation;
            ExternalId = data.ExternalId;
        }

        public CustomerDefectDetailData(int turnaroundId, int customerDefectId, DateTime createdDate, int createdUserId, string createdUser, int statusId, string statusName,
            string missingInformation, string detailsInformation, string internalDetailsInformation, string responseInformation,string externalId)
        {
            TurnaroundId = turnaroundId;
            CustomerDefectId = customerDefectId;
            CreatedDate = createdDate;
            CreatedBy = createdUserId;
            CreatedUser = createdUser;
            StatusId = statusId;
            StatusName = statusName;
            MissingInformation = missingInformation;
            DetailsInformation = detailsInformation;
            InternalDetailsInformation = internalDetailsInformation;
            ResponseInformation = responseInformation;
            ExternalId = externalId;
        }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
		/// <summary>
		/// Gets or sets CustomerDefectId
		/// </summary>
		public int CustomerDefectId { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets CreatedUser
        /// </summary>
        public string CreatedUser { get; set; }
        /// <summary>
        /// Gets or sets StatusId
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// Gets or sets StatusName
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// Gets or sets MissingInformation
        /// </summary>
        public string MissingInformation { get; set; }
        /// <summary>
        /// Gets or sets DetailsInformation
        /// </summary>
        public string DetailsInformation { get; set; }
        /// <summary>
        /// Gets or sets InternalDetailsInformation
        /// </summary>
        public string InternalDetailsInformation { get; set; }
        /// <summary>
        /// Gets or sets ResponseInformation
        /// </summary>
        public string ResponseInformation { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
    }
}
