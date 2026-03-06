using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public static class EnumExtensions
    {
        /// <summary>
        /// GetBGDisplayColor operation
        /// </summary>
        public static string GetBGDisplayColor(this Enum e)
        {
            return e.GetType()
                    .GetMember(e.ToString())
                    .First()
                    .GetCustomAttribute<DisplayColorAttribute>()?
                    .DisplayColor;
        }

        /// <summary>
        /// GetTextDisplayColor operation
        /// </summary>
        public static string GetTextDisplayColor(this Enum e)
        {
            return e.GetType()
                    .GetMember(e.ToString())
                    .First()
                    .GetCustomAttribute<TextDisplayColor>()?
                    .Color;
        }

        /// <summary>
        /// GetDescription operation
        /// </summary>
        public static string GetDescription(this Enum e)
        {
            return e.GetType()
                    .GetMember(e.ToString())
                    .First()
                    .GetCustomAttribute<DescriptionAttribute>()?
                    .Description;
        }

        /// <summary>
        /// GetTooltip operation
        /// </summary>
        public static string GetTooltip(this Enum e)
        {
            return e.GetType()
                    .GetMember(e.ToString())
                    .First()
                    .GetCustomAttribute<TooltipAttribute>()?
                    .Tooltip;
        }
    }
}
