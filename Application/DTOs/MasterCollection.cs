using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// MasterCollection
    /// </summary>
    public class MasterCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterCollection"/> class.
        /// </summary>
        /// <param name="masterId">The master id.</param>
        /// <param name="masterExternalId">The master external id.</param>
        /// <param name="definitionId">The definitionId.</param>definitionId
        /// <param name="name">The name.</param>
        /// <param name="masterTypeId">The master type id.</param>
        /// <param name="createdDate">The created date.</param>
        /// <param name="requiresSecondCheck">if set to <c>true</c> [requires second check].</param>
        /// <param name="revision">The revision.</param>
        /// <param name="specialityId">The speciality id.</param>
        /// <param name="specialityName">Name of the speciality.</param>
        /// <param name="categoryId">The category id.</param>
        /// <param name="categoryName">Name of the category.</param>
        /// <param name="createUserId">The create user id.</param>
        /// <param name="createUserName">Name of the create user.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <param name="itemTypeName">Name of the item type.</param>
        /// <param name="complexityId">The complexity id.</param>
        /// <param name="itemStatusId">The item status id.</param>
        /// <param name="itemStatusName">Name of the item status.</param>
        /// <param name="parentItemTypeId">The printer type id.</param>
        /// <param name="parentItemTypeName">Name of the printer type.</param>
        /// <param name="ipoh">The ipoh.</param>
        /// <param name="manufactureReference">The manufacture reference.</param>
        /// <param name="numberOfLabels">The number of labels.</param>
        /// <remarks></remarks>
        public MasterCollection(
            int masterId,
            string masterExternalId,
            int definitionId,
            string name,
            short masterTypeId,
            DateTime createdDate,
            bool requiresSecondCheck,
            int revision,
            int specialityId,
            string specialityName,
            int categoryId,
            string categoryName,
            int createUserId,
            string createUserName,
            short itemTypeId,
            string itemTypeName,
            int complexityId,
            byte itemStatusId,
            string itemStatusName,
            short? parentItemTypeId,
            string parentItemTypeName,
            int? ipoh,
            string manufactureReference,
            int? numberOfLabels)
        {
            MasterId = masterId;
            MasterExternalId = masterExternalId;
            MasterDefinitionId = definitionId;
            Name = name;
            ItemSubtypeId = masterTypeId;
            CreatedDate = createdDate;
            RequiresSecondCheck = requiresSecondCheck;
            Revision = revision;
            SpecialityId = specialityId;
            SpecialityName = specialityName;
            CategoryId = categoryId;
            CategoryName = categoryName;
            CreateUserId = createUserId;
            CreateUserName = createUserName;
            ItemTypeId = itemTypeId;
            ItemTypeName = itemTypeName;
            ComplexityId = complexityId;
            ItemStatusId = itemStatusId;
            ItemStatusName = itemStatusName;
            ParentItemTypeId = parentItemTypeId;
            ParentItemTypeName = parentItemTypeName;
            IPOH = ipoh;
            ManufactureReference = manufactureReference;
            NumberOfLabels = numberOfLabels;
        }

        #region IMasterCollection Members

        /// <summary>
        /// Gets or sets the master id.
        /// </summary>
        /// <value>The master id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MasterId
        /// </summary>
        public int MasterId { get; set; }

        /// <summary>
        ///  Gets or sets the master external id.
        /// </summary>
        /// <summary>
        /// Gets or sets MasterExternalId
        /// </summary>
        public string MasterExternalId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the item subtype id.
        /// </summary>
        /// <value>The item subtype id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemSubtypeId
        /// </summary>
        public short ItemSubtypeId { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [requires second check].
        /// </summary>
        /// <value><c>true</c> if [requires second check]; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets RequiresSecondCheck
        /// </summary>
        public bool RequiresSecondCheck { get; set; }

        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
        /// <value>The revision.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Revision
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// Gets or sets the speciality id.
        /// </summary>
        /// <value>The speciality id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets SpecialityId
        /// </summary>
        public int SpecialityId { get; set; }

        /// <summary>
        /// Gets or sets the name of the speciality.
        /// </summary>
        /// <value>The name of the speciality.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets SpecialityName
        /// </summary>
        public string SpecialityName { get; set; }

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        /// <value>The category id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CategoryId
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>The name of the category.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CategoryName
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the create user id.
        /// </summary>
        /// <value>The create user id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CreateUserId
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the create user.
        /// </summary>
        /// <value>The name of the create user.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CreateUserName
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// Gets or sets the item type id.
        /// </summary>
        /// <value>The item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the item type.
        /// </summary>
        /// <value>The name of the item type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }

        /// <summary>
        /// Gets or sets the complexity id.
        /// </summary>
        /// <value>The complexity id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ComplexityId
        /// </summary>
        public int ComplexityId { get; set; }

        /// <summary>
        /// Gets or sets the item status id.
        /// </summary>
        /// <value>The item status id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemStatusId
        /// </summary>
        public byte ItemStatusId { get; set; }

        /// <summary>
        /// Gets or sets the name of the item status.
        /// </summary>
        /// <value>The name of the item status.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemStatusName
        /// </summary>
        public string ItemStatusName { get; set; }

        /// <summary>
        /// Gets or sets the printer type id.
        /// </summary>
        /// <value>The printer type id.</value>
        /// <remarks></remarks>
        public short? ParentItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the printer type.
        /// </summary>
        /// <value>The name of the printer type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ParentItemTypeName
        /// </summary>
        public string ParentItemTypeName { get; set; }

        /// <summary>
        /// Gets or sets the IPOH.
        /// </summary>
        /// <value>The IPOH.</value>
        /// <remarks></remarks>
        public int? IPOH { get; set; }

        /// <summary>
        /// Gets or sets the manufacture reference.
        /// </summary>
        /// <value>The manufacture reference.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ManufactureReference
        /// </summary>
        public string ManufactureReference { get; set; }

        /// <summary>
        /// Gets or sets the number of labels.
        /// </summary>
        /// <value>The number of labels.</value>
        /// <remarks></remarks>
        public int? NumberOfLabels { get; set; }

        /// <summary>
        ///  Gets or sets the master definitionid of master.
        /// </summary>
        /// <summary>
        /// Gets or sets MasterDefinitionId
        /// </summary>
        public int MasterDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the compilance Reason 
        /// </summary>
        /// <summary>
        /// Gets or sets ComplianceReason
        /// </summary>
        public string ComplianceReason { get; set; }
        #endregion
    }
}