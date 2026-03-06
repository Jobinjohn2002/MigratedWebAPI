using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// RouteValueDictionary extension class
    /// </summary>
    public static class RouteValueDictionaryExtensions
    {
        /// <summary>
        /// Combines two RouteValueDictionary collections together.  Values in the additional values collection will overwrite those in the initial values collection if present.
        /// </summary>
        /// <param name="initialValues">The initial values collection.</param>
        /// <param name="newValues">The new values collection to merge in.</param>
        /// <returns>A new collection containing the merged data.</returns>
        /// <summary>
        /// Merge operation
        /// </summary>
        public static RouteValueDictionary Merge(this RouteValueDictionary initialValues, RouteValueDictionary newValues = null)
        {
            var merged = new RouteValueDictionary(initialValues);

            if (newValues != null && newValues.Count > 0)
            {
                newValues.ToList().ForEach(x => merged[x.Key] = x.Value);
            }

            return merged;
        }

        /// <summary>
        /// Adds a route to the collection and returns the collection.
        /// </summary>
        /// <param name="routes">The collection to add a route to.</param>
        /// <param name="key">The route key.</param>
        /// <param name="value">The route value.</param>
        /// <returns>The route value dictionary.</returns>
        /// <summary>
        /// ChainAdd operation
        /// </summary>
        public static RouteValueDictionary ChainAdd(this RouteValueDictionary routes, string key, object value)
        {
            if (routes.ContainsKey(key))
                routes[key] = value;
            else
                routes.Add(key, value);

            return routes;
        }

        /// <summary>
        /// ToQueryString operation
        /// </summary>
        public static string ToQueryString(this RouteValueDictionary routes)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var route in routes)
            {
                if (route.Value != null)
                {
                    if (typeof(List<string>).IsAssignableFrom(route.Value.GetType()))
                    {
                        foreach (var value in route.Value as List<string>)
                        {
                            if (sb.Length > 0)
                                sb.Append('&');

                            sb.Append(HttpUtility.UrlEncode(route.Key))
                                .Append('=')
                                .Append(HttpUtility.UrlEncode(value.ToString()));
                        }
                    }
                    else
                    {
                        if (sb.Length > 0)
                            sb.Append('&');

                        sb.Append(HttpUtility.UrlEncode(route.Key))
                            .Append('=')
                            .Append(HttpUtility.UrlEncode(route.Value.ToString()));
                    }
                }
                else
                {
                    if (sb.Length > 0)
                        sb.Append('&');

                    sb.Append(HttpUtility.UrlEncode(route.Key))
                            .Append('=');
                }
            }

            if (sb.Length > 0)
                sb.Insert(0, '?');

            return sb.ToString();
        }
    }
}