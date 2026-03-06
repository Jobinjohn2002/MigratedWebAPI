using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PegaCaseValidationResult
    /// </summary>
    public class PegaCaseValidationResult
    {
        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets StatusCode
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        
        public PegaCaseValidationResult(PegaCaseValidationCode validationCode)
        {
            switch(validationCode)
            {
                case PegaCaseValidationCode.InvalidDeliveryPoint:
                    Message = Constants.PegaCase.Errors.DeliveryPointIdNotFound;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case PegaCaseValidationCode.InvalidAssetId:
                    Message = Constants.PegaCase.Errors.InstanceNotFound;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case PegaCaseValidationCode.SaveError:
                    Message = Constants.General.Errors.SaveFailed;
                    StatusCode = HttpStatusCode.InternalServerError;
                    break;
                case PegaCaseValidationCode.BadRequest:
                    Message = Constants.PegaCase.Errors.SurgeryDateProcedureDescriptionRequired;
                    StatusCode = HttpStatusCode.BadRequest;
                    break;
            }
        }
    }

    public enum PegaCaseValidationCode
    {
        [EnumMember]
        Success = 1,
        [EnumMember]
        SaveError = 2,
        [EnumMember]
        InvalidDeliveryPoint = 3,
        [EnumMember]
        InvalidAssetId = 4,
        [EnumMember]
        BadRequest = 5,
    }
}
