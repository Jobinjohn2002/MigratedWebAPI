using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IDataCommand
    /// </summary>
    public interface IDataCommand
    {
        IList<T> GetEntityList<T>() where T : class;

        void ExecuteNonQuery();
        object ExecuteScalar();
        WorkflowReturnType ExecuteWorkflowSP();
    }

    /// <summary>
    /// WorkflowReturnType
    /// </summary>
    public class WorkflowReturnType
    {
        public int ReturnCode
        {
            get;
            set;
        }

        public int TurnaroundId
        {
            get;
            set;
        }

        public bool HasWarning
        {
            get;
            set;
        }

        public bool HasNotes
        {
            get;
            set;
        }
    }
}