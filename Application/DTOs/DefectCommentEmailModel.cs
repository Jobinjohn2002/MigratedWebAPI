using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DefectCommentEmailModel
    /// </summary>
    public class DefectCommentEmailModel
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

        public Comment Comment
        {
            get;
            set;
        }
    }
}