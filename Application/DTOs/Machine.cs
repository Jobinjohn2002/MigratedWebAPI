using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class Machine
    {
        public Batch CurrentInProgressBatch
        {
            get
            {
                return (Batch.Where(batch => batch.BatchStatusId == (int)BatchStatusIdentifier.InProgress && batch.Archived == null).OrderByDescending(batch => batch.Created).FirstOrDefault());
            }
        }
    }
}
