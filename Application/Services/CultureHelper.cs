using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class CultureHelper
    {
        /// <summary>
        /// CreateUserCultureData operation
        /// </summary>
        public static SqlParameter CreateUserCultureData(UserCultureData userCultureData)
        {
            var dt = new DataTable("Specification");
            dt.Columns.Add("Application", typeof(string));
            dt.Columns.Add("LanguageSet", typeof(string));
            dt.Columns.Add("Culture", typeof(string));

            dt.Rows.Add(userCultureData.Application, userCultureData.LanguageSet, userCultureData.Culture);

            return new SqlParameter
            {
                ParameterName = "CultureSetting",
                Value = dt,
                TypeName = "[dbo].[CultureSetting]",
                SqlDbType = SqlDbType.Structured
            }; 
        }
    }
}