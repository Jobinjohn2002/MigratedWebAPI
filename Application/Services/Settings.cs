using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SynergyApplicationFrameworkApi.Application.Interfaces;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class Settings
    {
        public static T ReadGenericSetting<T, U>(U setting) where U : Models.Operative.Interfaces.ISetting
        {
            if (setting == null) return default(T);

            var value = setting.Value;

            object parsedValue = default(T);

            try
            {
                TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                parsedValue = (T)conv.ConvertFrom(value);
            }
            catch (InvalidCastException)
            {
                parsedValue = null;
            }
            catch (ArgumentException)
            {
                parsedValue = null;
            }

            return (T)parsedValue;
        }
    }
}
