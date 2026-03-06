using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Compound data type for the result set from a get clocking action stored procedure.
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// GetClockingActionsResultData
    /// </summary>
    public class GetClockingActionsResultData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetClockingActionsResultData"/> class.
        /// </summary>
        /// <param name="row">The clocking action data row.</param>
        /// <param name="clockingEventTypeIdentifier">Clocking Event Type Identifier.</param>
        /// <remarks></remarks>
        public GetClockingActionsResultData(DataRow row, ClockingEventTypeIdentifier clockingEventTypeIdentifier)
        {

            ClockingTypeIdentifier = clockingEventTypeIdentifier;
            LocationId = (int)row[1];
            StationId = row[2] == DBNull.Value ? null : (int?) row[2];
            FullPath = (string)row[3];
            IsMandatory = (bool)row[4];
            LocationType = (LocationTypeIdentifier)((byte)row[5]);

        }

        /// <summary>
        /// Gets or sets the clocking type identifier.
        /// </summary>
        /// <value>The clockingTypeIdentifier</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ClockingTypeIdentifier
        /// </summary>
        public ClockingEventTypeIdentifier ClockingTypeIdentifier { get; private set; }

        /// <summary>
        /// Gets or sets the station.
        /// </summary>
        /// <value>The station.</value>
        /// <remarks></remarks>
        public int? StationId { get; private set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; private set; }

        /// <summary>
        /// Gets or sets IsMandatory
        /// </summary>
        public bool IsMandatory { get; private set; }

        /// <summary>
        /// Gets or sets FullPath
        /// </summary>
        public string FullPath { get; private set; }

        /// <summary>
        /// Gets or sets LocationType
        /// </summary>
        public LocationTypeIdentifier LocationType { get; private set; }

    }
}
