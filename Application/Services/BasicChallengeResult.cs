using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Basic Challenge Result.
    /// </summary>
    /// <summary>
    /// BasicChallengeResult
    /// </summary>
    public class BasicChallengeResult
    {
        public const string AuthenticationScheme = "Basic";
        public const string Realm = "SynergyTrak";

        private readonly IHttpActionResult _action;

        /// <summary>
        /// Initialises an instance of the BasicChallengeResult.
        /// </summary>
        /// <param name="action">The calling action.</param>
        public BasicChallengeResult(IHttpActionResult action)
        {
            _action = action;
        }

        /// <summary>
        /// Returns a challenge result for authentication.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation.</param>
        /// <returns>A task to return the challenge result.</returns>
        /// <summary>
        /// ExecuteAsync operation
        /// </summary>
        public async Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            var response = await _action.ExecuteAsync(cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(AuthenticationScheme, @"realm=""{0}""".FormatWith(Realm)));

            return response;
        }
    }
}