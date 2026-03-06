using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class IpAddressHelper
    {
        /// <summary>
        /// GetIPAddress operation
        /// </summary>
        public static string GetIPAddress()
        {
            var context = OperationContext.Current;
            var properties = context.IncomingMessageProperties;
            var endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            var address = string.Empty;
            
            if (properties.Keys.Contains(HttpRequestMessageProperty.Name))
            {
                var endpointLoadBalancer = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                if (endpointLoadBalancer?.Headers["X-Forwarded-For"] != null)
                {
                    address = endpointLoadBalancer.Headers["X-Forwarded-For"];
                }
                else if (endpointLoadBalancer?.Headers["Remote_Addr"] != null)
                {
                    address = endpointLoadBalancer.Headers["Remote_Addr"];
                }
            }
            if (string.IsNullOrEmpty(address) && endpoint != null)
            {
                address = endpoint.Address;
            }

            return address;
        }

        /// <summary>
        /// DetermineCompName operation
        /// </summary>
        public static string DetermineCompName(string IP)
        {
            try
            {
                IPAddress myIP = IPAddress.Parse(IP);
                IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                List<string> compName = GetIPHost.HostName.Split('.').ToList();
                return compName.First();
            }
            catch (Exception)
            {
                return "Unknown";
            }
        }
    }
}
