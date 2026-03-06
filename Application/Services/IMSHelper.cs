using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class IMSHelper
    {
        /// <summary>
        /// ToIDTable operation
        /// </summary>
        public static DataTable ToIDTable(this IQueryable<CustomerDefinition> qry)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));

            foreach (var row in qry)
            {
                dt.Rows.Add(row.CustomerDefinitionId);
            }

            return dt;
        }
        /// <summary>
        /// ToIDTable operation
        /// </summary>
        public static DataTable ToIDTable(this IQueryable<ItemType> qry)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));

            foreach (var row in qry)
            {
                dt.Rows.Add(row.ItemTypeId);
            }

            return dt;
        }

        /// <summary>
        /// Validation method for result parameters
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// ValidateParameters operation
        /// </summary>
        public static HttpResponseMessage ValidateParameters(this ResultParameterModel resultParameterModel, HttpRequestMessage request)
        {
            if (resultParameterModel.skip != null && resultParameterModel.skip < 0)
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, Services.Constants.General.Errors.InvalidArgument + nameof(resultParameterModel.skip));
            if (resultParameterModel.max != null &&  resultParameterModel.max < 1)
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, Services.Constants.General.Errors.InvalidArgument + nameof(resultParameterModel.max));
            if (resultParameterModel.start != null &&  resultParameterModel.start > DateTime.UtcNow)
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, Services.Constants.General.Errors.InvalidArgument + nameof(resultParameterModel.start));
            if (resultParameterModel.end != null &&  resultParameterModel.end > DateTime.UtcNow)
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, Services.Constants.General.Errors.InvalidArgument + nameof(resultParameterModel.end));

            return null;
        }
    }
}