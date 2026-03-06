using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// BaseHelper
    /// </summary>
    public class BaseHelper
    {
        protected SynergyTrakData Data { get; set; }

        protected ILog Log;

        public BaseHelper(SynergyTrakData data)
        {
            Data = data;
            Log = InstanceFactory.GetInstance<ILog>();
        }
    }
}