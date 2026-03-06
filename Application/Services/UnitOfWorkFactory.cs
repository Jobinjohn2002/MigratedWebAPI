using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class UnitOfWorkFactory
    {
        public static Operative.IUnitOfWork CreateOperativeEFUnitOfWork()
        {
            return InstanceFactory.GetInstance<IUnitOfWork>();
        }
    }
}
