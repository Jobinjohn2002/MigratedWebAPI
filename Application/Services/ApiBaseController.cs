using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Api Base Controller.
    /// </summary>
    /// <summary>
    /// ApiBaseController
    /// </summary>
    public class ApiBaseController : ApiController
    {
        private const string LogFormat = "[UUID:{0}] [USERID:{1,10}] [INFO:{2}]";

        internal Guid RequestId { get; } = Guid.NewGuid();

        /// <summary>
        /// Get/Set the current authenticated SynergyTrak User.
        /// </summary>
        /// <summary>
        /// Gets or sets SynergyUser
        /// </summary>
        public User SynergyUser { get; set; }

        /// <summary>
        /// Get/Set the full body content of the request.
        /// </summary>
        /// <summary>
        /// Gets or sets RequestContent
        /// </summary>
        public string RequestContent { get; private set; } = string.Empty;

        /// <summary>
        /// Gets an instance of the specified type from the Instance Factory.
        /// </summary>
        /// <typeparam name="T">The type to obtain an instance of.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        public T GetInstance<T>() where T : class
        {
            return InstanceFactory.GetInstance<T>();
        }

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="data">A dictionary containing any error data.</param>
        /// <summary>
        /// Log operation
        /// </summary>
        public void Log(Exception ex, IDictionary<string, object> data = null)
        {
            if (SynergyUser != null)
            {
                if (data == null)
                    data = new Dictionary<string, object>();

                data["UserID"] = SynergyUser.UserId;
                data["RequestID"] = RequestId;
            }

            Kernel.Log(ex, data);
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="level">The message log level.</param>
        /// <summary>
        /// Log operation
        /// </summary>
        public void Log(string message, LogLevel level = LogLevel.Debug)
        {
            Kernel.Log(LogFormat.FormatWith(RequestId, SynergyUser == null ? 0 : SynergyUser.UserId, message), level);
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="method">The method to log.</param>
        /// <summary>
        /// Log operation
        /// </summary>
        public void Log(MethodBase method)
        {
            if (method == null)
                return;

            Kernel.Log(method.DeclaringType == null
                ? LogFormat.FormatWith(RequestId, SynergyUser == null ? 0 : SynergyUser.UserId, "Executing: " + method.Name)
                : LogFormat.FormatWith(RequestId, SynergyUser == null ? 0 : SynergyUser.UserId, "Executing: {0}.{1}".FormatWith(method.DeclaringType.FullName, method.Name)));
        }

        protected virtual void OnRequestStarted()
        {
        }

        protected virtual void OnRequestComplete()
        {
        }

        /// <summary>
        /// Wraps action execution allowing for pre and post action functionality.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <summary>
        /// ExecuteAsync operation
        /// </summary>
        public override async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            try
            {
                var timer = Stopwatch.StartNew();
                HttpResponseMessage response = null;

                OnRequestStarted();
                await base
                    .ExecuteAsync(controllerContext, cancellationToken)
                    .ContinueWith(task =>
                    {
                        timer.Stop();
                        response = task.Result;
                    }, cancellationToken);
                Log("WebApiRequest  [{0}]{1}".FormatWith(controllerContext.Request.Method.Method, controllerContext.Request.RequestUri));
                Log("WebApiResponse [{0}/{1}/{2}ms] {3}".FormatWith(response.StatusCode, (int)response.StatusCode, timer.ElapsedMilliseconds, controllerContext.Request.RequestUri));
                if (response.Headers != null)
                {
                    if (response.Headers.Location != null)
                        Log("Location: {0}".FormatWith(response.Headers.Location.ToString()));

                    response.Headers.Add("X-Synergy-Req", RequestId.ToString());
                }

                OnRequestComplete();

                return response;
            }
            catch (Exception ex)
            {
                Log(ex);

                throw;
            }
        }
    }
}