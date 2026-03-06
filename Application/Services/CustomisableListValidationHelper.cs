using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// CustomisableListValidationHelper
    /// </summary>
    public class CustomisableListValidationHelper
    {
        private const string _group = "enum";
        private const string _section = "InvalidReferenceObjectType";
        private readonly int _tenancyId;
        private List<short> _tenancyFacilityIds;
        private ITranslator _translator;

        public CustomisableListValidationHelper(ITranslator translator, int tenancyId)
        {
            _tenancyId = tenancyId;
            _translator = translator;

            using (var repository = InstanceFactory.GetInstance<IPathwayRepository>())
            {
                _tenancyFacilityIds = repository.Where<Facility>(f => f.Owner.Tenancy.TenancyId == tenancyId && !f.Archived.HasValue).Select(f => f.FacilityId).ToList();
            }
        }

        /// <summary>
        /// Validate operation
        /// </summary>
        public ConfigurableListValidationResult Validate(ConfigurableListTypeIdentifier listType, List<ConfigurableListValueDataContract> valuesToRemove)
        {
            ConfigurableListValidationResult result = null;

            switch (listType)
            {
                case ConfigurableListTypeIdentifier.Category:
                    result = ValidateCategoryRemoval(valuesToRemove);
                    break;
                case ConfigurableListTypeIdentifier.MachineType:
                    result = ValidateMachineTypeRemoval(valuesToRemove);
                    break;
                case ConfigurableListTypeIdentifier.ItemType:
                    result = ValidateItemTypeRemoval(valuesToRemove);
                    break;
                case ConfigurableListTypeIdentifier.BatchCycle:
                    result = ValidateMachineBatchCycleRemoval(valuesToRemove);
                    break;
                case ConfigurableListTypeIdentifier.MaintenanceActivity:
                    result = ValidateMaintenanceActivityRemoval(valuesToRemove);
                    break;
                case ConfigurableListTypeIdentifier.Speciality:
                    result = ValidateSpecialityRemoval(valuesToRemove);
                    break;
                case ConfigurableListTypeIdentifier.FailureTypeEventType:
                    throw new NotSupportedException("ConfigurableListType.FailureTypeEventType is not supported here. Use Validate(TurnAroundEventTypeIdentifier turnAroundEventType, List<ConfigurableListValueDataContract> valuesToRemove) instead.");
                case ConfigurableListTypeIdentifier.DefectResponsibility:
                case ConfigurableListTypeIdentifier.DecontaminationTask:
                case ConfigurableListTypeIdentifier.Courier:
                case ConfigurableListTypeIdentifier.ItemExceptionReason:
                case ConfigurableListTypeIdentifier.QuarantineReason:
                    result = new ConfigurableListValidationResult(true, listType);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Validate operation
        /// </summary>
        public ConfigurableListValidationResult Validate(TurnAroundEventTypeIdentifier turnAroundEventType, List<ConfigurableListValueDataContract> valuesToRemove)
        {
            ConfigurableListValidationResult result = null;

            switch (turnAroundEventType)
            {
                case TurnAroundEventTypeIdentifier.WeighedUsingPostWashTolerances:
                case TurnAroundEventTypeIdentifier.WeighedUsingPreWashTolerances:
                case TurnAroundEventTypeIdentifier.FailPacking:
                case TurnAroundEventTypeIdentifier.PreAerDeconTaskFailure:
                case TurnAroundEventTypeIdentifier.AerFailed:
                case TurnAroundEventTypeIdentifier.FailedQualityAssurance:
                    result = new ConfigurableListValidationResult(true, ConfigurableListTypeIdentifier.FailureTypeEventType);
                    break;

                default:
                    throw new NotSupportedException("Event type " + turnAroundEventType.ToString() + " is not supported in Configurable Lists");
            }

            return result;
        }

        /// <summary>
        /// ValidateAdd operation
        /// </summary>
        public ConfigurableListBasicValidationResult ValidateAdd(ConfigurableListTypeIdentifier listType, string newValue, TenancyCustomisationController controller)
        {
            ConfigurableListBasicValidationResult result = new ConfigurableListBasicValidationResult(true, listType);

            {
                switch (listType)
                {
                    case ConfigurableListTypeIdentifier.MaintenanceActivity:
                        result.IsValid = repository.FirstOrDefault<MaintenanceActivity>(x => x.Text == newValue && !x.Archived.HasValue) == null;
                        break;

                    case ConfigurableListTypeIdentifier.BatchCycle:
                        result.IsValid = repository.FirstOrDefault<BatchCycle>(x => x.Text == newValue && !x.Archived.HasValue) == null;
                        break;

                    case ConfigurableListTypeIdentifier.Courier:
                        result.IsValid = repository.FirstOrDefault<Courier>(x => x.Text == newValue && !x.Archived.HasValue) == null;
                        break;

                    case ConfigurableListTypeIdentifier.Speciality:
                        result.IsValid = repository.FirstOrDefault<Speciality>(x => x.Text == newValue && !x.Archived.HasValue) == null;
                        break;

                    case ConfigurableListTypeIdentifier.DecontaminationTask:
                        result.IsValid = repository.FirstOrDefault<DecontaminationTask>(x => x.Text == newValue && !x.Archived.HasValue) == null;
                        break;

                    case ConfigurableListTypeIdentifier.QuarantineReason:
                        result.IsValid = repository.FirstOrDefault<QuarantineReason>(qr => qr.Text == newValue && !qr.Archived.HasValue) == null;
                        break;

                    default:
                        throw new NotSupportedException("Adding custom values to " + listType.ToFriendlyString() + " is not supported.");
                }
            }

            if (!result.IsValid)
            {
                result.ErrorMessage = string.Format(controller.Translator.GetText(controller.group, controller.addSection, "NewValueExists"), newValue);
            }

            return result;
        }

        private ConfigurableListValidationResult ValidateMachineTypeRemoval(List<ConfigurableListValueDataContract> valuesToRemove)
        {
            var result = new ConfigurableListValidationResult(true, ConfigurableListTypeIdentifier.MachineType);

            var machineTypeIdsToRemove = valuesToRemove.Select(v => v.CustomValueId);

            {
                var machinesInUse = repository.Where<Machine>(m =>
                    m.Facility.Owner.TenancyId == _tenancyId &&
                    machineTypeIdsToRemove.Contains(m.MachineTypeId) &&
                    m.Archived == null).ToList();

                if (machinesInUse.Any())
                {
                    result.IsValid = false;

                    var machineTypesInUse = (from m in machinesInUse
                                             group m by new { m.MachineTypeId, m.MachineType.Text } into g
                                             select new
                                             {
                                                 machineTypeId = g.Key.MachineTypeId,
                                                 machineTypeName = g.Key.Text,
                                                 facilities = (from a in g
                                                               group a by a.Facility into b
                                                               select new
                                                               {
                                                                   facility = b.Key,
                                                                   machines = b.OrderBy(m => m.Text).ToList()
                                                               }).OrderBy(f => f.facility.Text).ToList()
                                             }).OrderBy(m => m.machineTypeName).ToList();

                    foreach (var machineType in machineTypesInUse)
                    {
                        var invalidValue = new InvalidCustomisableListValue()
                        {
                            InvalidValue = valuesToRemove.Single(v => v.CustomValueId.Value == machineType.machineTypeId),
                        };

                        foreach (var facilityMachines in machineType.facilities)
                        {
                            var invalidReferences = new InvalidReference(InvalidReferenceObjectType.Facility, _translator.GetText(_group, _section, InvalidReferenceObjectType.Facility.ToString()))
                            {
                                Id = facilityMachines.facility.FacilityId,
                                Text = facilityMachines.facility.Text
                            };

                            foreach (var machine in facilityMachines.machines)
                            {
                                invalidReferences.Children.Add(new InvalidReference(InvalidReferenceObjectType.Machine, _translator.GetText(_group, _section, InvalidReferenceObjectType.Machine.ToString()), machine.MachineId, machine.Text));
                            }

                            invalidValue.InvalidReferences.Add(invalidReferences);
                        }

                        result.InvalidValues.Add(invalidValue);

                        GetMachineTypeInvalidContainerMasters(machineType.machineTypeId, result, valuesToRemove);
                    }
                }           
            }

            return result;
        }

        private void GetMachineTypeInvalidContainerMasters(int machineTypeId, ConfigurableListValidationResult result, List<ConfigurableListValueDataContract> valuesToRemove)
        {
            List<object> containerMasters = new List<object>();
            {
                IEnumerable<dynamic> invalidContainers = Database.Pathway.GetInvalidMachineTypesContainers.GetInvalidMachineTypeContainers(_tenancyId, machineTypeId);

                var invalidValue = GetOrCreateInvalidItem(result, valuesToRemove, machineTypeId);

                if ((invalidContainers.Count() == 1) || (invalidContainers.Count() == 1 && invalidContainers.Single()["ContainerMasterId"] is null))
                {
                    if (int.TryParse(invalidContainers.Single()["ItemMasterText"].ToString(), out int overridenCount))
                    {
                        var invalidContainerReferences = (new InvalidReference(InvalidReferenceObjectType.ContainerMaster, InvalidReferenceObjectType.ContainerMaster.ToFriendlyString())
                        {
                            Id = -1,
                            OverridenCount = overridenCount
                        });

                        invalidValue.InvalidReferences.Add(invalidContainerReferences);

                        return;
                    }
                }

                foreach (var container in invalidContainers)
                {
                    var itemMaster = new List<string>();

                    if (container["ItemMasterText"] != null)
                    {
                        itemMaster.Add(container["ItemMasterText"].ToString());
                    }

                    var invalidValueitem = Convert.ToInt32(container["machineTypeId"]);
                    var containerMaster = new
                    {
                        containerMasterId = container["ContainerMasterId"],
                        containerMasterText = container["ContainerMasterText"],
                        invalidValueId = invalidValueitem,
                        itemMasters = itemMaster
                    };

                    containerMasters.Add(containerMaster);
                }
            }

            BuildInvalidContainerMasterData(result, valuesToRemove, containerMasters);
        }

        private ConfigurableListValidationResult ValidateMaintenanceActivityRemoval(List<ConfigurableListValueDataContract> valuesToRemove)
        {
            var result = new ConfigurableListValidationResult(true, ConfigurableListTypeIdentifier.MaintenanceActivity);

            var maintenanceActivityIdsToRemove = valuesToRemove.Select(v => v.CustomValueId);

            {
                var vendors = repository.Where<VendorFacility>(vf => _tenancyFacilityIds.Contains(vf.FacilityId)).Select(vf => vf.Vendor.VendorId).ToList();

                var vendorsUsingMaintenanceActivity = repository.Where<VendorMaintenanceActivity>(
                    m => vendors.Contains((int)m.VendorId) &&
                    maintenanceActivityIdsToRemove.Contains(m.MaintenanceActivityId));

                if (vendorsUsingMaintenanceActivity.Any())
                {
                    result.IsValid = false;

                    var maintenanceActivitiesInUse = (from vuma in vendorsUsingMaintenanceActivity
                                                      group vuma by new { vuma.MaintenanceActivityId, vuma.MaintenanceActivity.Text } into g
                                                      select new
                                                      {
                                                          maintenanceActivityId = g.Key.MaintenanceActivityId,
                                                          maintenanceActivityName = g.Key.Text,
                                                          facilities = (from a in g
                                                                        from f in a.Vendor.VendorFacilities
                                                                        group f by f.Facility into b
                                                                        select new
                                                                        {
                                                                            facility = b.Key,
                                                                            vendors = b.Select(vma => vma.Vendor).OrderBy(v => v.Text).ToList()
                                                                        }).OrderBy(f => f.facility.Text).ToList()
                                                      }).OrderBy(m => m.maintenanceActivityName).ToList();

                    foreach (var maintenanceActivity in maintenanceActivitiesInUse)
                    {
                        var invalidValue = new InvalidCustomisableListValue()
                        {
                            InvalidValue = valuesToRemove.Single(v => v.CustomValueId.Value == maintenanceActivity.maintenanceActivityId),
                        };

                        foreach (var facilityVendors in maintenanceActivity.facilities)
                        {
                            var invalidReferences = new InvalidReference(InvalidReferenceObjectType.Facility, _translator.GetText(_group, _section, InvalidReferenceObjectType.Facility.ToString()))
                            {
                                Id = facilityVendors.facility.FacilityId,
                                Text = facilityVendors.facility.Text,
                            };

                            foreach (var vendor in facilityVendors.vendors)
                            {
                                invalidReferences.Children.Add(new InvalidReference(InvalidReferenceObjectType.Vendor, _translator.GetText(_group, _section, InvalidReferenceObjectType.Vendor.ToString()), vendor.VendorId, vendor.Text));
                            }

                            invalidValue.InvalidReferences.Add(invalidReferences);
                        }

                        result.InvalidValues.Add(invalidValue);
                    }
                }
            }

            return result;
        }

        private ConfigurableListValidationResult ValidateItemTypeRemoval(List<ConfigurableListValueDataContract> valuesToRemove)
        {
            var result = new ConfigurableListValidationResult(true, ConfigurableListTypeIdentifier.ItemType);

            var itemTypeIdsToRemove = valuesToRemove.Select(v => v.CustomValueId);

            {
                var facilitiesUsingItemType = repository.Where<Facility>(f =>
                    f.Owner.TenancyId == _tenancyId &&
                    f.FacilityItemTypes.Any(fit => itemTypeIdsToRemove.Contains(fit.ItemTypeId)) &&
                    f.Archived == null).ToList();

                if (facilitiesUsingItemType.Any())
                {
                    result.IsValid = false;

                    var itemTypesInUse = (from i in facilitiesUsingItemType
                                          from fit in i.FacilityItemTypes
                                          where itemTypeIdsToRemove.Contains(fit.ItemTypeId)
                                          group i by new { fit.ItemTypeId, fit.ItemType.Text } into g
                                          select new
                                          {
                                              itemTypeId = g.Key.ItemTypeId,
                                              itemTypeName = g.Key.Text,
                                              facilities = g.OrderBy(f => f.Text).ToList()
                                          }).OrderBy(i => i.itemTypeName).ToList();

                    foreach (var itemType in itemTypesInUse)
                    {
                        var invalidValue = new InvalidCustomisableListValue()
                        {
                            InvalidValue = valuesToRemove.Single(v => v.CustomValueId.Value == itemType.itemTypeId),
                        };

                        foreach (var facilityItemTypes in itemType.facilities)
                        {
                            var invalidReferences = new InvalidReference(InvalidReferenceObjectType.Facility, _translator.GetText(_group, _section, InvalidReferenceObjectType.Facility.ToString()))
                            {
                                Id = facilityItemTypes.FacilityId,
                                Text = facilityItemTypes.Text,
                            };

                            invalidValue.InvalidReferences.Add(invalidReferences);
                        }

                        result.InvalidValues.Add(invalidValue);
                    }
                }
                var invalidContainerMasters = repository.Where<ContainerMasterDefinition>(cmd =>
                    cmd.CurrentContainerMaster.Archived == null &&
                    cmd.CustomerDefinition.Owner.TenancyId == _tenancyId &&
                    itemTypeIdsToRemove.Contains(cmd.CurrentContainerMaster.ItemTypeId)
                ).Select(a => new
                {
                    a.CurrentContainerMaster.ContainerMasterId,
                    a.CurrentContainerMaster.Text,
                    invalidValueId = a.CurrentContainerMaster.ItemTypeId,
                    itemMasterText = string.Empty

                }).Union(repository.Where<ContainerContent>(cc =>
                    cc.ContainerMaster.Archived == null &&
                    cc.ContainerMaster.CurrentForDefinitionLink != null &&
                    cc.ContainerMaster.ContainerMasterDefinition.CustomerDefinition.Owner.TenancyId == _tenancyId &&
                    itemTypeIdsToRemove.Contains(cc.ItemMasterDefinition.CurrentItemMaster.ItemTypeId)
                )
                .Select(a => new
                {
                    a.ContainerMaster.ContainerMasterId,
                    a.ContainerMaster.Text,
                    invalidValueId = a.ItemMasterDefinition.CurrentItemMaster.ItemTypeId,
                    itemMasterText = a.ItemMasterDefinition.CurrentItemMaster.Text
                })).GroupBy(a => new { invalidValueId = a.invalidValueId, containerMasterId = a.ContainerMasterId, containerMasterText = a.Text }, (a, b) => new { a.invalidValueId, a.containerMasterId, a.containerMasterText, itemMasters = b.Select(c => c.itemMasterText) });

                BuildInvalidContainerMasterData(result, valuesToRemove, invalidContainerMasters);
            }

            return result;
        }

        private InvalidCustomisableListValue GetOrCreateInvalidItem(ConfigurableListValidationResult result, List<ConfigurableListValueDataContract> valuesToRemove, int invalidValueId)
        {
            var existingInvalidValue = result.InvalidValues.SingleOrDefault(iv => iv.InvalidValue.CustomValueId == invalidValueId);

            if (existingInvalidValue != null) return existingInvalidValue;

            var invalidValue = new InvalidCustomisableListValue()
            {
                InvalidValue = valuesToRemove.Single(v => v.CustomValueId.Value == invalidValueId),
                InvalidReferences = new List<InvalidReference>()
            };

            result.InvalidValues.Add(invalidValue);

            return invalidValue;
        }

        private InvalidReference GetOrCreateInvalidReferenceByType(InvalidCustomisableListValue invalidValue, InvalidReferenceObjectType invalidReferenceObjectType)
        {
            var existingReference = invalidValue.InvalidReferences.SingleOrDefault(ir => ir.InvalidReferenceType == invalidReferenceObjectType);

            if (existingReference != null) return existingReference;

            var invalidReference = new InvalidReference(invalidReferenceObjectType, invalidReferenceObjectType.ToFriendlyString())
            {
                Children = new List<InvalidReference>()
            };

            invalidValue.InvalidReferences.Add(invalidReference);

            return invalidReference;
        }

        private void BuildInvalidContainerMasterData(ConfigurableListValidationResult result, List<ConfigurableListValueDataContract> valuesToRemove, IEnumerable<dynamic> invalidContainerMasters)
        {
            if (invalidContainerMasters.Any())
            {
                result.IsValid = false;

                foreach (var containerMaster in invalidContainerMasters)
                {
                    var invalidReference = new InvalidReference(InvalidReferenceObjectType.ContainerMaster, InvalidReferenceObjectType.ContainerMaster.ToString())
                    {
                        Id = containerMaster.containerMasterId,
                        Text = containerMaster.containerMasterText,
                    };

                    if (((List<string>)containerMaster.itemMasters).Any())
                    {
                        foreach (var itemMaster in containerMaster.itemMasters)
                        {
                            if (!string.IsNullOrEmpty(itemMaster))
                                invalidReference.Children.Add(new InvalidReference() { Text = itemMaster });
                        }
                    }

                    try
                    {
                        var invalidValue = GetOrCreateInvalidItem(result, valuesToRemove, containerMaster.invalidValueId);
                        var invalidGeneral = GetOrCreateInvalidReferenceByType(invalidValue, InvalidReferenceObjectType.General);
                        invalidGeneral.Children.Add(invalidReference);
                    }
                    catch (Exception ex)
                    {
                        var error = ex.Message;
                    }
                }
            }
        }

        private ConfigurableListValidationResult ValidateMachineBatchCycleRemoval(List<ConfigurableListValueDataContract> valuesToRemove)
        {
            var result = new ConfigurableListValidationResult(true, ConfigurableListTypeIdentifier.BatchCycle);

            var batchCycleIdsToRemove = valuesToRemove.Select(v => v.CustomValueId);

            {
                var machinesInUse = repository.Where<Machine>(m =>
                    m.Facility.Owner.TenancyId == _tenancyId &&
                    m.MachineBatchCycles.Any(mbc => batchCycleIdsToRemove.Contains(mbc.BatchCycleId)) &&
                    m.Archived == null).ToList();

                if (machinesInUse.Any())
                {
                    result.IsValid = false;

                    var batchCyclesInUse = (from m in machinesInUse
                                            from bc in m.MachineBatchCycles
                                            where batchCycleIdsToRemove.Contains(bc.BatchCycleId)
                                            group m by new { bc.BatchCycleId, bc.BatchCycle.Text } into g
                                            select new
                                            {
                                                batchCycleId = g.Key.BatchCycleId,
                                                batchCycleName = g.Key.Text,
                                                facilities = (from a in g
                                                              group a by a.Facility into b
                                                              select new
                                                              {
                                                                  facility = b.Key,
                                                                  machines = b.OrderBy(m => m.Text).ToList()
                                                              }).OrderBy(f => f.facility.Text).ToList()
                                            }).OrderBy(b => b.batchCycleName).ToList();

                    foreach (var batchCycle in batchCyclesInUse)
                    {
                        var invalidValue = new InvalidCustomisableListValue()
                        {
                            InvalidValue = valuesToRemove.Single(v => v.CustomValueId.Value == batchCycle.batchCycleId),
                        };

                        foreach (var facilityMachines in batchCycle.facilities)
                        {
                            var invalidReferences = new InvalidReference(InvalidReferenceObjectType.Facility, _translator.GetText(_group, _section, InvalidReferenceObjectType.Facility.ToString()))
                            {
                                Id = facilityMachines.facility.FacilityId,
                                Text = facilityMachines.facility.Text,
                            };

                            foreach (var machine in facilityMachines.machines)
                            {
                                invalidReferences.Children.Add(new InvalidReference(InvalidReferenceObjectType.Machine, _translator.GetText(_group, _section, InvalidReferenceObjectType.Machine.ToString()), machine.MachineId, machine.Text));
                            }

                            invalidValue.InvalidReferences.Add(invalidReferences);
                        }

                        result.InvalidValues.Add(invalidValue);

                        GetBatchCycleInvalidContainerMasters(batchCycle.batchCycleId, result, valuesToRemove);
                    }
                }
            }

            return result;
        }

        private void GetBatchCycleInvalidContainerMasters(int batchCycleId, ConfigurableListValidationResult result, List<ConfigurableListValueDataContract> valuesToRemove)
        {
            List<object> containerMasters = new List<object>();
            { 
                IEnumerable<dynamic> invalidContainers = Database.Pathway.GetInvalidBatchCyclesContainers.GetInvalidBatchCycleContainers(_tenancyId, batchCycleId);

                var invalidValue = GetOrCreateInvalidItem(result, valuesToRemove, batchCycleId);

                if ((invalidContainers.Count() == 1) || (invalidContainers.Count() == 1  && invalidContainers.Single()["ContainerMasterId"] is null))
                {
                    if (int.TryParse(invalidContainers.Single()["ItemMasterText"].ToString(), out int overridenCount))
                    {
                        var invalidContainerReferences = (new InvalidReference(InvalidReferenceObjectType.ContainerMaster, InvalidReferenceObjectType.ContainerMaster.ToFriendlyString())
                            {
                                Id = -1,
                                OverridenCount = overridenCount
                            });

                        invalidValue.InvalidReferences.Add(invalidContainerReferences);

                        return;
                    }
                }

                foreach (var container in invalidContainers)
                {
                    var itemMaster = new List<string>();

                    if (container["ItemMasterText"] != null)
                    {
                        itemMaster.Add(container["ItemMasterText"].ToString());
                    }

                    var invalidValueitem = Convert.ToInt32(container["BatchCycleId"]);
                    var containerMaster = new
                    {
                        containerMasterId = container["ContainerMasterId"],
                        containerMasterText = container["ContainerMasterText"],
                        invalidValueId = invalidValueitem,
                        itemMasters = itemMaster
                    };

                    containerMasters.Add(containerMaster);
                }
            }

            BuildInvalidContainerMasterData(result, valuesToRemove, containerMasters);
        }

        private ConfigurableListValidationResult ValidateSpecialityRemoval(List<ConfigurableListValueDataContract> valuesToRemove)
        {
            var result = new ConfigurableListValidationResult(true, ConfigurableListTypeIdentifier.Speciality);

            var specialityIdsToRemove = valuesToRemove.Select(v => v.CustomValueId);

            {
                var invalidContainerMasters = repository.Where<ContainerMasterDefinition>(cmd =>
                    cmd.CustomerDefinition.Owner.TenancyId == _tenancyId && specialityIdsToRemove.Contains(cmd.CurrentContainerMaster.SpecialityId) &&
                    cmd.CurrentContainerMaster.Archived == null
                ).Select(a => new
                {
                    a.CurrentContainerMaster.ContainerMasterId,
                    a.CurrentContainerMaster.Text,
                    invalidValueId = a.CurrentContainerMaster.SpecialityId,
                    itemMasterText = string.Empty
                }).Union(repository.Where<ContainerContent>(cc =>
                    cc.ContainerMaster.Archived == null &&
                    cc.ContainerMaster.CurrentForDefinitionLink != null &&
                    cc.ContainerMaster.ContainerMasterDefinition.CustomerDefinition.Owner.TenancyId == _tenancyId &&
                    specialityIdsToRemove.Contains(cc.ItemMasterDefinition.CurrentItemMaster.SpecialityId)
                )
                .Select(a => new
                {
                    a.ContainerMaster.ContainerMasterId,
                    a.ContainerMaster.Text,
                    invalidValueId = a.ItemMasterDefinition.CurrentItemMaster.SpecialityId,
                    itemMasterText = a.ItemMasterDefinition.CurrentItemMaster.Text
                })).GroupBy(a => new { invalidValueId = a.invalidValueId, containerMasterId = a.ContainerMasterId, containerMasterText = a.Text }, (a, b) => new { a.invalidValueId, a.containerMasterId, a.containerMasterText, itemMasters = b.Select(c => c.itemMasterText) });

                BuildInvalidContainerMasterData(result, valuesToRemove, invalidContainerMasters);

                if (!invalidContainerMasters.Any())
                {
                    var userComplexities = repository.Where<UserComplexity>(uc =>
                        uc.User.Archived == null &&
                        uc.User.TenancyId == _tenancyId &&
                        specialityIdsToRemove.Contains(uc.Speciality.SpecialityId)
                    ).ToList();

                    if (userComplexities.Any())
                    {
                        result.IsValid = false;
                        result.CanOverride = true;

                        var specialitiesInUse = (from uc in userComplexities
                                                 group uc by new { uc.SpecialityId, uc.Speciality.Text } into g
                                                 select new
                                                 {
                                                     specialityId = g.Key.SpecialityId,
                                                     specialityName = g.Key.Text,
                                                     facilities = (from a in g
                                                                   from f in a.User.UserFacilities
                                                                   group f by f.Facility into b
                                                                   select new
                                                                   {
                                                                       facility = b.Key,
                                                                       users = b.Select(uf => uf.User).OrderBy(u => u.UserName)
                                                                   }).OrderBy(f => f.facility.Text).ToList()
                                                 }).OrderBy(s => s.specialityName).ToList();

                        foreach (var userComplexity in specialitiesInUse)
                        {
                            var invalidValue = new InvalidCustomisableListValue()
                            {
                                InvalidValue = valuesToRemove.Single(v => v.CustomValueId.Value == userComplexity.specialityId),
                            };

                            foreach (var facilityUsers in userComplexity.facilities)
                            {
                                var invalidReferences = new InvalidReference(InvalidReferenceObjectType.Facility, _translator.GetText(_group, _section, InvalidReferenceObjectType.Facility.ToString()))
                                {
                                    Id = facilityUsers.facility.FacilityId,
                                    Text = facilityUsers.facility.Text,
                                };

                                foreach (var user in facilityUsers.users)
                                {
                                }

                                invalidValue.InvalidReferences.Add(invalidReferences);
                            }

                            result.InvalidValues.Add(invalidValue);
                        }
                    }
                }
            }

            return result;
        }

        private ConfigurableListValidationResult ValidateCategoryRemoval(List<ConfigurableListValueDataContract> valuesToRemove)
        {
            var result = new ConfigurableListValidationResult(true, ConfigurableListTypeIdentifier.BatchCycle);

            var categoriesToRemove = valuesToRemove.Select(v => v.CustomValueId);

            {
                var invalidContainerMasters = repository.Where<ContainerMasterDefinition>(cmd =>
                    cmd.CurrentContainerMaster.Archived == null &&
                    cmd.CustomerDefinition.Owner.TenancyId == _tenancyId &&
                    categoriesToRemove.Contains(cmd.CurrentContainerMaster.CategoryId)
                ).Select(a => new
                {
                    a.CurrentContainerMaster.ContainerMasterId,
                    a.CurrentContainerMaster.Text,
                    invalidValueId = a.CurrentContainerMaster.CategoryId,
                    itemMasterText = string.Empty
                }).Union(repository.Where<ContainerContent>(cc =>
                    cc.ContainerMaster.Archived == null &&
                    cc.ContainerMaster.CurrentForDefinitionLink != null &&
                    cc.ContainerMaster.ContainerMasterDefinition.CustomerDefinition.Owner.TenancyId == _tenancyId &&
                    categoriesToRemove.Contains(cc.ItemMasterDefinition.CurrentItemMaster.CategoryId)
                )
                .Select(a => new
                {
                    a.ContainerMaster.ContainerMasterId,
                    a.ContainerMaster.Text,
                    invalidValueId = a.ItemMasterDefinition.CurrentItemMaster.CategoryId,
                    itemMasterText = a.ItemMasterDefinition.CurrentItemMaster.Text
                })).GroupBy(a => new { invalidValueId = a.invalidValueId, containerMasterId = a.ContainerMasterId, containerMasterText = a.Text }, (a, b) => new { a.invalidValueId, a.containerMasterId, a.containerMasterText, itemMasters = b.Select(c => c.itemMasterText) });

                BuildInvalidContainerMasterData(result, valuesToRemove, invalidContainerMasters);
            }

            return result;
        }

        /// <summary>
        /// ValidateRemoveCustomisableTableValue operation
        /// </summary>
        public ConfigurableListValidationResult ValidateRemoveCustomisableTableValue(ConfigurableListValueDataContract configurableListValueDataContract)
        {
            {
                var configurableListValue = repository.First<ConfigurableListValue>(clv => clv.ConfigurableListValueId == configurableListValueDataContract.ConfigurableListValueId);

                if (configurableListValue.OwnerConfigurableListValues.Any())
                {
                    var invalidReferences = configurableListValue.OwnerConfigurableListValues.Select(octv => new InvalidReference(InvalidReferenceObjectType.Tenancy, _translator.GetText(_group, _section, InvalidReferenceObjectType.Tenancy.ToString()))
                    {
                        Id = octv.Owner.Tenancy.TenancyId,
                        Text = octv.Owner.Tenancy.Text
                    }).OrderBy(ir => ir.Text).ToList();

                    return new ConfigurableListValidationResult
                    {
                        IsValid = false,
                        InvalidValues = new List<InvalidCustomisableListValue>
                        {
                            new InvalidCustomisableListValue
                            {
                                InvalidValue = configurableListValueDataContract,
                                InvalidReferences = invalidReferences
                            }
                        }
                    };
                }
            }

            return new ConfigurableListValidationResult
            {
                IsValid = true
            };
        }
    }
}