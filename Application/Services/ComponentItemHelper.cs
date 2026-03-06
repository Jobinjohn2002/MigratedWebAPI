using SynergyApplicationFrameworkApi.Application.DTOs.ItemExceptions;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ComponentItemHelper
    {
        /// <summary>
        /// GetComponentItems operation
        /// </summary>
        public static List<ComponentItem> GetComponentItems(string procedureName, List<SqlParameter> parameters)
        {
            var items = new List<ComponentItem>();
            using (var repository = new PathwayRepository())
            {
                var itemsGrouped = repository.DataManager.ExecuteQuery((row, table, data) =>
                {
                    var dc = new
                    {
                        CategoryGrouping = row.Field<string>("CategoryGrouping"),
                        MasterId = row.Field<int?>("MasterId"),
                        ItemMasterDefinitionId = row.Field<int?>("ItemMasterDefinitionId"),
                        ExternalId = row.Field<string>("ExternalId"),
                        ItemName = row.Field<string>("ItemName"),
                        Quantity = row.Field<int>("Quantity"),
                        ComponentPartCount = row.Field<short?>("ComponentPartCount"),
                        BaseItemTypeName = row.Field<string>("BaseItemTypeName"),
                        ChildItemTypeName = row.Field<string>("ChildItemTypeName"),
                        ContainerContentNoteId = row.Field<int?>("ContainerContentNoteId"),
                        ContainerContentNote = row.Field<string>("ContainerContentNote"),
                        MasterType = row.Field<string>("MasterType"),
                        ContainerContentId = row.Field<int>("ContainerContentId"),
                        Position = row.Field<int>("Position"),
                        IsNote = row.Field<bool>("IsNote"),
                        ItemExceptionQuantity = row.Field<int?>("ItemExceptionQuantity"),
                        ItemExceptionReasonId = row.Field<byte?>("ItemExceptionReasonId"),
                        ItemExceptionReason = row.Field<string>("ItemExceptionReason"),
                        RemovedFromContainer = row.Field<bool?>("RemovedFromContainer"),
                        Category = row.Field<string>("Category"),
                        GroupHeader = row.Field<string>("GroupHeader"),
                        ManufacturerName = row.Field<string>("ManufacturerName"),
                        ManufacturerRef = row.Field<string>("ManufacturerRef")
                    };
                    return dc;
                },
                    procedureName,
                    CommandType.StoredProcedure,
                    parameters.ToArray()
                ).GroupBy(i => i.ContainerContentId);

                foreach (var groupedItem in itemsGrouped)
                {
                    var componentItem = new ComponentItem()
                    {
                        CategoryGrouping = groupedItem.First().CategoryGrouping,
                        ItemMasterId = groupedItem.First().MasterId,
                        ItemMasterDefinitionId = groupedItem.First().ItemMasterDefinitionId,
                        ExternalId = groupedItem.First().ExternalId,
                        ItemName = groupedItem.First().ItemName,
                        Quantity = groupedItem.First().Quantity,
                        ComponentPartCount = groupedItem.First().ComponentPartCount,
                        BaseItemTypeName = groupedItem.First().BaseItemTypeName,
                        ChildItemTypeName = groupedItem.First().ChildItemTypeName,
                        ContainerContentNoteId = groupedItem.First().ContainerContentNoteId,
                        ContainerContentNote = groupedItem.First().ContainerContentNote,
                        ItemMasterType = groupedItem.First().MasterType,
                        ContainerContentId = groupedItem.First().ContainerContentId,
                        Position = groupedItem.First().Position,
                        IsNote = groupedItem.First().IsNote,
                        Category = groupedItem.First().Category,
                        GroupHeader = groupedItem.First().GroupHeader,
                        Manufacturer = groupedItem.First().ManufacturerName,
                        ManufacturerRef = groupedItem.First().ManufacturerRef
                    };

                    componentItem.ItemExceptions = new List<ItemExceptionDataContract>();
                    foreach (var itemException in groupedItem)
                    {
                        if (itemException.ItemExceptionQuantity != null && itemException.ItemExceptionQuantity > 0)
                        {
                            componentItem.ItemExceptions.Add(new ItemExceptionDataContract()
                            {
                                ItemExceptionQuantity = (int)itemException.ItemExceptionQuantity,
                                ItemExceptionReason = new ItemExceptionReasonDataContract()
                                {
                                    ItemExceptionReasonId = (byte)itemException.ItemExceptionReasonId,
                                    Text = itemException.ItemExceptionReason,
                                    RemovedFromContainer = (bool)itemException.RemovedFromContainer
                                },
                                ContainerContentId = itemException.ContainerContentId
                            });
                        }
                    }

                    items.Add(componentItem);
                }
            }

            return items;
        }
    }
}