using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ComponentNoteData
    /// </summary>
    public class ComponentNoteData
    {
        #region Implementation of IComponentNoteData
        public int ContainerContentId
        {
            get; set;
        }
        public int Position
        {
            get;
            set;
        }
        public bool ComponentListPrint
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentNoteId
        /// </summary>
        public int ContainerContentNoteId { get; set; }
        #endregion
    }
}
