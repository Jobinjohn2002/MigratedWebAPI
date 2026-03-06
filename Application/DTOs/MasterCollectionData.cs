using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// MasterCollectionData
    /// </summary>
    public class MasterCollectionData
    {
        public MasterCollectionData(IMasterCollection masterCollection)
        {
            MasterId = masterCollection.MasterId;
            MasterExternalId = masterCollection.MasterExternalId;
            Name = masterCollection.Name;
            ItemSubtypeId = masterCollection.ItemSubtypeId;
            CreatedDate = masterCollection.CreatedDate;
            RequiresSecondCheck = masterCollection.RequiresSecondCheck;
            Revision = masterCollection.Revision;
            SpecialityId = masterCollection.SpecialityId;
            SpecialityName = masterCollection.SpecialityName;
            CategoryId = masterCollection.CategoryId;
            CategoryName = masterCollection.CategoryName;
            CreateUserId = masterCollection.CreateUserId;
            CreateUserName = masterCollection.CreateUserName;
            ItemTypeId = masterCollection.ItemTypeId;
            ItemTypeName = masterCollection.ItemTypeName;
            ComplexityId = masterCollection.ComplexityId;
            ItemStatusId = masterCollection.ItemStatusId;
            ItemStatusName = masterCollection.ItemStatusName;
            ParentItemTypeId = masterCollection.ParentItemTypeId;
            ParentItemTypeName = masterCollection.ParentItemTypeName;
            IPOH = masterCollection.IPOH;
            ManufactureReference = masterCollection.ManufactureReference;
            NumberOfLabels = masterCollection.NumberOfLabels;
            MasterDefinitionId = masterCollection.MasterDefinitionId;
        }
		/// <summary>
		/// Gets or sets MasterExternalId
		/// </summary>
		public string MasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets MasterId
        /// </summary>
        public int MasterId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets ItemSubtypeId
        /// </summary>
        public short ItemSubtypeId { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets RequiresSecondCheck
        /// </summary>
        public bool RequiresSecondCheck { get; set; }
        /// <summary>
        /// Gets or sets Revision
        /// </summary>
        public int Revision { get; set; }
        /// <summary>
        /// Gets or sets SpecialityId
        /// </summary>
        public int SpecialityId { get; set; }
        /// <summary>
        /// Gets or sets SpecialityName
        /// </summary>
        public string SpecialityName { get; set; }
        /// <summary>
        /// Gets or sets CategoryId
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Gets or sets CategoryName
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Gets or sets CreateUserId
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// Gets or sets CreateUserName
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets ComplexityId
        /// </summary>
        public int ComplexityId { get; set; }
        /// <summary>
        /// Gets or sets ItemStatusId
        /// </summary>
        public byte ItemStatusId { get; set; }
        /// <summary>
        /// Gets or sets ItemStatusName
        /// </summary>
        public string ItemStatusName { get; set; }
        public short? ParentItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ParentItemTypeName
        /// </summary>
        public string ParentItemTypeName { get; set; }
        public int? IPOH { get; set; }
        /// <summary>
        /// Gets or sets ManufactureReference
        /// </summary>
        public string ManufactureReference { get; set; }
        public int? NumberOfLabels { get; set; }
        /// <summary>
        /// Gets or sets MasterDefinitionId
        /// </summary>
        public int MasterDefinitionId { get; set; }
    }
}
