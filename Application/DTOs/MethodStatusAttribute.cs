using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Method State enum.
    /// </summary>
    public enum MethodState
    {
        /// <summary>
        /// It's coming soon, but we're giving you visibility of the documenation.
        /// </summary>
        [Description("Coming Soon")]
        ComingSoon = 0,
        /// <summary>
        /// It's in alpha state, you can have a go, but we're still evolving how this is going to work and is subject to change without notice.
        /// </summary>
        [Description("Alpha Testing")]
        Alpha = 1,
        /// <summary>
        /// It's in beta, we're not planning on making any changes to it's behaviour, but there may be a few issues we still need to iron out.
        /// </summary>
        [Description("Beta Testing")]
        Beta = 2,
        /// <summary>
        /// It's released and good to go.
        /// </summary>
        [Description("Fully Implemented")]
        Release = 3
    }

    /// <summary>
    /// Indicates that a HttpStatusCode and Message can be returned.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    /// <summary>
    /// MethodStatusAttribute
    /// </summary>
    public class MethodStatusAttribute : Attribute
    {
        /// <summary>
        /// The state of the method.
        /// </summary>
        /// <summary>
        /// Gets or sets State
        /// </summary>
        public MethodState State { get; set; }
    }
}