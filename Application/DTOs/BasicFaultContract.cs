using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BasicFaultContract
    /// </summary>
    public class BasicFaultContract
    {
        public BasicFaultContract(string faultId, string faultMessage)
        {
            FaultId = faultId;
            FaultMessage = faultMessage;
        }
        /// <summary>
        /// Gets or sets FaultId
        /// </summary>
        public string FaultId { get; private set; }
        /// <summary>
        /// Gets or sets FaultMessage
        /// </summary>
        public string FaultMessage { get; private set; }
    }
}