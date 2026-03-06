using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Describes the states of a Delete model view
    /// </summary>
    public enum DeleteModelState
    {
        AreYouSure = 0, // display confirmation
        Confirmed = 1, // user has confirmed
        Deleted = 2, // deleted
        CannotDelete = 10 // couldn't delete
    }
}
