using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{

    public enum MessageSeverity
    {
        Null = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Critical = 4
    }


    [Serializable]
    /// <summary>
    /// OperationResponseContract
    /// </summary>
    public class OperationResponseContract
    {
        public OperationResponseContract()
        {
        }

        public OperationResponseContract(bool success)
        {
            Successful = success;
        }

        public OperationResponseContract(bool success, string message)
        {
            Successful = success;
            Message = message;
        }

        #region IOperationResponse Members
        /// <summary>
        /// Gets or sets Successful
        /// </summary>
        public bool Successful { get; set; }
        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets ItemCount
        /// </summary>
        public int ItemCount { get; set; }
        /// <summary>
        /// Gets or sets PrintJobs
        /// </summary>
        public IList<PrintDetailsDataContract> PrintJobs { get; set; }

        #endregion
    }
    [Serializable]
    /// <summary>
    /// OperationResponseContract
    /// </summary>
    public class OperationResponseContract<TData> : OperationResponseContract
    {
        public OperationResponseContract()
            : this(default(TData), null, MessageSeverity.Null)
        {
        }

        public OperationResponseContract(TData data)
            : this(data, null, MessageSeverity.Null)
        {
        }

        public OperationResponseContract(TData data, bool successful)
            : this(data, null, MessageSeverity.Null)
        {
            Successful = successful;
        }

        public OperationResponseContract(TData data, string message, MessageSeverity messageSeverity)
        {
            Data = data;
            Message = message;
            MessageSeverity = messageSeverity;
        }
        /// <summary>
        /// Gets or sets Data
        /// </summary>
        public TData Data { get; set; }
        /// <summary>
        /// Gets or sets MessageSeverity
        /// </summary>
        public MessageSeverity MessageSeverity { get; set; }
    }
}