using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Enum values that represent a base type for the creation of an items external ID
    /// </summary>
    /// <remarks>Dan Maunder, 03/10/2012.</remarks>
    public static class BaseTypeIdentifier
    {
        public const string Reusable = "RE";
        public const string SingleUse = "SI";
        public const string Tray = "TR";
        public const string Extra = "EX";
        public const string Supplementary = "SU";
        public const string ProcessTag = "PT";
        public const string AutoclaveCassette = "AC";
        public const string Trolley = "TY";
        public const string Box = "BO";
        public const string Drape = "DR";
        public const string Gown = "GO";
        public const string DrapePack = "DP";
        public const string Container ="CO";
        public const string GownPack = "GP";
        public const string BatchTag = "BT";
        public const string OnLoanTrayTag = "OT";
        public const string Carriage = "CA";
        public const string Identification = "ID";
        public const string LoanTray = "LT";
        public const string SoftPack = "SP";

        /// <summary>
        /// GetIdentifier operation
        /// </summary>
        public static string GetIdentifier(string baseType)
        {
            switch (baseType)
            {
                case "Reusable":
                    return Reusable;
                case "Single Use":
                    return SingleUse;
                case "Tray":
                    return Tray;
                case "Extra":
                    return Extra;
                case "Supplementary":
                    return Supplementary;
                case "Process Tag":
                    return ProcessTag;
                case "Autoclave Cassette":
                    return AutoclaveCassette;
                case "Trolley":
                    return Trolley;
                case "Box":
                    return Box;
                case "Drape":
                    return Drape;
                case "Gown":
                    return Gown;
                case "Drape Pack":
                    return DrapePack;
                case "Container":
                    return Container;
                case "Gown Pack":
                    return GownPack;
                case "Batch Tag":
                    return BatchTag;
                case "On Loan Tray Tag":
                    return OnLoanTrayTag;
                case "Carriage":
                    return Carriage;
                case "Identification":
                    return Identification;
                case "Loan Tray":
                    return LoanTray;
                case "Soft Pack":
                    return SoftPack;
                default:
                    return string.Empty;
            }
        }
    }
}