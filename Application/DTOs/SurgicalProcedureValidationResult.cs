using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SurgicalProcedureValidationResult
    /// </summary>
    public class SurgicalProcedureValidationResult
    {
        public long? ExternalTurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
        /// <summary>
        /// Gets or sets Level
        /// </summary>
        public SurgicalProcedureValidationLevel Level { get; set; }
        
        public SurgicalProcedureValidationError? Error { get; set; }
        public SurgicalProcedureValidationWarning? Warning { get; set; }

        public string FormattedMessage => ExternalTurnaroundId.HasValue ? Message.Replace(Constants.SurgicalProcedure.FormatParameters.Turnaround, ExternalTurnaroundId.Value.ToString()) : Message;

        public SurgicalProcedureValidationResult(SurgicalProcedureValidationError error, long? externalTurnaroundId = null)
        {
            Error = error;
            Level = SurgicalProcedureValidationLevel.Error;
            ExternalTurnaroundId = externalTurnaroundId;

            switch(error)
            {
                case SurgicalProcedureValidationError.InvalidUsagePoint:
                    {
                        Message = Constants.SurgicalProcedure.Errors.InvalidUsagePoint;
                        StatusCode = HttpStatusCode.Conflict;
                        break;
                    }
                case SurgicalProcedureValidationError.SaveFailed:
                    {
                        Message = Constants.SurgicalProcedure.Errors.SaveFailed;
                        StatusCode = HttpStatusCode.InternalServerError;
                        break;
                    }
                case SurgicalProcedureValidationError.InvalidStation:
                    {
                        Message = Constants.SurgicalProcedure.Errors.InvalidStation;
                        StatusCode = HttpStatusCode.Conflict;
                        break;
                    }
                case SurgicalProcedureValidationError.TurnaroundInvalid:
                    {
                        Message = Constants.SurgicalProcedure.Errors.TurnaroundInvalid;
                        StatusCode = HttpStatusCode.Conflict;
                        break;
                    }
                case SurgicalProcedureValidationError.TurnaroundRestricted:
                    {
                        Message = Constants.SurgicalProcedure.Errors.TurnaroundRestricted;
                        StatusCode = HttpStatusCode.Conflict;
                        break;
                    }
                case SurgicalProcedureValidationError.TurnaroundWrongCustomer:
                    {
                        Message = Constants.SurgicalProcedure.Errors.TurnaroundWrongCustomer;
                        StatusCode = HttpStatusCode.Conflict;
                        break;
                    }
                case SurgicalProcedureValidationError.TurnaroundInvalidItemType:
                    {
                        Message = Constants.SurgicalProcedure.Errors.TurnaroundInvalidItemType;
                        StatusCode = HttpStatusCode.Conflict;
                        break;
                    }
                case SurgicalProcedureValidationError.TurnaroundAlreadyUsed:
                    {
                        Message = Constants.SurgicalProcedure.Errors.TurnaroundAlreadyUsed;
                        StatusCode = HttpStatusCode.Conflict;
                        break;
                    }
                case SurgicalProcedureValidationError.InvalidHospital:
                    {
                        Message = Constants.SurgicalProcedure.Errors.InvalidHospital;
                        StatusCode = HttpStatusCode.Conflict;
                        break;
                    }
                case SurgicalProcedureValidationError.DuplicatedTurnaround:
                    {
                        Message = Constants.SurgicalProcedure.Errors.DuplicateTurnaround;
                        StatusCode = HttpStatusCode.BadRequest;
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("Unhandled value: " + error.ToString());
                    }
            }
        }

        public SurgicalProcedureValidationResult(SurgicalProcedureValidationWarning warning, long? externalTurnaroundId = null)
        {
            Warning = warning;
            Level = SurgicalProcedureValidationLevel.Warning;
            ExternalTurnaroundId = externalTurnaroundId;

            switch (warning)
            {
                case SurgicalProcedureValidationWarning.TurnaroundNotCurrent:
                    {
                        Message = Constants.SurgicalProcedure.Warnings.TurnaroundNotCurrent;
                        break;
                    }
                case SurgicalProcedureValidationWarning.InvalidWorkflowForIntoStock:
                    {
                        Message = Constants.SurgicalProcedure.Warnings.InvalidWorkflowForIntoStock;
                        break;
                    }
                case SurgicalProcedureValidationWarning.TurnaroundIntoStockFailed:
                    {
                        Message = Constants.SurgicalProcedure.Warnings.TurnaroundIntoStockFailed;
                        break;
                    }
                case SurgicalProcedureValidationWarning.ExistingProcedureType:
                    {
                        Message = Constants.SurgicalProcedure.Warnings.ExistingProcedureType;
                        break;
                    }
                case SurgicalProcedureValidationWarning.ExistingSurgeon:
                    {
                        Message = Constants.SurgicalProcedure.Warnings.ExistingSurgeon;
                        break;
                    }
                case SurgicalProcedureValidationWarning.TurnaroundExtraNotMoved:
                    {
                        Message = Constants.SurgicalProcedure.Warnings.TurnaroundExtraNotMoved;
                        break;
                    }
                case SurgicalProcedureValidationWarning.TurnaroundSterileExpiryPriorToProcedureDate:
                    {
                        Message = Constants.SurgicalProcedure.Warnings.TurnaroundSterileExpiryPriorToProcedureDate;
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("Unhandled value: " + warning.ToString());
                    }
            }
        }
    }
    public enum SurgicalProcedureValidationError : byte
    {
        [EnumMember]
        InvalidUsagePoint = 1,
        [EnumMember]
        SaveFailed = 2,
        [EnumMember]
        InvalidStation = 3,
        [EnumMember]
        TurnaroundInvalid = 4,
        [EnumMember]
        TurnaroundRestricted = 5,
        [EnumMember]
        TurnaroundWrongCustomer = 6,
        [EnumMember]
        TurnaroundInvalidItemType = 7,
        [EnumMember]
        TurnaroundAlreadyUsed = 8,
        [EnumMember]
        InvalidHospital = 9,
        [EnumMember]
        DuplicatedTurnaround = 10
    }
    public enum SurgicalProcedureValidationWarning : byte
    {
        /// <summary>
        /// A newer turnaround of the instance exists for the provided turnaround, therefore the item will not be moved into the usage point.
        /// </summary>
        [EnumMember]
        TurnaroundNotCurrent = 1,

        /// <summary>
        /// The turnaround is not in a valid state to be moved into the usage point.
        /// </summary>
        [EnumMember]
        InvalidWorkflowForIntoStock = 2,

        /// <summary>
        /// We attempted to move the turnaround into the usage point, but the operation failed.
        /// </summary>
        [EnumMember]
        TurnaroundIntoStockFailed = 3,

        /// <summary>
        /// The procedure type provided already exists with the same reference, but with a different name. The existing procedure type has been used instead.
        /// </summary>
        [EnumMember]
        ExistingProcedureType = 4,

        /// <summary>
        /// The surgeon provided already exists with the same reference, but with a different name. The existing surgeon has been used instead.
        /// </summary>
        [EnumMember]
        ExistingSurgeon = 5,

        /// <summary>
        /// The turnaround provided is an extra, and hence can't be moved into the usage point.
        /// </summary>
        [EnumMember]
        TurnaroundExtraNotMoved = 6,

        /// <summary>
        /// The sterile expiry of the turnaround is prior to the provided surgical procedure schedule date.
        /// </summary>
        [EnumMember]
        TurnaroundSterileExpiryPriorToProcedureDate = 7
    }

    public enum SurgicalProcedureValidationLevel : byte
    {
        Warning,
        Error
    }
}
