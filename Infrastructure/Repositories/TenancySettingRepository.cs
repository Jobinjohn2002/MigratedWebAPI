using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class TenancySettingRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public TenancySetting Get(int tenancySettingId)
        {
            return Repository.Find(tenancySetting => tenancySetting.TenancySettingId == tenancySettingId).FirstOrDefault();
        }

        /// <summary>
        /// Reads a tenancy setting for and returns the value as the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tenancyId">The Id of the tenancy to look for settings.</param>
        /// <param name="setting">The name of the setting to look for.</param>
        /// <returns>The value recovered for the specified setting.</returns>
        public T ReadTenancySetting<T>(int tenancyId, string setting)
        {
            var tenancySetting = Repository.Find(t => t.TenancyId == tenancyId && t.Name == setting).FirstOrDefault();

            if (tenancySetting == null) return default(T);

            var value = tenancySetting.Value;

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