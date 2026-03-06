using System.Collections.Generic;
using System.Security.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// The model that represents an API displayed on the help page.
    /// </summary>
    /// <summary>
    /// HelpPageApiModel
    /// </summary>
    public class HelpPageApiModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpPageApiModel"/> class.
        /// </summary>
        public HelpPageApiModel()
        {
            UriParameters = new Collection<ParameterDescription>();
            SampleRequests = new Dictionary<MediaTypeHeaderValue, object>();
            SampleResponses = new Dictionary<MediaTypeHeaderValue, object>();
            ErrorMessages = new Collection<string>();

            AuthenticationFilters = new Collection<IAuthenticationFilter>();
            UriPermissions = new List<KnownPermission>();
            HttpResults = new List<HttpResultAttribute>();
        }

        /// <summary>
        /// Gets or sets the <see cref="MethodStatus"/> that describes the status of the API.
        /// </summary>
        /// <summary>
        /// Gets or sets MethodStatus
        /// </summary>
        public MethodStatusAttribute MethodStatus { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ApiDescription"/> that describes the API.
        /// </summary>
        /// <summary>
        /// Gets or sets ApiDescription
        /// </summary>
        public ApiDescription ApiDescription { get; set; }

        /// <summary>
        /// Gets or sets the Permissions required to call this API.
        /// </summary>
        /// <summary>
        /// Gets or sets UriPermissions
        /// </summary>
        public List<KnownPermission> UriPermissions { get; private set; }

        /// <summary>
        /// Gets or sets the Http Status Results for this API.
        /// </summary>
        /// <summary>
        /// Gets or sets HttpResults
        /// </summary>
        public List<HttpResultAttribute> HttpResults { get; set; }

        /// <summary>
        /// Gets or sets the Http Header definitions for the API.
        /// </summary>
        /// <summary>
        /// Gets or sets HttpHeaders
        /// </summary>
        public List<HttpHeaderAttribute> HttpHeaders { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ParameterDescription"/> collection that describes the URI parameters for the API.
        /// </summary>
        /// <summary>
        /// Gets or sets UriParameters
        /// </summary>
        public Collection<ParameterDescription> UriParameters { get; private set; }

        /// <summary>
        /// Gets or sets the authentication filters
        /// </summary>
        /// <summary>
        /// Gets or sets AuthenticationFilters
        /// </summary>
        public Collection<IAuthenticationFilter> AuthenticationFilters { get; private set; }

        /// <summary>
        /// Gets or sets the documentation for the request.
        /// </summary>
        /// <summary>
        /// Gets or sets RequestDocumentation
        /// </summary>
        public string RequestDocumentation { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ModelDescription"/> that describes the request body.
        /// </summary>
        /// <summary>
        /// Gets or sets RequestModelDescription
        /// </summary>
        public ModelDescription RequestModelDescription { get; set; }

        /// <summary>
        /// Gets the request body parameter descriptions.
        /// </summary>
        public IList<ParameterDescription> RequestBodyParameters
        {
            get
            {
                return GetParameterDescriptions(RequestModelDescription);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ModelDescription"/> that describes the resource.
        /// </summary>
        /// <summary>
        /// Gets or sets ResourceDescription
        /// </summary>
        public ModelDescription ResourceDescription { get; set; }

        /// <summary>
        /// Gets the resource property descriptions.
        /// </summary>
        public IList<ParameterDescription> ResourceProperties
        {
            get
            {
                return GetParameterDescriptions(ResourceDescription);
            }
        }

        /// <summary>
        /// Gets the sample requests associated with the API.
        /// </summary>
        /// <summary>
        /// Gets or sets SampleRequests
        /// </summary>
        public IDictionary<MediaTypeHeaderValue, object> SampleRequests { get; private set; }

        /// <summary>
        /// Gets the sample responses associated with the API.
        /// </summary>
        /// <summary>
        /// Gets or sets SampleResponses
        /// </summary>
        public IDictionary<MediaTypeHeaderValue, object> SampleResponses { get; private set; }

        /// <summary>
        /// Gets the error messages associated with this model.
        /// </summary>
        /// <summary>
        /// Gets or sets ErrorMessages
        /// </summary>
        public Collection<string> ErrorMessages { get; private set; }

        private static IList<ParameterDescription> GetParameterDescriptions(ModelDescription modelDescription)
        {
            var complexTypeModelDescription = modelDescription as ComplexTypeModelDescription;
            if (complexTypeModelDescription != null)
            {
                return complexTypeModelDescription.Properties;
            }

            var collectionModelDescription = modelDescription as CollectionModelDescription;
            if (collectionModelDescription != null)
            {
                complexTypeModelDescription = collectionModelDescription.ElementDescription as ComplexTypeModelDescription;
                if (complexTypeModelDescription != null)
                {
                    return complexTypeModelDescription.Properties;
                }
            }

            return null;
        }
    }
}