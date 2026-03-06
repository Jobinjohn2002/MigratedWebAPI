using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum DayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6
    }

    public enum SynergyActionType
    {
        LoadPartial,
        LoadFull,
        UpdatePanel,
        SubmitPanel,
        ClosePanel,
        RunClientScript,
        ClearTarget,
        SubmitForm,
        ShowPopup
    }

    public enum LoadMethod
    {
        LazyLoad,
        EagerLoad
    }

    public enum TimePattern
    {
        HourMinute,
        HourMinuteSecond
    }

    public enum DatePattern
    {
        DayMonthYear
    }

    public enum MessageSeverity
    {
        Null,
        Information,
        Warning,
        Error
    }

    public enum EmailAttachmentFormat
    {
        PDF = 0,
        EXCEL = 1,
        CSV = 2,
        XML = 3
    }

    public enum ReportUrlParameters
    {
        ReportParameters,
        ReportName,
        AttachmentFileNames,
        EmailFormat,
        EmailBodyParameters,
        EmailTemplate,
        EmailSubjectParameters,
        ReportFunction,
        IsApplication
    }

    public enum ReportFuntion
    {
        DisplayReport = 0,
        EmailReport = 1,
        SingleUseComonentsReport = 2,
        DeliverableItemsReport = 3,
        PriceCategory = 4
    }
    
    public enum CompareOperator
    {
        EqualTo,
        NotEqualTo,
        GreaterThan,
        GreaterThanEqualTo,
        LessThan,
        LessThanEqualTo,
    }

    public enum SynergyDateTimeDisplayFormat
    {
        ShortDate,
        ShortTime,
        LongTime,
        LongDate,
        ShortDateTime,
        LongDateTime,
        LongDateShortTime
    }

    public enum FormatSource
    {
        Default,
        Facility,
        Customer
    }

    [Flags]
    public enum AccountAuthenticationResult : short
    {
        Unknown = 0,
        Invalid = 1,
        AccessDenied = 2,
        PasswordExpired = 4,
        PinExpired = 8,
        NoFacilities = 16,
        TooManyAttempts = 32,
        PreviousPassword = 64,
        Authentic = 128,
        DeniedBreachedPassword = 256,
        IgnoreBreachedPassword = 512

    }
}
