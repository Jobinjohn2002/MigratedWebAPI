using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public sealed class StationAssociatedStationTypeDataAdapter : DataAdapterBase,
                                                                  IStationAssociatedStationTypeDataAdapter
    {
        internal StationAssociatedStationTypeDataAdapter(IUnitOfWork efUnitOfWork)
            : base(efUnitOfWork)
        {
        }

        #region IStationAssociatedStationTypeDataAdapter Members

        /// <summary>
        /// Update operation
        /// </summary>
        public bool Update(int stationId, IList<int> types)
        {
            var stationRepository = StationRepository.New(WorkUnit);
            var stationassociatedstationtypeRepository = new StationAssociatedStationTypeRepository();
            var associatedstationtypes = stationRepository.ReadAssociatedStationTypes(stationId);
            using (var transaction = new TransactionScope())
            {
                foreach (var stationtype in associatedstationtypes.ToList())
                {
                    if (types != null)
                    {
                        if (!types.Contains(stationtype.StationTypeId))
                            stationassociatedstationtypeRepository.Delete(stationId, stationtype.StationTypeId);
                        else
                            types.Remove(stationtype.StationTypeId);
                    }
                    else
                    {
                        stationassociatedstationtypeRepository.Delete(stationId, stationtype.StationTypeId);
                    }
                }

                if (types != null)
                {

                    foreach (int newtypeid in types)
                    {
                        if (associatedstationtypes.Where(t => t.StationTypeId == newtypeid).FirstOrDefault() == null)
                            stationassociatedstationtypeRepository.Add(stationId, (byte)newtypeid);
                    }
                }
                transaction.Complete();
                return true;
            }

        }

        #endregion
    }
}