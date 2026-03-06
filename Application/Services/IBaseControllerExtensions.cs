using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class IBaseControllerExtensions
    {
        /// <summary>
        /// CanHandleDisplayMode operation
        /// </summary>
        public static bool CanHandleDisplayMode(this IBaseController controller, string displayModeID)
        {
            var mode = DisplayModeProvider.Instance.Modes.FirstOrDefault(m => m.DisplayModeId == displayModeID);

            return mode != null && mode.CanHandleContext(controller.HttpContext);
        }
        /// <summary>
        /// IsIE8 operation
        /// </summary>
        public static bool IsIE8(this IBaseController controller)
        {
            return CanHandleDisplayMode(controller, DisplayModeConfig.Modes.IE8);
        }
        /// <summary>
        /// IsIE9 operation
        /// </summary>
        public static bool IsIE9(this IBaseController controller)
        {
            return CanHandleDisplayMode(controller, DisplayModeConfig.Modes.IE9);
        }

        /// <summary>
        /// IsChrome operation
        /// </summary>
        public static bool IsChrome(this IBaseController controller)
        {
            return CanHandleDisplayMode(controller, DisplayModeConfig.Modes.Chrome);
        }
    }
}