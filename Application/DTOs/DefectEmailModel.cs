using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DefectEmailModel
    /// </summary>
    public class DefectEmailModel
    {
        public string Reference
        {
            get;
            set;
        }

        public string TurnaroundExternalID
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string ReportedBy
        {
            get;
            set;
        }

        public string Position
        {
            get;
            set;
        }

        public string Department
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public string Customer
        {
            get;
            set;
        }

        public string Classification
        {
            get;
            set;
        }

        public string Severity
        {
            get;
            set;
        }

        public string[] Comments
        {
            get;
            set;
        }

        public string ProductName
        {
            get;
            set;
        }
    }
}