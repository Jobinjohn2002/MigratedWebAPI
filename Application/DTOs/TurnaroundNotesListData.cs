using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundNotesListData
    /// </summary>
    public class TurnaroundNotesListData
    {
        public TurnaroundNotesListData()
        { }

        public TurnaroundNotesListData(ITurnaroundNotesList data)
        {
            TurnAroundNoteId = data.TurnAroundNoteId;
            Text = data.Text;
            Created = data.Created;
            CreatedUser = data.CreatedUser;
            CreatedUserUid = data.CreatedUserUid;
            EndDate = data.EndDate;
        }

        public TurnaroundNotesListData(int noteUid, string text, DateTime created, int createdUserUid, string createdUser, DateTime? endDate=null)
        {
            TurnAroundNoteId = noteUid;
            Text = text;
            Created = created;
            CreatedUser = createdUser;
            CreatedUserUid = createdUserUid;
            EndDate = endDate;
        }
        /// <summary>
        /// Gets or sets TurnAroundNoteId
        /// </summary>
        public int TurnAroundNoteId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserUid
        /// </summary>
        public int CreatedUserUid { get; set; }
        /// <summary>
        /// Gets or sets CreatedUser
        /// </summary>
        public string CreatedUser { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
