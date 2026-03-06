using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityArchived interface
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    /// <summary>
    /// FacilityArchivedData
    /// </summary>
    public class FacilityArchivedData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public FacilityArchivedData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacilityArchivedData"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <remarks></remarks>
        public FacilityArchivedData(FacilityArchivedData data)
        {
            Identifier = data.Identifier;
            Text = data.Text;
            UserId = data.UserId;
            UserName = data.UserName;
            ArchivedDate = data.ArchivedDate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacilityArchivedData"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="text">The text.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="archivedDate">The archived date.</param>
        /// <remarks></remarks>
        public FacilityArchivedData(int identifier, string text, int? userId, string userName, DateTime archivedDate)
        {
            Identifier = identifier;
            Text = text;
            UserId = userId;
            UserName = userName;
            ArchivedDate = archivedDate;
        }

        #region IFacilityArchived Members

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Identifier
        /// </summary>
        public int Identifier { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        /// <remarks></remarks>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the archived date.
        /// </summary>
        /// <value>The archived date.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ArchivedDate
        /// </summary>
        public DateTime ArchivedDate { get; set; }

        #endregion
    }
}