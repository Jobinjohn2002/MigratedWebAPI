using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// UserTagData
    /// </summary>
    public class UserTagData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public UserTagData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTagData"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="surname"></param>
        /// <param name="externalId">The external id.</param>
        /// <remarks></remarks>
        public UserTagData(string firstName,
                           string surname,
                           string externalId)
        {
            FirstName = firstName;
            Surname = surname;
            ExternalId = externalId;
        }

        #region Properties

        /// <summary>
        /// Gets first name of the user.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the surname of the user.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; private set; }

        /// <summary>
        /// Gets the external id of the user.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; private set; }

        #endregion
    }
}