using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyObjectTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ObjectType concreteObjectType, ObjectType genericObjectType)
        {
            concreteObjectType.ObjectTypeId = genericObjectType.ObjectTypeId;
            concreteObjectType.Text = genericObjectType.Text;
        }
    }
}