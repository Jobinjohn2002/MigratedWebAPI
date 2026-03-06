using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// CustomerDetailRepository
    /// </summary>
    public class CustomerDetailRepository
    {
        /// <summary>
        /// GetChargeListByCustomerDefinitionId operation
        /// </summary>
        public IList<IChargeListSummary> GetChargeListByCustomerDefinitionId(int CustomerDefinitionId)
        {
            var ChargeList = new List<IChargeListSummary>();

            using (var context = new OperativeModelContainer())
            {
                if (context.CustomerDefinition.Single(cd => cd.CustomerDefinitionId == CustomerDefinitionId).CustomerDefinitionTypeId == (short)Pathway.Enums.CustomerDefinitionType.LoanVendor)
                    throw new NotSupportedException("Charges Not Valid for Loan Vendors");

                foreach (var results in context.finapp_ReadChargeListByCustomerDefinitionId(CustomerDefinitionId))
                {
                    var charge = new ChargeListSummary();

                    charge.ChargeListId = results.ChargeListId;
                    charge.ChargeListCategory = results.ChargeListCategory;
                    charge.BasePrice = results.BasePrice;
                    charge.CurrentPrice = results.CurrentPrice.GetValueOrDefault();
                    charge.Name = results.Name;

                    ChargeList.Add(charge);
                }

            }

            return ChargeList;
        }

        /// <summary>
        /// ReadCustomerIndexationByCategory operation
        /// </summary>
        public IList<ICustomerIndexationSummary> ReadCustomerIndexationByCategory(int CustomerDefinitionId)
        {
            var CustomerIndexationList = new List<ICustomerIndexationSummary>();

            {
                if (context.CustomerDefinition.Single(cd => cd.CustomerDefinitionId == CustomerDefinitionId).CustomerDefinitionTypeId == (short)Pathway.Enums.CustomerDefinitionType.LoanVendor)
                    throw new NotSupportedException("Indexation Not Valid for Loan Vendors");

                foreach (var results in context.finapp_ReadCustomerIndexationByCategory(CustomerDefinitionId))
                {
                    var customerIndexation = new CustomerIndexationSummary();

                    customerIndexation.IndexationCategoryId = results.IndexationCategoryId;
                    customerIndexation.IndexationFactor = results.IndexationFactor.GetValueOrDefault();
                    customerIndexation.Name = results.Name;

                    CustomerIndexationList.Add(customerIndexation);
                }

            }

            return CustomerIndexationList;
        }

        /// <summary>
        /// ReadCustomerIndexationByCategoryDetail operation
        /// </summary>
        public IList<ICustomerIndexationDetailSummary> ReadCustomerIndexationByCategoryDetail(int CustomerDefinitionId, byte IndexationCategoryId)
        {
            var CustomerIndexationList = new List<ICustomerIndexationDetailSummary>();

            {
                if (context.CustomerDefinition.Single(cd => cd.CustomerDefinitionId == CustomerDefinitionId).CustomerDefinitionTypeId == (short)Pathway.Enums.CustomerDefinitionType.LoanVendor)
                    throw new NotSupportedException("Indexation Not Valid for Loan Vendors");

                foreach (var results in context.finapp_ReadCustomerIndexationByCategoryDetail(CustomerDefinitionId, IndexationCategoryId))
                {
                    var customerIndexation = new CustomerIndexationDetailSummary();

                    customerIndexation.Indexationid = results.IndexationId;
                    customerIndexation.IndexationFactor = results.IndexationFactor;
                    customerIndexation.Indexationtype = results.IndexationType;
                    customerIndexation.AppliesFrom = results.AppliesFrom;
                    customerIndexation.Created = results.Created;
                    customerIndexation.CreatedBy = results.CreatedBy;
                    customerIndexation.Notes = results.Notes;

                    CustomerIndexationList.Add(customerIndexation);
                }

            }

            return CustomerIndexationList;
        }

        /// <summary>
        /// ReadSingleUseItemByCustomerDefinitionId operation
        /// </summary>
        public IList<ISingleUseItemSummary> ReadSingleUseItemByCustomerDefinitionId(int CustomerDefinitionId)
        {
            var SingleUseItemSummaryList = new List<ISingleUseItemSummary>();

            DataSet data;

            using (var repository = new PathwayRepository())
            {
                data = repository.DataManager.ExecuteQuery("dbo.finapp_ReadSingleUseItemByCustomerDefinitionId", CommandType.StoredProcedure,
                                                            new SqlParameter { ParameterName = "@CustomerDefinitionId", Value = CustomerDefinitionId });
            }

            if (data == null || data.Tables.Count != 1)
            {
                throw new KeyNotFoundException("Expected data format is 1 table containing turnaround and event types");
            }

            foreach (DataRow dr in data.Tables[0].Rows)
            {
                var sui = new SingleUseItemSummary
                {
                    ItemMasterId = Convert.ToInt32(dr["ItemMasterId"]),
                    ExternalId = Convert.ToString(dr["ExternalId"]),
                    Name = Convert.ToString(dr["Name"]),
                    ItemType = Convert.ToString(dr["ItemType"]),
                    BasePrice = Convert.ToDecimal(dr["BasePrice"]),
                    Indexation = Convert.ToDecimal(dr["Indexation"])
                };

                SingleUseItemSummaryList.Add(sui);

            }

            return SingleUseItemSummaryList;
        }

        /// <summary>
        /// ReadSingleUseItemByContainerMasterId operation
        /// </summary>
        public IList<ISingleUseItemByContainerMasterSummary> ReadSingleUseItemByContainerMasterId(int ContainerMasterId)
        {
            var SingleUseItemByContainerMasterSummaryList = new List<ISingleUseItemByContainerMasterSummary>();

            DataSet data;

            {
                data = repository.DataManager.ExecuteQuery("dbo.finapp_ReadSingleUseItemByContainerMasterId", CommandType.StoredProcedure,
                                                            new SqlParameter { ParameterName = "@ContainerMasterId", Value = ContainerMasterId });
            }

            if (data == null || data.Tables.Count != 1)
            {
                throw new KeyNotFoundException("Expected data format is 1 table containing turnaround and event types");
            }

            foreach (DataRow dr in data.Tables[0].Rows)
            {
                var sui = new SingleUseItemByContainerMasterSummary
                {
                    ExternalId = Convert.ToString(dr["ExternalId"]),
                    Name = Convert.ToString(dr["Name"]),
                    ItemType = Convert.ToString(dr["ItemType"]),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    BasePrice = Convert.ToDecimal(dr["BasePrice"]),
                    Indexation = Convert.ToDecimal(dr["Indexation"])
                };

                SingleUseItemByContainerMasterSummaryList.Add(sui);

            }

            return SingleUseItemByContainerMasterSummaryList;
        }

        /// <summary>
        /// CountDeliverableContainersByCustomerAndSearchText operation
        /// </summary>
        public int CountDeliverableContainersByCustomerAndSearchText(int customerDefinitionId, string searchText)
        {
            searchText = (searchText ?? string.Empty);
            {
                return context.ContainerMaster.
                    Where(cm =>
                        cm.ContainerMasterDefinition.CustomerDefinitionId == customerDefinitionId &&
                        cm.ItemStatusId == (int)ItemStatusTypeIdentifier.Active &&
                        (
                            cm.ExternalId.Contains(searchText) ||
                            cm.Text.Contains(searchText) ||
                            cm.ItemType.Text.Contains(searchText) ||
                            cm.ItemType.ParentItemType.Text.Contains(searchText)
                        )).
                    Count();
            }
        }

        /// <summary>
        /// UpdateContainerMasterPrice operation
        /// </summary>
        public bool UpdateContainerMasterPrice(int? containermasterid, int? pricecategorydefinitionid, decimal? manualpricecategorycharge, decimal? manualsingleuseitemcharge)
        {
            {
                if (context.ContainerMaster.Single(cd => cd.ContainerMasterId == containermasterid).ContainerMasterDefinition.ContainerMasterDefinitionTypeId == (short)Pathway.Enums.General.ContainerMasterDefinitionTypeIdentifier.Blueprint)
                    throw new NotSupportedException("ContainerMasterPrice Not Valid for Blueprint Items");

                return System.Convert.ToBoolean(context.finapp_UpdateContainerMasterPrice(containermasterid, pricecategorydefinitionid, manualpricecategorycharge, manualsingleuseitemcharge, (manualpricecategorycharge != null)).First().Result);
            }
        }
    }
}
