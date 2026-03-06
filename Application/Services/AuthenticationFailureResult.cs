using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Authentication Failure Result.
    /// </summary>
    /// <summary>
    /// AuthenticationFailureResult
    /// </summary>
    public class AuthenticationFailureResult
    {
        /// <summary>
        /// Initialises an instance of the AuthenticationFailureResult.
        /// </summary>
        public AuthenticationFailureResult()
        {
            StatusCode = HttpStatusCode.Unauthorized;
        }

        /// <summary>
        /// Get/Set the authentication failure reason.
        /// </summary>
        /// <summary>
        /// Gets or sets Reason
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Get/Set the original request that triggered this failure.
        /// </summary>
        /// <summary>
        /// Gets or sets Request
        /// </summary>
        public HttpRequestMessage Request { get; set; }

        /// <summary>
        /// Get/Set the http status code.
        /// </summary>
        /// <summary>
        /// Gets or sets StatusCode
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Executes the failure result.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation.</param>
        /// <returns>Returns a task to carry out raising the failure result.</returns>
        /// <summary>
        /// ExecuteAsync operation
        /// </summary>
        public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(StatusCode)
            {
                RequestMessage = Request,
                ReasonPhrase = Reason
            };

            return Task.FromResult(response);
        }
    }
}