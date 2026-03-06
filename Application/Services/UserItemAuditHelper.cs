using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class UserItemAuditHelper
    {
        /// <summary>
        /// Add operation
        /// </summary>
        public static void Add(ItemMaster currentRevision, ItemMaster newRevision, int userId)
        {
            if (currentRevision.ItemMasterDefinition.ItemMasterDefinitionTypeId == (int)ItemMasterDefinitionTypeIdentifier.Blueprint)
                return; //No Financial stuff for Blueprint Instruments

            if (currentRevision.ItemTypeId != newRevision.ItemTypeId)
            {
                newRevision.UserItemAudit = new UserItemAudit
                {
                    UserId = userId,
                    UserItemAuditTypeId = (short)UserItemAuditTypeId.ItemMasterItemTypeChange
                };
            }

            if (currentRevision.ComponentPartCount != newRevision.ComponentPartCount)
            {
                newRevision.UserItemAudit = new UserItemAudit
                {
                    UserId = userId,
                    UserItemAuditTypeId = (short)UserItemAuditTypeId.FinancialChangeComponentPartCount
                };
            }
        }

        /// <summary>
        /// Save operation
        /// </summary>
        public static void Save(ItemMaster newRevision)
        {
            if (newRevision.UserItemAudit == null)
                return;

            if (newRevision.ItemMasterDefinition.ItemMasterDefinitionTypeId == (int)ItemMasterDefinitionTypeIdentifier.Blueprint)
                return;

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var userItemAuditRepository = new UserItemAuditRepository(workUnit);

                newRevision.UserItemAudit.Created = DateTime.UtcNow;
                newRevision.UserItemAudit.RelatedId = newRevision.ItemMasterId;

                userItemAuditRepository.Add(newRevision.UserItemAudit);
                workUnit.Save();
            }

        }
    }
}
