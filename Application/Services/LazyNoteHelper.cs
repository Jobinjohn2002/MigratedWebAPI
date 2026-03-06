using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// LazyNoteHelper
    /// </summary>
    /// <remarks></remarks>
    public static class LazyNoteHelper
    {
        #region ContainerMasterNotes

        /// <summary>
        /// Converts the container master notes to data.
        /// </summary>
        /// <param name="containerMasterNote">The container master note.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerMasterNotesToData operation
        /// </summary>
        public static ContainerMasterNoteData ConvertContainerMasterNotesToData(ContainerMasterNote containerMasterNote)
        {
            return containerMasterNote == null ? null : new ContainerMasterNoteData(containerMasterNote);
        }

        /// <summary>
        /// Converts the container master notes to container master note data.
        /// </summary>
        /// <param name="containerMasterNotes">The container master notes.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerMasterNotesToContainerMasterNoteData operation
        /// </summary>
        public static IList<ContainerMasterNoteData> ConvertContainerMasterNotesToContainerMasterNoteData(IList<ContainerMasterNote> containerMasterNotes)
        {
            if (containerMasterNotes == null)
            {
                return null;
            }
            IList<ContainerMasterNoteData> containerMasterNoteList = containerMasterNotes.Select(ConvertContainerMasterNotesToData).ToList();
            return containerMasterNoteList;
        }

        #endregion

        #region ProcessingNotes

        /// <summary>
        /// Converts the container master notes to data.
        /// </summary>
        /// <param name="processingNote">The processing note.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertProcessingNotesToData operation
        /// </summary>
        public static ContainerMasterNoteData ConvertProcessingNotesToData(IProcessingNote processingNote)
        {
            return processingNote == null ? null : new ContainerMasterNoteData(processingNote);
        }

        /// <summary>
        /// Converts the container master notes to container master note data.
        /// </summary>
        /// <param name="processingNotes">The container master definition notes.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertProcessingNotesToContainerMasterNoteData operation
        /// </summary>
        public static IList<ContainerMasterNoteData> ConvertProcessingNotesToContainerMasterNoteData(IList<IProcessingNote> processingNotes)
        {
            if (processingNotes == null)
            {
                return null;
            }
            IList<ContainerMasterNoteData> processingNoteList = processingNotes.Select(ConvertProcessingNotesToData).ToList();
            return processingNoteList;
        }

        #endregion

        #region Warnings

        /// <summary>
        /// Converts the warnings to data.
        /// </summary>
        /// <param name="warning">The warning.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertWarningsToData operation
        /// </summary>
        public static WarningData ConvertWarningsToData(Warning warning)
        {
            return warning == null ? null : new WarningData(warning);
        }

        /// <summary>
        /// Converts the warnings to warning data.
        /// </summary>
        /// <param name="warnings">The warnings.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertWarningsToWarningData operation
        /// </summary>
        public static IList<WarningData> ConvertWarningsToWarningData(IList<Warning> warnings)
        {
            if (warnings == null)
            {
                return null;
            }
            IList<WarningData> warningList = warnings.Select(ConvertWarningsToData).ToList();
            return warningList;
        }

        #endregion
    }
}
