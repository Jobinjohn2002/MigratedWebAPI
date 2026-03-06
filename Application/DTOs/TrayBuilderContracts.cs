using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// LineItem
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// Gets or sets BaseType
        /// </summary>
        public string BaseType { get; set; }
        /// <summary>
        /// Gets or sets Catalogue
        /// </summary>
        public string Catalogue { get; set; }
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets ComponentPartCount
        /// </summary>
        public int ComponentPartCount { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentID
        /// </summary>
        public int ContainerContentID { get; set; }
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        /// <summary>
        /// Gets or sets LineType
        /// </summary>
        public string LineType { get; set; }
        /// <summary>
        /// Gets or sets ObjectID
        /// </summary>
        public int ObjectID { get; set; }
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Gets or sets PrintComponentList
        /// </summary>
        public bool PrintComponentList { get; set; }
        /// <summary>
        /// Gets or sets ProductName
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets SubType
        /// </summary>
        public string SubType { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets ManufacturersReference
        /// </summary>
        public string ManufacturersReference { get; set; }
    }
    /// <summary>
    /// ProductSearchResult
    /// </summary>
    public class ProductSearchResult
    {
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
    }
    /// <summary>
    /// SaveSpecificationResult
    /// </summary>
    public class SaveSpecificationResult
    {
        public SaveSpecificationResult()
        {
            ContainerMasterID = 0;
            Success = false;
        }
        /// <summary>
        /// Gets or sets ContainerMasterID
        /// </summary>
        public int ContainerMasterID { get; set; }
        /// <summary>
        /// Gets or sets Exception
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// Gets or sets Success
        /// </summary>
        public bool Success { get; set; }
    }
    /// <summary>
    /// TrayModelData
    /// </summary>
    public class TrayModelData
    {
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionID
        /// </summary>
        public int ContainerMasterDefinitionID { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterID
        /// </summary>
        public int ContainerMasterID { get; set; }
        /// <summary>
        /// Gets or sets CreateInstrumentEnabled
        /// </summary>
        public bool CreateInstrumentEnabled { get; set; }
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        /// <summary>
        /// Gets or sets FacilityID
        /// </summary>
        public short FacilityID { get; set; }
        /// <summary>
        /// Gets or sets FDAEnabled
        /// </summary>
        public bool FDAEnabled { get; set; }
        /// <summary>
        /// Gets or sets FDAComplianceReason
        /// </summary>
        public string FDAComplianceReason { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionTypeID
        /// </summary>
        public short ContainerMasterDefinitionTypeID { get; set; }

    }
    /// <summary>
    /// ItemModelData
    /// </summary>
    public class ItemModelData
    {
        /// <summary>
        /// Gets or sets BaseType
        /// </summary>
        public string BaseType { get; set; }
        /// <summary>
        /// Gets or sets BatchCycleType
        /// </summary>
        public string BatchCycleType { get; set; }
        /// <summary>
        /// Gets or sets BiologicalIndicatorEnabled
        /// </summary>
        public bool BiologicalIndicatorEnabled { get; set; }
        /// <summary>
        /// Gets or sets Catalogue
        /// </summary>
        public string Catalogue { get; set; }
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets Complexity
        /// </summary>
        public string Complexity { get; set; }
        /// <summary>
        /// Gets or sets ComponentPartCount
        /// </summary>
        public short ComponentPartCount { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinitionID
        /// </summary>
        public int ItemMasterDefinitionID { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterID
        /// </summary>
        public int ItemMasterID { get; set; }
        /// <summary>
        /// Gets or sets ManufacturersReference
        /// </summary>
        public string ManufacturersReference { get; set; }
        /// <summary>
        /// Gets or sets ManufacturersName
        /// </summary>
        public string ManufacturersName { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Revision
        /// </summary>
        public int Revision { get; set; }
        /// <summary>
        /// Gets or sets Speciality
        /// </summary>
        public string Speciality { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets SubType
        /// </summary>
        public string SubType { get; set; }

    }
}
