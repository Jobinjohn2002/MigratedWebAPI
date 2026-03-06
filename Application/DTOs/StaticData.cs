using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StaticData
    /// </summary>
    public class StaticData
    {
        /// <summary>
        /// Gets or sets ConfiguredItemCategories
        /// </summary>
        public IList<ConfigurableStaticDataValue<int>> ConfiguredItemCategories { get; set; } = new List<ConfigurableStaticDataValue<int>>();
        /// <summary>
        /// Gets or sets ConfiguredSpecialities
        /// </summary>
        public IList<ConfigurableStaticDataValue<short>> ConfiguredSpecialities { get; set; } = new List<ConfigurableStaticDataValue<short>>();
        /// <summary>
        /// Gets or sets ItemComplexities
        /// </summary>
        public IDictionary<short, string> ItemComplexities { get; set; }
        /// <summary>
        /// Gets or sets ItemTypesWithParent
        /// </summary>
        public IList<GenericKeyValueData> ItemTypesWithParent { get; set; }
        /// <summary>
        /// Gets or sets ConfiguredItemTypes
        /// </summary>
        public IList<ConfigurableStaticDataValue<short>> ConfiguredItemTypes { get; set; } = new List<ConfigurableStaticDataValue<short>>();
        /// <summary>
        /// Gets or sets ConfiguredBatchCycles
        /// </summary>
        public IList<ConfigurableStaticDataValue<int>> ConfiguredBatchCycles { get; set; } = new List<ConfigurableStaticDataValue<int>>();
        /// <summary>
        /// Gets or sets ConfiguredChargeableBatchCycles
        /// </summary>
        public IList<ConfigurableStaticDataValue<int>> ConfiguredChargeableBatchCycles { get; set; } = new List<ConfigurableStaticDataValue<int>>();
        /// <summary>
        /// Gets or sets ContainerMasterNoteTypes
        /// </summary>
        public IDictionary<byte, string> ContainerMasterNoteTypes { get; set; }
        /// <summary>
        /// Gets or sets StationTypes
        /// </summary>
        public IDictionary<byte, string> StationTypes { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointTypes
        /// </summary>
        public IDictionary<byte, string> DeliveryPointTypes { get; set; }
        /// <summary>
        /// Gets or sets ConfiguredBaseItemTypes
        /// </summary>
        public IList<ConfigurableStaticDataValue<short>> ConfiguredBaseItemTypes { get; set; } = new List<ConfigurableStaticDataValue<short>>();
        /// <summary>
        /// Gets or sets ConfiguredMachineTypes
        /// </summary>
        public IList<ConfigurableStaticDataValue<byte>> ConfiguredMachineTypes { get; set; } = new List<ConfigurableStaticDataValue<byte>>();
        /// <summary>
        /// Gets or sets ConfiguredMachineWashTypes
        /// </summary>
        public IList<ConfigurableStaticDataValue<byte>> ConfiguredMachineWashTypes { get; set; } = new List<ConfigurableStaticDataValue<byte>>();
        /// <summary>
        /// Gets or sets StationTypeCategories
        /// </summary>
        public IDictionary<byte, string> StationTypeCategories { get; set; }
        /// <summary>
        /// Gets or sets StatusTypes
        /// </summary>
        public IDictionary<byte, string> StatusTypes { get; set; }
        /// <summary>
        /// Gets or sets Facilities
        /// </summary>
        public IDictionary<short, string> Facilities { get; set; }
        /// <summary>
        /// Gets or sets Roles
        /// </summary>
        public IDictionary<short, string> Roles { get; set; }
        /// <summary>
        /// Gets or sets Permissions
        /// </summary>
        public IDictionary<short, string> Permissions { get; set; }
        /// <summary>
        /// Gets or sets LabelTypes
        /// </summary>
        public IDictionary<byte, string> LabelTypes { get; set; }
        /// <summary>
        /// Gets or sets PrinterTypes
        /// </summary>
        public IDictionary<byte, string> PrinterTypes { get; set; }
        /// <summary>
        /// Gets or sets ConfiguredDecontaminationTasks
        /// </summary>
        public IList<ConfigurableStaticDataValue<int>> ConfiguredDecontaminationTasks { get; set; } = new List<ConfigurableStaticDataValue<int>>();
        /// <summary>
        /// Gets or sets LabourLevels
        /// </summary>
        public IDictionary<int, string> LabourLevels { get; set; }
        /// <summary>
        /// Gets or sets ClockingConfigurationTypes
        /// </summary>
        public IDictionary<int, string> ClockingConfigurationTypes { get; set; }
        /// <summary>
        /// Gets or sets DelayedBiTestTypes
        /// </summary>
        public IDictionary<int, string> DelayedBiTestTypes { get; set; }
        /// <summary>
        /// Gets or sets Qualities
        /// </summary>
        public IDictionary<short, string> Qualities { get; set; }
        /// <summary>
        /// Gets or sets ItemCategories
        /// </summary>
        public IDictionary<int, string> ItemCategories { get { return ConfiguredItemCategories.Where(x => x.IsSelected).OrderBy(x => x.DisplayOrder).ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets Specialities
        /// </summary>
        public IDictionary<short, string> Specialities { get { return ConfiguredSpecialities.Where(x => x.IsSelected).OrderBy(x => x.DisplayOrder).ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets ItemTypes
        /// </summary>
        public IDictionary<short, string> ItemTypes { get { return ConfiguredItemTypes.Where(x => x.IsSelected).OrderBy(x => x.DisplayOrder).ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets BatchCycles
        /// </summary>
        public IDictionary<int, string> BatchCycles { get { return ConfiguredBatchCycles.Where(x => x.IsSelected).OrderBy(x => x.DisplayOrder).ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets ChargeableBatchCycles
        /// </summary>
        public IDictionary<int, string> ChargeableBatchCycles { get { return ConfiguredChargeableBatchCycles.Where(x => x.IsSelected).OrderBy(x => x.DisplayOrder).ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets BaseItemTypes
        /// </summary>
        public IDictionary<short, string> BaseItemTypes { get { return ConfiguredBaseItemTypes.Where(x => x.IsSelected).OrderBy(x => x.DisplayOrder).ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets MachineTypes
        /// </summary>
        public IDictionary<byte, string> MachineTypes { get { return ConfiguredMachineTypes.Where(x => x.IsSelected).OrderBy(x => x.DisplayOrder).ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets MachineWashTypes
        /// </summary>
        public IDictionary<byte, string> MachineWashTypes { get { return ConfiguredMachineWashTypes.Where(x => x.IsSelected).OrderBy(x => x.DisplayOrder).ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets DecontaminationTasks
        /// </summary>
        public IDictionary<int, string> DecontaminationTasks { get { return ConfiguredDecontaminationTasks.Where(x => x.IsSelected).OrderBy(x => x.DisplayOrder).ToDictionary(x => x.Id, x => x.Value); } set { } }

        /// <summary>
        /// Gets or sets AllItemCategories
        /// </summary>
        public IDictionary<int, string> AllItemCategories { get { return ConfiguredItemCategories.ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets AllSpecialities
        /// </summary>
        public IDictionary<short, string> AllSpecialities { get { return ConfiguredSpecialities.ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets AllItemTypes
        /// </summary>
        public IDictionary<short, string> AllItemTypes { get { return ConfiguredItemTypes.ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets AllBatchCycles
        /// </summary>
        public IDictionary<int, string> AllBatchCycles { get { return ConfiguredBatchCycles.ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets AllChargeableBatchCycles
        /// </summary>
        public IDictionary<int, string> AllChargeableBatchCycles { get { return ConfiguredChargeableBatchCycles.ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets AllBaseItemTypes
        /// </summary>
        public IDictionary<short, string> AllBaseItemTypes { get { return ConfiguredBaseItemTypes.ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets AllMachineTypes
        /// </summary>
        public IDictionary<byte, string> AllMachineTypes { get { return ConfiguredMachineTypes.ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets AllMachineWashTypes
        /// </summary>
        public IDictionary<byte, string> AllMachineWashTypes { get { return ConfiguredMachineWashTypes.ToDictionary(x => x.Id, x => x.Value); } set { } }
        /// <summary>
        /// Gets or sets AllDecontaminationTasks
        /// </summary>
        public IDictionary<int, string> AllDecontaminationTasks { get { return ConfiguredDecontaminationTasks.ToDictionary(x => x.Id, x => x.Value); } set { } }

        public StaticData()
        {
        }

        public StaticData(IStaticData staticData)
        {
            ConfiguredItemCategories = staticData.ConfiguredItemCategories;
            ConfiguredSpecialities = staticData.ConfiguredSpecialities;
            ItemComplexities = staticData.ItemComplexities;
            ConfiguredItemTypes = staticData.ConfiguredItemTypes;
            ConfiguredBatchCycles = staticData.ConfiguredBatchCycles;
            ConfiguredChargeableBatchCycles = staticData.ConfiguredChargeableBatchCycles;
            ContainerMasterNoteTypes = staticData.ContainerMasterNoteTypes;
            StationTypes = staticData.StationTypes;
            DeliveryPointTypes = staticData.DeliveryPointTypes;
            ConfiguredBaseItemTypes = staticData.ConfiguredBaseItemTypes;
            ConfiguredMachineTypes = staticData.ConfiguredMachineTypes;
            ConfiguredMachineWashTypes = staticData.ConfiguredMachineWashTypes;
            StationTypeCategories = staticData.StationTypeCategories;
            StatusTypes = staticData.StatusTypes;
            Facilities = staticData.Facilities;
            Roles = staticData.Roles;
            Permissions = staticData.Permissions;
            LabelTypes = staticData.LabelTypes;
            PrinterTypes = staticData.PrinterTypes;
            ItemTypesWithParent = staticData.ItemTypesWithParent;
            ConfiguredDecontaminationTasks = staticData.ConfiguredDecontaminationTasks;
            LabourLevels = staticData.LabourLevels;
            ClockingConfigurationTypes = staticData.ClockingConfigurationTypes;
            DelayedBiTestTypes = staticData.DelayedBiTestTypes;
            Qualities = staticData.Qualities;
        }
    }
}
