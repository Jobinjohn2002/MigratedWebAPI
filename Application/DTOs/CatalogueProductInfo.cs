using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueProductInfo
    /// </summary>
    public class CatalogueProductInfo
    {
        /// <summary>
        /// Gets or sets Active
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets ProductId
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets ProductCode
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Quality
        /// </summary>
        public string Quality { get; set; }

        /// <summary>
        /// Gets or sets WasherMachineTypeId
        /// </summary>
        public int WasherMachineTypeId { get; set; }
        /// <summary>
        /// Gets or sets WasherMachine
        /// </summary>
        public string WasherMachine { get; set; }

        /// <summary>
        /// Gets or sets Documents
        /// </summary>
        public List<string> Documents { get; set; }
        /// <summary>
        /// Gets or sets AutoclaveCycles
        /// </summary>
        public List<CatalogueProductBatchCycleInfo> AutoclaveCycles { get; set; }
        /// <summary>
        /// Gets or sets DeconTasks
        /// </summary>
        public List<CatalogueProductDeconTaskInfo> DeconTasks { get; set; }
        /// <summary>
        /// Gets or sets Specification
        /// </summary>
        public SpecificationInfo Specification { get; set; }
        /// <summary>
        /// Gets or sets ModifiedDate
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }

    public static class ContainerMasterExt
    {
        /// <summary>
        /// ToCatalogueProductInfo operation
        /// </summary>
        public static IQueryable<CatalogueProductInfo> ToCatalogueProductInfo(this IQueryable<ContainerMaster> containerMasters)
        {
            return containerMasters.Select
                (data => new CatalogueProductInfo
                {
                    Active = data.ItemStatusId != (int)KnownItemStatusType.Archived,
                    VendorId = data.ContainerMasterDefinition.CustomerDefinitionId,
                    ProductId = data.ContainerMasterDefinition.ContainerMasterDefinitionId,
                    ProductCode = data.ManufacturersReference,
                    ModifiedDate = data.Created,
                    Name = data.Text,
                    Quality = data.ContainerMasterDefinition.Quality.Text,
                    WasherMachineTypeId = data.MachineTypeId,
                    WasherMachine = data.MachineType.Text,
                    AutoclaveCycles = data.ProcessingBatchCycles.Select(b => new CatalogueProductBatchCycleInfo
                    {
                        BatchCycleId = b.BatchCycleId,
                        BatchCycleName = b.Text,
                        MachineTypeName = b.MachineType.Text,
                        MachineTypeId = b.MachineTypeId
                    }).ToList(),
                    DeconTasks = data.ProcessingDecontaminationTasks.Select(dt => new CatalogueProductDeconTaskInfo
                    {
                        DeconTaskName = dt.Text,
                        DeconTaskId = dt.TaskId
                    }).ToList(),
                    Specification = new SpecificationInfo
                    {
                        ExternalId = data.ExternalId,
                        Name = data.Text,
                        Revision = data.Revision,
                        Type = data.ItemType.Text,
                        ProductNumber = data.ContainerMasterDefinition.ProductNumber,
                        SubType = data.ItemType.SubItemTypes.FirstOrDefault().Text,
                        Notes = data.ContainerContents.Where(cc => cc.ContainerContentNote != null).Select(cc => new SpecificationNoteInfo
                        {
                            Text = cc.ContainerContentNote.Text,
                            Position = cc.Position
                        }).ToList(),
                        Components = data.ContainerContents.Where(cc => cc.ContainerContentNote == null).Select(cc => new SpecificationComponentInfo
                        {
                            Identifiers = new List<Identifier>
                            {
                                new Identifier
                                {
                                    Type = IdentifierType.Synergy,
                                    Value = cc.ItemMasterDefinition.CurrentItemMaster.ExternalId
                                }
                            },
                            Quantity = cc.Quantity,
                            Position = cc.Position,
                            ItemMasterDefinitionId = cc.ItemMasterDefinitionId,
                            Category = cc.ItemMasterDefinition.CurrentItemMaster.Category.Text,
                            Name = cc.ItemMasterDefinition.CurrentItemMaster.Text,
                        }).ToList()
                    },
                }
                );
        }
    }
}