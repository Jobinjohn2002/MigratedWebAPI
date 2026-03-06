using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class TurnaroundExtensions
    {
        /// <summary>
        /// BuildStoragePointTurnaroundsTableModel operation
        /// </summary>
        public static TableModel BuildStoragePointTurnaroundsTableModel(this IList<Turnaround> turnarounds, IBaseController controller, ITranslator translator, string group, string section, User user)
        {
            var canReadTurnarounds = user.HasCustomerPermission(KnownPermission.ReadTurnaround);
            var canReadItem = user.HasCustomerPermission(KnownPermission.ReadItem);
            var canReadInstance = user.HasCustomerPermission(KnownPermission.ReadInstance);

            return new TableModel(controller.IsInternetExplorer10orLess, controller.IsInternetExplorer11orLess)
            {
                Columns = new List<TableColumnModel>
                {
                    new TableColumnModel 
                    { 
                        Text = translator.GetText(group, section, "Turnaround"), 
                        Name = "TurnaroundID" 
                    },
                    new TableColumnModel 
                    { 
                        Text = translator.GetText(group, section, "ContainerMasterID"), 
                        Name = "ContainerMasterID",
                        CollapseMode = CollapseMode.First
                    },
                    new TableColumnModel 
                    { 
                        Text = translator.GetText(group, section, "ContainerInstanceID"), 
                        Name = "ContainerInstanceID",
                        CollapseMode = CollapseMode.Fourth
                    },
                    new TableColumnModel
                    {
                        Text = translator.GetText(group, section, "ContainerMaster"),
                        Name = "ContainerMaster",
                        CollapseMode = CollapseMode.Second
                    },
                    new TableColumnModel 
                    { 
                        Text = translator.GetText(group, section, "DeliveryPoint"), 
                        Name = "DeliveryPoint"
                    },
                    new TableColumnModel
                    {
                        Text = translator.GetText(group, section, "SterileExpiry"),
                        Name = "SterileExpiry"
                    }
                },
                CssClass = "tableStoragePointTurnarounds",
                CurrentPage = 1,
                OnGetTableCells = index =>
                {
                    var turnaround = turnarounds[index];

                    return new RowModel
                    {
                        new TableCellModel
                        {
                            Value = turnaround.ExternalId,
                            ActionInfo = canReadTurnarounds && TenancyConfiguration.TurnaroundSettings.Enabled(user.TenancyId)
                            ? new ActionInfo
                                {
                                    Action = "Details",
                                    Controller = "Turnaround",
                                    RouteValues = new RouteValueDictionary
                                    {
                                        { "Area", "Services" },
                                        { "id", turnaround.TurnaroundId }
                                    }
                                }
                            : null
                        },
                        new TableCellModel
                        {
                            Value = turnaround.ContainerMaster.ExternalId,
                            ActionInfo = canReadItem
                            ? new ActionInfo
                                {
                                    Action = "Details",
                                    Controller = "ContainerMaster",
                                    RouteValues = new RouteValueDictionary
                                    {
                                        { "Area", "Services" },
                                        { "id", turnaround.ContainerMaster.ContainerMasterId }
                                    }
                                }
                            : null
                        },
                        new TableCellModel
                        {
                            Value = turnaround.ContainerInstance == null ? "" : turnaround.ContainerInstance.PrimaryId,
                            ActionInfo = canReadInstance && turnaround.ContainerInstance != null && TenancyConfiguration.InstanceSettings.Enabled(user.TenancyId)
                            ? new ActionInfo
                                {
                                    Action = "Details",
                                    Controller = "ContainerInstance",
                                    RouteValues = new RouteValueDictionary
                                    {
                                        { "Area", "Services" },
                                        { "id", turnaround.ContainerInstance.ContainerInstanceId }
                                    }
                                }
                            : null
                        },
                        new TableCellModel
                        {
                            Value = turnaround.ContainerMaster.Text,
                            ActionInfo = canReadItem
                            ? new ActionInfo
                                {
                                    Action = "Details",
                                    Controller = "ContainerMaster",
                                    RouteValues = new RouteValueDictionary
                                    {
                                        { "Area", "Services" },
                                        { "id", turnaround.ContainerMaster.ContainerMasterId }
                                    }
                                }
                            : null
                        },
                        new TableCellModel
                        {
                            Value = turnaround.DeliveryPoint.Text
                        },
                        new TableCellModel
                        {
                            Value = turnaround.SterileExpiryDate.HasValue ? turnaround.SterileExpiryDate.ToLocalShortDateTime() : translator.GetTerm("NA")
                        }
                    };
                },
                PageAction = ActionInfo.None,
                RefreshAction = ActionInfo.None,
                ResultsOnPage = turnarounds.Count,
                ResultsPerPage = turnarounds.Count,
                TotalResults = turnarounds.Count
            };
        }
    }
}