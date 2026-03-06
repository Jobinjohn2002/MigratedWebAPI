using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum BatchCycleTypeIdentifier
    {
        [EnumMember]
        [Description("134 Std Dry")]
        StdDry134 = 1,

        [EnumMember]
        [Description("134 Extra Dry")]
        ExtraDry134 = 10, 

        [EnumMember]
        [Description("121 Std Dry")]
        StdDry121 = 9,

        [EnumMember]
        [Description("121 Extra Dry")]
        ExtraDry121 = 11,

        [EnumMember]
        [Description("121 Other")]
        Other121 = 17,

        [EnumMember]
        [Description("134 Other")]
        Other134 = 16,

        [EnumMember]
        [Description("134 Bowie Dick")]
        BowieDick134 = 7,

        [EnumMember]
        [Description("121 Bowie Dick")]
        BowieDick121 = 12,

        [EnumMember]
        [Description("Warm Up")]
        WarmUp = 6,

        [EnumMember]
        [Description("AER Standard")]
        AERStandard = 500,

        [EnumMember]
        [Description("AER Disinfection")]
        AERDisinfection = 501,

        [EnumMember]
        [Description("AER Test")]
        AERTest = 502
    }

    public static class EnumerationHelper
    {
        /// <summary>
        /// GetDescription operation
        /// </summary>
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }

    }

}
