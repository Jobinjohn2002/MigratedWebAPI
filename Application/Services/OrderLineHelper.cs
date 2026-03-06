using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class OrderLineHelper
    {

        public static List<Data.Models.Operative.OrderLine> GetAllForOrder(int orderId, IUnitOfWork workUnit)
        {
            var orderLineRepository = OrderLineRepository.New(workUnit);
            return orderLineRepository.Repository.Find(o => o.OrderId == orderId).ToList();
        }

        /// <summary>
        /// GetOrderLinesDataContract operation
        /// </summary>
        public static List<OrderLineDataContract> GetOrderLinesDataContract(int userId, Data.Models.Operative.Order order, IUnitOfWork workUnit)
        {
            int? deliveryPointId = null;
            if (CustomerSettings.GetEvaluatedForceOrderToMatchTurnaroundDeliveryPoint(order, workUnit))
            {
                deliveryPointId = order.DeliveryPointId;
            }

            var orderLines = GetAllForOrder(order.OrderId, workUnit).Select(ol => ol.ToDataContract()).ToList();

            using (var repository = new PathwayRepository())
            {
                var userIdParameter = new SqlParameter
                {
                    ParameterName = "UserId",
                    SqlDbType = SqlDbType.Int,
                    Value = userId
                };

                var dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                foreach (var orderLine in orderLines.GroupBy(ol => ol.ContainerMasterDefinitionId))
                {
                    dt.Rows.Add(orderLine.Key);
                }

                var containerMasterDefinitionIdsParameter = new SqlParameter
                {
                    ParameterName = "ContainerMasterDefinitionIds",
                    Value = dt,
                    TypeName = "[dbo].[IDTable]",
                    SqlDbType = SqlDbType.Structured
                };

                var deliveryPointIdParameter = new SqlParameter
                {
                    ParameterName = "DeliveryPointId",
                    SqlDbType = SqlDbType.Int
                };
                if (deliveryPointId == null)
                {
                    deliveryPointIdParameter.Value = DBNull.Value;
                }
                else
                {
                    deliveryPointIdParameter.Value = deliveryPointId;
                }

                var results = repository.Container.Database.SqlQuery<GetStockLevelsByContainerMasterDefinition_Result>("GetStockLevelsByContainerMasterDefinition @UserId, @ContainerMasterDefinitionIds, @DeliveryPointId", userIdParameter, containerMasterDefinitionIdsParameter, deliveryPointIdParameter).ToList();

                foreach (var orderLine in orderLines)
                {
                    var result = results.FirstOrDefault(r => r.ContainerMasterDefinitionId == orderLine.ContainerMasterDefinitionId);

                    if (result != null)
                    {
                        orderLine.ContainerMasterAvailableAtLocationExternalId = result.LocationExternalId;
                        orderLine.ContainerMasterAvailableAtLocationText = result.LocationText;
                        orderLine.ContainerMasterAvailableAtLocationQty = result.Count ?? 0;
                    }
                }

                return orderLines;
            }
        }
         

        /// <summary>
        /// ValidateOrderTurnarounds operation
        /// </summary>
        public static void ValidateOrderTurnarounds(Data.Models.Operative.Order order, OrderShippingDataContract dc, IUnitOfWork workUnit,OrderData data, bool? isProcessEvent)
        {
            var tmp = new List<Tuple<Data.Models.Operative.OrderLine, ScanAssetDataContract, Turnaround, ScanDetails>>();
            
            data.OrderManagementScanDetails.ApplyEvent = false;

            var turnaroundRepository = TurnaroundRepository.New(workUnit);
            foreach (var line in order.OrderLine.Where(ol => ol.OrderLineStatus.RequiresTurnaround))
            {
                if (line.TurnaroundId != null)
                {
                    var turnaround = turnaroundRepository.Get(line.TurnaroundId.Value);
                    tmp.Add(GetOrderLineTuple(workUnit, line, data.OrderManagementScanDetails, turnaround));
                }
                else
                {
                    throw new NullReferenceException("Turnaround Cannot be Null");
                }
            }

            var mk3Helper = new SynergyTrakHelperMk3(data,isProcessEvent);
            Parallel.ForEach(tmp, oi => mk3Helper.ProcessTurnaround(oi.Item3, oi.Item2, oi.Item4, null, false, true));
            foreach (var oi in tmp)
            {
                oi.Item2.DeliveryPtId = data.OrderManagementScanDetails.DeliveryPointId.Value;
                dc.ProccesedTurnarounds.Add(oi.Item2);
            }
        }

        private static Tuple<Data.Models.Operative.OrderLine, ScanAssetDataContract, Turnaround, ScanDetails> GetOrderLineTuple(IUnitOfWork workUnit, Data.Models.Operative.OrderLine ol, ScanDetails masterSD, Turnaround turnaround)
        {
            var sd = new ScanDetails();
            var trn = TurnaroundFactory.CreateEntity(workUnit);
            var dc = new ScanAssetDataContract();
            var orderLine = OrderLineFactory.CreateEntity(workUnit,
                orderLineId: ol.OrderLineId,
                turnaroundId: ol.TurnaroundId,
                containerMasterDefinitionId: ol.ContainerMasterDefinitionId,
                orderLineStatusId: ol.OrderLineStatusId
            );

            sd.UserId = masterSD.UserId;
            sd.FacilityId = masterSD.FacilityId;
            sd.Hash = masterSD.Hash;
            sd.PrimaryFacilityId = masterSD.PrimaryFacilityId;
            sd.StationId = masterSD.StationId;
            sd.NTLogon = masterSD.NTLogon;
            sd.Culture = masterSD.Culture;
            sd.BaseItemTypeId = masterSD.BaseItemTypeId;
            sd.StationTypeId = masterSD.StationTypeId;
            sd.Events = masterSD.Events;
            sd.ApplyEvent = masterSD.ApplyEvent;
            sd.TurnaroundId = ol.TurnaroundId;

            trn.ContainerInstanceId = turnaround.ContainerInstanceId;
            trn.TurnaroundId = turnaround.TurnaroundId;
            trn.BaseItemTypeId = turnaround.BaseItemTypeId;
            trn.ContainerMasterId = turnaround.ContainerMasterId;
            trn.LastEventId = turnaround.LastEventId;
            trn.LastEventTypeId = turnaround.LastEventTypeId;
            trn.FacilityId = turnaround.FacilityId;
            trn.Expiry = turnaround.Expiry;
            trn.DeliveryNoteId = turnaround.DeliveryNoteId;
            trn.DeliveryPointId = turnaround.DeliveryPointId;

            return new Tuple<Data.Models.Operative.OrderLine, ScanAssetDataContract, Turnaround, ScanDetails>(orderLine, dc, trn, sd);
        }
    }
}