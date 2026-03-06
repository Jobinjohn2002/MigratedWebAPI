using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class CustomerSettingRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public CustomerSetting Get(int customerSettingId)
        {
            return Repository.Find(customerSetting => customerSetting.CustomerSettingId == customerSettingId).FirstOrDefault();
        }

        /// <summary>
        /// Get operation
        /// </summary>
        public List<CustomerSetting> Get(string setting)
        {
            return Repository.Find(cs => cs.Name == setting).ToList();
        }

        public T ReadCustomerSetting<T>(int customerDefinitionId, string setting)
        {
            var customerSetting = Repository.Find(c => c.CustomerDefinitionId == customerDefinitionId && c.Name == setting).FirstOrDefault();

            if (customerSetting == null) return default(T);

            var value = customerSetting.Value;

            object parsedValue = default(T);

            try
            {
                TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                parsedValue = (T) conv.ConvertFrom(value);
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