using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HttpRequestBase extension class
    /// </summary>
    public static class HttpRequestBaseExtensions
    {
        /// <summary>
        /// Gets the root Url from the request, e.g. if the url is http://localhost/controller/action, the root url will be http://localhost/
        /// </summary>
        /// <param name="request">The HttpRequestBase</param>
        /// <returns>The root Url</returns>
        /// <summary>
        /// UrlRoot operation
        /// </summary>
        public static string UrlRoot(this HttpRequestBase request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            return string.Format("{0}://{1}/", request.Url.Scheme, request.Url.Authority);
        }
    }
}
