using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public sealed class LazyMasterHelper
    {
        private static readonly Lazy<LazyMasterHelper> Lazy =
            new Lazy<LazyMasterHelper>(() => new LazyMasterHelper());

        /// <summary>
        /// Gets or sets Instance
        /// </summary>
        public static LazyMasterHelper Instance { get { return Lazy.Value; } }

        private LazyMasterHelper()
        {
        }
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ref ItemMaster concreteMaster, ref IItemMaster genericMaster)
        {
            concreteMaster.MasterUid = genericMaster.MasterUid == Guid.Empty
                                           ? EngineUtility.GenerateNewGuid()
                                           : genericMaster.MasterUid;
            concreteMaster.Name = genericMaster.Name;
            concreteMaster.Complexity = genericMaster.Complexity;
            concreteMaster.IndexId = genericMaster.IndexId;
            concreteMaster.Trackable = genericMaster.Trackable;
            concreteMaster.CreatedDate = genericMaster.CreatedDate;
            concreteMaster.RequiresSecondCheck = genericMaster.RequiresSecondCheck;
            concreteMaster.Revision = genericMaster.Revision;
        }

        /// <summary>
        /// ConvertItemMasterToContract operation
        /// </summary>
        public ItemMasterContract ConvertItemMasterToContract(IItemMaster genericMaster)
        {
            return new ItemMasterContract(genericMaster);
        }
    }
}