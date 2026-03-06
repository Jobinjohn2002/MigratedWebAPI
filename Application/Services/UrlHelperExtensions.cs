using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// WebApi operation
        /// </summary>
        public static string WebApi(this UrlHelper helper, string action, string controller, object routeValues = null)
        {
            return WebApi(helper, action, controller, "Api", routeValues);
        }

        /// <summary>
        /// WebApi operation
        /// </summary>
        public static string WebApi(this UrlHelper helper, string action, string controller, string area, object routeValues = null)
        {
            var routes = (routeValues == null ? new RouteValueDictionary() : new RouteValueDictionary(routeValues));

            routes.Add("action", action);

            routes.Add("controller", controller);

            routes.Add("httproute", "");

            return helper.HttpRouteUrl(area, routes);
        }

        /// <summary>
        /// FullyQualifiedAction operation
        /// </summary>
        public static string FullyQualifiedAction(this UrlHelper url, string action, string controller)
        {
            return FullyQualifiedAction(url, action, controller, null);
        }

        /// <summary>
        /// FullyQualifiedAction operation
        /// </summary>
        public static string FullyQualifiedAction(this UrlHelper url, string action, string controller, object routeValues)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            var request = url.RequestContext.HttpContext.Request;

            return request.Url == null ? url.Action(action, controller, routeValues) : url.Action(action, controller, routeValues, request.Url.Scheme);
        }
    }
}