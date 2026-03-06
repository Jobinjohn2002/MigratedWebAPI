using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel;
using SynergyApplicationFrameworkApi.Application.DTOs;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ServiceHelper
    {
        private static IDictionary<Type, IDictionary<string, ChannelFactory>> channelFactories = new Dictionary<Type, IDictionary<string, ChannelFactory>>();
        private static object _lock = new object();

        public static TResponse Invoke<TService, TResponse>(Func<TService, TResponse> expression, string endpoint)
        {
            TResponse response;
            var channel = typeof(TService);
            lock (_lock)
            {
                if (!channelFactories.ContainsKey(channel))
                {
                    channelFactories.Add(channel, new Dictionary<string, ChannelFactory>());
                }
                if (!channelFactories[channel].ContainsKey(endpoint))
                {
                    var newChannelFactory = new ChannelFactory<TService>(endpoint);
                    channelFactories[channel].Add(endpoint, newChannelFactory);
                }
            }

            var channelFactory = (ChannelFactory<TService>)channelFactories[channel][endpoint];
            var proxy = (IClientChannel)channelFactory.CreateChannel();
            try
            {
                response = expression((TService)proxy);
                proxy.Close();

                if (!Equals(response, default(TResponse)))
                {
                    var type = response.GetType();
                    var messageProperty = type.GetProperty("Message");
                    var severityProperty = type.GetProperty("MessageSeverity");

                    if (messageProperty != null)
                    {
                        ApplicationStrategy.Instance.ContextData.Message = (string)messageProperty.GetValue(response, null);
                    }
                    if (severityProperty != null)
                    {
                        ApplicationStrategy.Instance.ContextData.MessageSeverity = (MessageSeverity)severityProperty.GetValue(response, null);
                    }
                }
            }
            catch (FaultException fault)
            {
                response = default(TResponse);
                proxy.Abort();
                ApplicationStrategy.Instance.ContextData.Message = (string.IsNullOrEmpty(fault.Message) ? ConstantResources.ErrorMessage_UnknownErrorText : fault.Message);
                ApplicationStrategy.Instance.ContextData.MessageSeverity = MessageSeverity.Error;
            }
            catch(Exception ex)
            {
                response = default(TResponse);
                proxy.Abort();
                ApplicationStrategy.Instance.ContextData.Message = (string.IsNullOrEmpty(ex.Message) ? ConstantResources.ErrorMessage_UnknownErrorText : ex.Message);
                ApplicationStrategy.Instance.ContextData.MessageSeverity = ex.GetType() == typeof(TimeoutException) ? MessageSeverity.Warning : MessageSeverity.Error;
            }

            return response;
        }

    }
}
