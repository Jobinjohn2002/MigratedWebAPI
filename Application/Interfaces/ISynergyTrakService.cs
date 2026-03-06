using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ISynergyTrakService
    /// </summary>
    public interface ISynergyTrakService
    {
        [WebInvoke(UriTemplate = "/RetrospectiveAddToWashBatch", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        ScanAssetDataContract RetrospectiveAddToWashBatch(AddToWashBatchDataContract dataContract);
    }
}