using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class PrinterDataAdapter
    {
        #region IPrinterDataAdapter Members

        /// <summary>
        /// GetPrintersByFacility operation
        /// </summary>
        public IQueryable<IPrinter> GetPrintersByFacility(short facilityId)
        {
            try
            {
                var printerRepository = PrinterRepository.New(WorkUnit);
                return printerRepository.GetByFacility(facilityId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// ArchivePrinter operation
        /// </summary>
        public void ArchivePrinter(int printerIndexId, int userId)
        {
            try
            {
                var repository = PrinterRepository.New(WorkUnit);
                Printer printer = repository.Get(printerIndexId);
                printer.Archived = DateTime.UtcNow;
                printer.ArchivedUserId = userId;
                WorkUnit.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}