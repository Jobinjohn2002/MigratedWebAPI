using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static partial class DataAdapterFactory
    {
        /// <summary>
        /// GetSearchDataAdapter operation
        /// </summary>
        public static ISearchDataAdapter GetSearchDataAdapter(IUnitOfWork efUnitOfWork)
        {
            return new SearchDataAdapter(efUnitOfWork);
        }

        /// <summary>
        /// GetStationAssociatedStationTypeDataAdapter operation
        /// </summary>
        public static IStationAssociatedStationTypeDataAdapter GetStationAssociatedStationTypeDataAdapter(
            IUnitOfWork efUnitOfWork)
        {
            return new StationAssociatedStationTypeDataAdapter(efUnitOfWork);
        }

        /// <summary>
        /// GetCustomerDefectCustomerDefectReasonsDataAdapter operation
        /// </summary>
        public static ICustomerDefectCustomerDefectReasonDataAdapter GetCustomerDefectCustomerDefectReasonsDataAdapter(
            IUnitOfWork efUnitOfWork)
        {
            return new CustomerDefectCustomerDefectReasonDataAdapter(efUnitOfWork);
        }

        /// <summary>
        /// GetStationDeliveryPointDataAdapter operation
        /// </summary>
        public static IStationDeliveryPointDataAdapter GetStationDeliveryPointDataAdapter(IUnitOfWork efUnitOfWork)
        {
            return new StationDeliveryPointDataAdapter(efUnitOfWork);
        }

        /// <summary>
        /// GetServiceRequirementItemTypeDataAdapter operation
        /// </summary>
        public static IServiceRequirementItemTypeDataAdapter GetServiceRequirementItemTypeDataAdapter(IUnitOfWork efUnitOfWork)
        {
            return new ServiceRequirementItemTypeDataAdapter(efUnitOfWork);
        }

        /// <summary>
        /// GetCustomerDetailDataAdapter operation
        /// </summary>
        public static ICustomerDetailDataAdapter GetCustomerDetailDataAdapter(IUnitOfWork efUnitOfWork)
        {
            return new CustomerDetailDataAdapter(efUnitOfWork);
        }

        /// <summary>
        /// GetMasterDataAdapter operation
        /// </summary>
        public static IMasterDataAdapter GetMasterDataAdapter(IUnitOfWork efUnitOfWork)
        {
            return new MasterDataAdapter(efUnitOfWork);
        }
    }
}