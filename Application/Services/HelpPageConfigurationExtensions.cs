using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Globalization;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class HelpPageConfigurationExtensions
    {
        private const string ApiModelPrefix = "MS_HelpPageApiModel_";

        /// <summary>
        /// Sets the documentation provider for help page.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="documentationProvider">The documentation provider.</param>
        /// <summary>
        /// SetDocumentationProvider operation
        /// </summary>
        public static void SetDocumentationProvider(this HttpConfiguration config, IDocumentationProvider documentationProvider)
        {
            config.Services.Replace(typeof(IDocumentationProvider), documentationProvider);
        }

        /// <summary>
        /// Sets the objects that will be used by the formatters to produce sample requests/responses.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sampleObjects">The sample objects.</param>
        /// <summary>
        /// SetSampleObjects operation
        /// </summary>
        public static void SetSampleObjects(this HttpConfiguration config, IDictionary<Type, object> sampleObjects)
        {
            config.GetHelpPageSampleGenerator().SampleObjects = sampleObjects;
        }

        /// <summary>
        /// Sets the sample request directly for the specified media type and action.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample request.</param>
        /// <param name="mediaType">The media type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <summary>
        /// SetSampleRequest operation
        /// </summary>
        public static void SetSampleRequest(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType, string controllerName, string actionName)
        {
            config.GetHelpPageSampleGenerator().ActionSamples.Add(new HelpPageSampleKey(mediaType, SampleDirection.Request, controllerName, actionName, new[] { "*" }), sample);
        }

        /// <summary>
        /// Sets the sample request directly for the specified media type and action with parameters.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample request.</param>
        /// <param name="mediaType">The media type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameterNames">The parameter names.</param>
        /// <summary>
        /// SetSampleRequest operation
        /// </summary>
        public static void SetSampleRequest(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType, string controllerName, string actionName, params string[] parameterNames)
        {
            config.GetHelpPageSampleGenerator().ActionSamples.Add(new HelpPageSampleKey(mediaType, SampleDirection.Request, controllerName, actionName, parameterNames), sample);
        }

        /// <summary>
        /// Sets the sample request directly for the specified media type of the action.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample response.</param>
        /// <param name="mediaType">The media type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <summary>
        /// SetSampleResponse operation
        /// </summary>
        public static void SetSampleResponse(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType, string controllerName, string actionName)
        {
            config.GetHelpPageSampleGenerator().ActionSamples.Add(new HelpPageSampleKey(mediaType, SampleDirection.Response, controllerName, actionName, new[] { "*" }), sample);
        }

        /// <summary>
        /// Sets the sample response directly for the specified media type of the action with specific parameters.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample response.</param>
        /// <param name="mediaType">The media type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameterNames">The parameter names.</param>
        /// <summary>
        /// SetSampleResponse operation
        /// </summary>
        public static void SetSampleResponse(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType, string controllerName, string actionName, params string[] parameterNames)
        {
            config.GetHelpPageSampleGenerator().ActionSamples.Add(new HelpPageSampleKey(mediaType, SampleDirection.Response, controllerName, actionName, parameterNames), sample);
        }

        /// <summary>
        /// Sets the sample directly for all actions with the specified media type.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample.</param>
        /// <param name="mediaType">The media type.</param>
        /// <summary>
        /// SetSampleForMediaType operation
        /// </summary>
        public static void SetSampleForMediaType(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType)
        {
            config.GetHelpPageSampleGenerator().ActionSamples.Add(new HelpPageSampleKey(mediaType), sample);
        }

        /// <summary>
        /// Sets the sample directly for all actions with the specified type and media type.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample.</param>
        /// <param name="mediaType">The media type.</param>
        /// <param name="type">The parameter type or return type of an action.</param>
        /// <summary>
        /// SetSampleForType operation
        /// </summary>
        public static void SetSampleForType(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType, Type type)
        {
            config.GetHelpPageSampleGenerator().ActionSamples.Add(new HelpPageSampleKey(mediaType, type), sample);
        }

        /// <summary>
        /// Specifies the actual type of <see cref="System.Net.Http.ObjectContent{T}"/> passed to the <see cref="System.Net.Http.HttpRequestMessage"/> in an action.
        /// The help page will use this information to produce more accurate request samples.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="type">The type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <summary>
        /// SetActualRequestType operation
        /// </summary>
        public static void SetActualRequestType(this HttpConfiguration config, Type type, string controllerName, string actionName)
        {
            config.GetHelpPageSampleGenerator().ActualHttpMessageTypes.Add(new HelpPageSampleKey(SampleDirection.Request, controllerName, actionName, new[] { "*" }), type);
        }

        /// <summary>
        /// Specifies the actual type of <see cref="System.Net.Http.ObjectContent{T}"/> passed to the <see cref="System.Net.Http.HttpRequestMessage"/> in an action.
        /// The help page will use this information to produce more accurate request samples.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="type">The type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameterNames">The parameter names.</param>
        /// <summary>
        /// SetActualRequestType operation
        /// </summary>
        public static void SetActualRequestType(this HttpConfiguration config, Type type, string controllerName, string actionName, params string[] parameterNames)
        {
            config.GetHelpPageSampleGenerator().ActualHttpMessageTypes.Add(new HelpPageSampleKey(SampleDirection.Request, controllerName, actionName, parameterNames), type);
        }

        /// <summary>
        /// Specifies the actual type of <see cref="System.Net.Http.ObjectContent{T}"/> returned as part of the <see cref="System.Net.Http.HttpRequestMessage"/> in an action.
        /// The help page will use this information to produce more accurate response samples.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="type">The type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <summary>
        /// SetActualResponseType operation
        /// </summary>
        public static void SetActualResponseType(this HttpConfiguration config, Type type, string controllerName, string actionName)
        {
            config.GetHelpPageSampleGenerator().ActualHttpMessageTypes.Add(new HelpPageSampleKey(SampleDirection.Response, controllerName, actionName, new[] { "*" }), type);
        }

        /// <summary>
        /// Specifies the actual type of <see cref="System.Net.Http.ObjectContent{T}"/> returned as part of the <see cref="System.Net.Http.HttpRequestMessage"/> in an action.
        /// The help page will use this information to produce more accurate response samples.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="type">The type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameterNames">The parameter names.</param>
        /// <summary>
        /// SetActualResponseType operation
        /// </summary>
        public static void SetActualResponseType(this HttpConfiguration config, Type type, string controllerName, string actionName, params string[] parameterNames)
        {
            config.GetHelpPageSampleGenerator().ActualHttpMessageTypes.Add(new HelpPageSampleKey(SampleDirection.Response, controllerName, actionName, parameterNames), type);
        }

        /// <summary>
        /// Gets the help page sample generator.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <returns>The help page sample generator.</returns>
        /// <summary>
        /// GetHelpPageSampleGenerator operation
        /// </summary>
        public static HelpPageSampleGenerator GetHelpPageSampleGenerator(this HttpConfiguration config)
        {
            return (HelpPageSampleGenerator)config.Properties.GetOrAdd(
                typeof(HelpPageSampleGenerator),
                k => new HelpPageSampleGenerator());
        }

        /// <summary>
        /// Sets the help page sample generator.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sampleGenerator">The help page sample generator.</param>
        /// <summary>
        /// SetHelpPageSampleGenerator operation
        /// </summary>
        public static void SetHelpPageSampleGenerator(this HttpConfiguration config, HelpPageSampleGenerator sampleGenerator)
        {
            config.Properties.AddOrUpdate(
                typeof(HelpPageSampleGenerator),
                k => sampleGenerator,
                (k, o) => sampleGenerator);
        }

        /// <summary>
        /// Gets the model description generator.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>The <see cref="ModelDescriptionGenerator"/></returns>
        /// <summary>
        /// GetModelDescriptionGenerator operation
        /// </summary>
        public static ModelDescriptionGenerator GetModelDescriptionGenerator(this HttpConfiguration config)
        {
            return (ModelDescriptionGenerator)config.Properties.GetOrAdd(
                typeof(ModelDescriptionGenerator),
                k => InitializeModelDescriptionGenerator(config));
        }

        /// <summary>
        /// Gets the model that represents an API displayed on the help page. The model is initialized on the first call and cached for subsequent calls.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="apiDescriptionId">The <see cref="ApiDescription"/> ID.</param>
        /// <returns>
        /// An <see cref="HelpPageApiModel"/>
        /// </returns>
        /// <summary>
        /// GetHelpPageApiModel operation
        /// </summary>
        public static HelpPageApiModel GetHelpPageApiModel(this HttpConfiguration config, string apiDescriptionId)
        {
            object model;
            string modelId = ApiModelPrefix + apiDescriptionId;
            if (!config.Properties.TryGetValue(modelId, out model))
            {
                Collection<ApiDescription> apiDescriptions = config.Services.GetApiExplorer().ApiDescriptions;
                ApiDescription apiDescription = apiDescriptions.FirstOrDefault(api => String.Equals(api.GetFriendlyId(), apiDescriptionId, StringComparison.OrdinalIgnoreCase));
                if (apiDescription != null)
                {
                    model = GenerateApiModel(apiDescription, config);
                    config.Properties.TryAdd(modelId, model);
                }
            }

            return (HelpPageApiModel)model;
        }

        private static HelpPageApiModel GenerateApiModel(ApiDescription apiDescription, HttpConfiguration config)
        {
            HelpPageApiModel apiModel = new HelpPageApiModel()
            {
                ApiDescription = apiDescription,
            };

            ModelDescriptionGenerator modelGenerator = config.GetModelDescriptionGenerator();
            HelpPageSampleGenerator sampleGenerator = config.GetHelpPageSampleGenerator();
            GenerateUriParameters(apiModel, modelGenerator);
            GenerateActionDetails(apiModel);
            GenerateRequestModelDescription(apiModel, modelGenerator, sampleGenerator);
            GenerateResourceDescription(apiModel, modelGenerator);
            GenerateSamples(apiModel, sampleGenerator);

            return apiModel;
        }

        private static void GenerateUriParameters(HelpPageApiModel apiModel, ModelDescriptionGenerator modelGenerator)
        {
            ApiDescription apiDescription = apiModel.ApiDescription;
            foreach (ApiParameterDescription apiParameter in apiDescription.ParameterDescriptions)
            {
                if (apiParameter.Source == ApiParameterSource.FromUri)
                {
                    HttpParameterDescriptor parameterDescriptor = apiParameter.ParameterDescriptor;
                    Type parameterType = null;
                    ModelDescription typeDescription = null;
                    ComplexTypeModelDescription complexTypeDescription = null;
                    if (parameterDescriptor != null)
                    {
                        parameterType = parameterDescriptor.ParameterType;
                        typeDescription = modelGenerator.GetOrCreateModelDescription(parameterType);
                        complexTypeDescription = typeDescription as ComplexTypeModelDescription;
                    }
                    if (complexTypeDescription != null
                        && !IsBindableWithTypeConverter(parameterType))
                    {
                        foreach (ParameterDescription uriParameter in complexTypeDescription.Properties)
                        {
                            apiModel.UriParameters.Add(uriParameter);
                        }
                    }
                    else if (parameterDescriptor != null)
                    {
                        ParameterDescription uriParameter =
                            AddParameterDescription(apiModel, apiParameter, typeDescription);

                        if (!parameterDescriptor.IsOptional)
                        {
                            uriParameter.Annotations.Add(new ParameterAnnotation() { Documentation = "Required" });
                        }

                        object defaultValue = parameterDescriptor.DefaultValue;
                        if (defaultValue != null)
                        {
                            uriParameter.Annotations.Add(new ParameterAnnotation() { Documentation = "Default value is " + Convert.ToString(defaultValue, CultureInfo.InvariantCulture) });
                        }
                    }
                    else
                    {
                        Debug.Assert(parameterDescriptor == null);
                        ModelDescription modelDescription = modelGenerator.GetOrCreateModelDescription(typeof(string));
                        AddParameterDescription(apiModel, apiParameter, modelDescription);
                    }
                }
            }
        }

        private static bool IsBindableWithTypeConverter(Type parameterType)
        {
            if (parameterType == null)
            {
                return false;
            }

            return TypeDescriptor.GetConverter(parameterType).CanConvertFrom(typeof(string));
        }

        private static ParameterDescription AddParameterDescription(HelpPageApiModel apiModel,
            ApiParameterDescription apiParameter, ModelDescription typeDescription)
        {
            ParameterDescription parameterDescription = new ParameterDescription
            {
                Name = apiParameter.Name,
                Documentation = apiParameter.Documentation,
                TypeDescription = typeDescription,
            };

            apiModel.UriParameters.Add(parameterDescription);
            return parameterDescription;
        }

        private static void GenerateActionDetails(HelpPageApiModel apiModel)
        {
            var permissionAttributes = apiModel.ApiDescription.ActionDescriptor.GetCustomAttributes<SynergyTrakAuthenticationAttribute>(false);

            if (permissionAttributes != null && permissionAttributes.Any())
            {
                permissionAttributes.ToList().ForEach(a =>
                {
                    apiModel.AuthenticationFilters.Add(a);

                    if (a.Permissions != null && a.Permissions.Any())
                    {
                        apiModel.UriPermissions.AddRange(a.Permissions);
                    }
                });
            }

            var httpResultAttributes = apiModel.ApiDescription.ActionDescriptor.GetCustomAttributes<HttpResultAttribute>(false).ToList();

            if (apiModel.ApiDescription.ActionDescriptor.GetCustomAttributes<BadRequestOnModelInvalidAttribute>(false).Count > 0)
                httpResultAttributes.Add(new HttpResultAttribute { Code = HttpStatusCode.BadRequest, Message = Services.Constants.General.Errors.InvalidBody });

            apiModel.HttpResults = httpResultAttributes;

            apiModel.HttpHeaders = apiModel.ApiDescription.ActionDescriptor.GetCustomAttributes<HttpHeaderAttribute>(false).ToList();

            apiModel.MethodStatus =
                apiModel.ApiDescription.ActionDescriptor.GetCustomAttributes<MethodStatusAttribute>(true)
                    .SingleOrDefault();
        }

        private static void GenerateRequestModelDescription(HelpPageApiModel apiModel, ModelDescriptionGenerator modelGenerator, HelpPageSampleGenerator sampleGenerator)
        {
            ApiDescription apiDescription = apiModel.ApiDescription;
            foreach (ApiParameterDescription apiParameter in apiDescription.ParameterDescriptions)
            {
                if (apiParameter.Source == ApiParameterSource.FromBody)
                {
                    Type parameterType = apiParameter.ParameterDescriptor.ParameterType;
                    apiModel.RequestModelDescription = modelGenerator.GetOrCreateModelDescription(parameterType);
                    apiModel.RequestDocumentation = apiParameter.Documentation;
                }
                else if (apiParameter.ParameterDescriptor != null &&
                    apiParameter.ParameterDescriptor.ParameterType == typeof(HttpRequestMessage))
                {
                    Type parameterType = sampleGenerator.ResolveHttpRequestMessageType(apiDescription);

                    if (parameterType != null)
                    {
                        apiModel.RequestModelDescription = modelGenerator.GetOrCreateModelDescription(parameterType);
                    }
                }
            }
        }

        private static void GenerateResourceDescription(HelpPageApiModel apiModel, ModelDescriptionGenerator modelGenerator)
        {
            ResponseDescription response = apiModel.ApiDescription.ResponseDescription;
            Type responseType = response.ResponseType ?? response.DeclaredType;
            if (responseType != null && responseType != typeof(void))
            {
                apiModel.ResourceDescription = modelGenerator.GetOrCreateModelDescription(responseType);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "The exception is recorded as ErrorMessages.")]
        private static void GenerateSamples(HelpPageApiModel apiModel, HelpPageSampleGenerator sampleGenerator)
        {
            try
            {
                foreach (var item in sampleGenerator.GetSampleRequests(apiModel.ApiDescription))
                {
                    apiModel.SampleRequests.Add(item.Key, item.Value);
                    LogInvalidSampleAsError(apiModel, item.Value);
                }

                foreach (var item in sampleGenerator.GetSampleResponses(apiModel.ApiDescription))
                {
                    apiModel.SampleResponses.Add(item.Key, item.Value);
                    LogInvalidSampleAsError(apiModel, item.Value);
                }
            }
            catch (Exception e)
            {
                apiModel.ErrorMessages.Add(String.Format(CultureInfo.CurrentCulture,
                    "An exception has occurred while generating the sample. Exception message: {0}",
                    HelpPageSampleGenerator.UnwrapException(e).Message));
            }
        }

        private static bool TryGetResourceParameter(ApiDescription apiDescription, HttpConfiguration config, out ApiParameterDescription parameterDescription, out Type resourceType)
        {
            parameterDescription = apiDescription.ParameterDescriptions.FirstOrDefault(
                p => p.Source == ApiParameterSource.FromBody ||
                    (p.ParameterDescriptor != null && p.ParameterDescriptor.ParameterType == typeof(HttpRequestMessage)));

            if (parameterDescription == null)
            {
                resourceType = null;
                return false;
            }

            resourceType = parameterDescription.ParameterDescriptor.ParameterType;

            if (resourceType == typeof(HttpRequestMessage))
            {
                HelpPageSampleGenerator sampleGenerator = config.GetHelpPageSampleGenerator();
                resourceType = sampleGenerator.ResolveHttpRequestMessageType(apiDescription);
            }

            if (resourceType == null)
            {
                parameterDescription = null;
                return false;
            }

            return true;
        }

        private static bool TryGetResourceResponse(ApiDescription apiDescription, out ResponseDescription responseDescription, out Type resourceType)
        {
            responseDescription = apiDescription.ResponseDescription;

            if (responseDescription == null)
            {
                resourceType = null;
                return false;
            }

            resourceType = responseDescription.ResponseType;

            if (resourceType == null)
            {
                responseDescription = null;
                return false;
            }

            return true;
        }

        private static ModelDescriptionGenerator InitializeModelDescriptionGenerator(HttpConfiguration config)
        {
            ModelDescriptionGenerator modelGenerator = new ModelDescriptionGenerator(config);
            Collection<ApiDescription> apis = config.Services.GetApiExplorer().ApiDescriptions;
            foreach (ApiDescription api in apis)
            {
                ApiParameterDescription parameterDescription;
                Type parameterType;
                if (TryGetResourceParameter(api, config, out parameterDescription, out parameterType))
                {
                    modelGenerator.GetOrCreateModelDescription(parameterType);
                }

                ResponseDescription responseDescription;
                if (TryGetResourceResponse(api, out responseDescription, out parameterType))
                {
                    modelGenerator.GetOrCreateModelDescription(parameterType);
                }
            }
            return modelGenerator;
        }

        private static void LogInvalidSampleAsError(HelpPageApiModel apiModel, object sample)
        {
            InvalidSample invalidSample = sample as InvalidSample;
            if (invalidSample != null)
            {
                apiModel.ErrorMessages.Add(invalidSample.ErrorMessage);
            }
        }
    }

    public interface IDocumentationProvider
    {
        string GetDocumentation(ApiDescription apiDescription);
        string GetDocumentation(ControllerDescriptor controllerDescriptor);
        string GetDocumentation(ParameterDescriptor parameterDescriptor);
    }

    public class HttpConfiguration
    {
        public ServicesContainer Services { get; set; } = new ServicesContainer();
        public IDictionary<object, object> Properties { get; set; } = new Dictionary<object, object>();

        public class ServicesContainer
        {
            private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

            public void Replace(Type serviceType, object service)
            {
                _services[serviceType] = service;
            }

            public T GetService<T>() where T : class
            {
                return _services.TryGetValue(typeof(T), out var service) ? (T)service : null;
            }

            public IApiExplorer GetApiExplorer()
            {
                return _services.TryGetValue(typeof(IApiExplorer), out var service) ? (IApiExplorer)service : new DefaultApiExplorer();
            }
        }

        public class DefaultApiExplorer : IApiExplorer
        {
            public Collection<ApiDescription> ApiDescriptions { get; set; } = new Collection<ApiDescription>();
        }
    }

    public class ApiDescription
    {
        public List<ApiParameterDescription> ParameterDescriptions { get; set; } = new List<ApiParameterDescription>();
        public ResponseDescription ResponseDescription { get; set; } = new ResponseDescription();
        public ControllerActionDescriptor ActionDescriptor { get; set; } = new ControllerActionDescriptor();

        public string GetFriendlyId()
        {
            return ActionDescriptor.ActionName;
        }
    }

    public class ApiParameterDescription
    {
        public ApiParameterSource Source { get; set; }
        public string Name { get; set; }
        public string Documentation { get; set; }
        public HttpParameterDescriptor ParameterDescriptor { get; set; }
    }

    public enum ApiParameterSource
    {
        Unknown,
        FromUri,
        FromBody,
        FromHeader
    }

    public class ResponseDescription
    {
        public Type ResponseType { get; set; }
        public Type DeclaredType { get; set; }
    }

    public class HttpParameterDescriptor
    {
        public Type ParameterType { get; set; }
        public object DefaultValue { get; set; }
        public bool IsOptional { get; set; }
    }

    public class ControllerActionDescriptor
    {
        public string ActionName { get; set; }
        public List<T> GetCustomAttributes<T>(bool inherit) where T : Attribute
        {
            return new List<T>();
        }
    }

    public class HelpPageApiModel
    {
        public ApiDescription ApiDescription { get; set; }
        public ModelDescription RequestModelDescription { get; set; }
        public ModelDescription ResourceDescription { get; set; }
        public string RequestDocumentation { get; set; }
        public List<ParameterDescription> UriParameters { get; set; } = new List<ParameterDescription>();
        public List<SynergyTrakAuthenticationAttribute> AuthenticationFilters { get; set; } = new List<SynergyTrakAuthenticationAttribute>();
        public List<string> UriPermissions { get; set; } = new List<string>();
        public List<HttpResultAttribute> HttpResults { get; set; } = new List<HttpResultAttribute>();
        public List<HttpHeaderAttribute> HttpHeaders { get; set; } = new List<HttpHeaderAttribute>();
        public MethodStatusAttribute MethodStatus { get; set; }
        public Dictionary<MediaTypeHeaderValue, object> SampleRequests { get; set; } = new Dictionary<MediaTypeHeaderValue, object>();
        public Dictionary<MediaTypeHeaderValue, object> SampleResponses { get; set; } = new Dictionary<MediaTypeHeaderValue, object>();
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }

    public class ModelDescriptionGenerator
    {
        private readonly HttpConfiguration _config;

        public ModelDescriptionGenerator(HttpConfiguration config)
        {
            _config = config;
        }

        public ModelDescription GetOrCreateModelDescription(Type type)
        {
            return new ModelDescription();
        }
    }

    public class ModelDescription
    {
    }

    public class ComplexTypeModelDescription : ModelDescription
    {
        public List<ParameterDescription> Properties { get; set; } = new List<ParameterDescription>();
    }

    public class ParameterDescription
    {
        public string Name { get; set; }
        public string Documentation { get; set; }
        public ModelDescription TypeDescription { get; set; }
        public List<ParameterAnnotation> Annotations { get; set; } = new List<ParameterAnnotation>();
    }

    public class ParameterAnnotation
    {
        public string Documentation { get; set; }
    }

    public class HelpPageSampleGenerator
    {
        public IDictionary<Type, object> SampleObjects { get; set; } = new Dictionary<Type, object>();
        public IDictionary<HelpPageSampleKey, object> ActionSamples { get; set; } = new Dictionary<HelpPageSampleKey, object>();
        public IDictionary<HelpPageSampleKey, Type> ActualHttpMessageTypes { get; set; } = new Dictionary<HelpPageSampleKey, Type>();

        public IEnumerable<KeyValuePair<MediaTypeHeaderValue, object>> GetSampleRequests(ApiDescription apiDescription)
        {
            return new List<KeyValuePair<MediaTypeHeaderValue, object>>();
        }

        public IEnumerable<KeyValuePair<MediaTypeHeaderValue, object>> GetSampleResponses(ApiDescription apiDescription)
        {
            return new List<KeyValuePair<MediaTypeHeaderValue, object>>();
        }

        public Type ResolveHttpRequestMessageType(ApiDescription apiDescription)
        {
            return null;
        }

        public static Exception UnwrapException(Exception e)
        {
            return e;
        }
    }

    public class HelpPageSampleKey
    {
        public HelpPageSampleKey(MediaTypeHeaderValue mediaType)
        {
        }

        public HelpPageSampleKey(MediaTypeHeaderValue mediaType, Type type)
        {
        }

        public HelpPageSampleKey(MediaTypeHeaderValue mediaType, SampleDirection direction, string controllerName, string actionName, string[] parameterNames)
        {
        }
    }

    public enum SampleDirection
    {
        Request,
        Response
    }

    public class InvalidSample
    {
        public string ErrorMessage { get; set; }
    }

    public class SynergyTrakAuthenticationAttribute : Attribute
    {
        public string[] Permissions { get; set; }
    }

    public class HttpResultAttribute : Attribute
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
    }

    public class HttpHeaderAttribute : Attribute
    {
    }

    public class MethodStatusAttribute : Attribute
    {
    }

    public class BadRequestOnModelInvalidAttribute : Attribute
    {
    }
}