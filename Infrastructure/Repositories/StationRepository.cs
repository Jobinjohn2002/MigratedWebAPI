using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// StationRepository
    /// </summary>
    /// <remarks></remarks>
    public partial class StationRepository
    {
        /// <summary>
        /// Gets the specified station id.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public Station Get(int stationId)
        {
            return Repository.Find(station => station.StationId == stationId).FirstOrDefault();
        }

        /// <summary>
        /// GetMany operation
        /// </summary>
        public IEnumerable<Station> GetMany(List<int> stationIds)
        {
            return Repository.Find(station => stationIds.Any(stid => stid == station.StationId)).Include("StationType");
        }

        /// <summary>
        /// Gets the specified nt logon.
        /// </summary>
        /// <param name="ntLogon">The nt logon.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public Station Get(string ntLogon)
        {
            return Repository.Find(station => station.NTLogon == ntLogon).FirstOrDefault();
        }

        /// <summary>
        /// Reads the available station by nt logon.
        /// </summary>
        /// <param name="ntLogon">The nt logon.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadAvailableStationByNtLogon operation
        /// </summary>
        public Station ReadAvailableStationByNtLogon(string ntLogon)
        {
            return Repository.Find(station => station.NTLogon == ntLogon && station.Archived == null).FirstOrDefault();
        }

        /// <summary>
        /// Reads the associated station types.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadAssociatedStationTypes operation
        /// </summary>
        public IQueryable<StationType> ReadAssociatedStationTypes(int stationId)
        {
            return Repository.Find(station => station.StationId == stationId).SelectMany(
                station => station.StationTypes).OrderBy(stationType => stationType.DisplayOrder);
        }

        /// <summary>
        /// Reads the associated delivery points.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadAssociatedDeliveryPoints operation
        /// </summary>
        public IQueryable<DeliveryPoint> ReadAssociatedDeliveryPoints(int stationId)
        {
            return Repository.Find(station => station.StationId == stationId).SelectMany(
                station => station.StationDeliveryPoints).OrderBy(deliveryPoint => deliveryPoint.DeliveryPointId);
        }

        /// <summary>
        /// Gets all machine types by station.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <param name="isSteriliser">if set to <c>true</c> [is steriliser].</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllMachineTypesByStation operation
        /// </summary>
        public IQueryable<MachineType> GetAllMachineTypesByStation(int stationId, bool isSteriliser)
        {
            IQueryable<MachineType> machineTypes =
                Repository.Find(s => s.StationId == stationId).Select(s => s.Machine).SelectMany(
                    m => m.Select(mt => mt.MachineType)).Where(mt => mt.IsSteriliser == isSteriliser).Distinct();
            return machineTypes;
        }

        /// <summary>
        /// Gets all machines by station.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <param name="machineType">Type of the machine.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllMachinesByStation operation
        /// </summary>
        public IQueryable<Machine> GetAllMachinesByStation(int stationId, int machineType)
        {
            IQueryable<Machine> machinestation =
                Repository.Find(s => s.StationId == stationId).SelectMany(s => s.Machine).Where(
                    m => m.MachineTypeId == machineType && m.Archived == null);

            var machineRepository = MachineRepository.New(Repository.UnitOfWork);
            IQueryable<Machine> machines = machineRepository.All();

            return (from machine in machines
                    join ms in machinestation on machine.MachineId equals ms.MachineId
                    select machine);
        }

        /// <summary>
        /// Gets all machines by station.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <param name="isSteriliser">if set to <c>true</c> [is steriliser].</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllMachinesByStation operation
        /// </summary>
        public IQueryable<Machine> GetAllMachinesByStation(int stationId, bool isSteriliser)
        {
            IQueryable<Machine> machines =
                Repository.Find(s => s.StationId == stationId).SelectMany(s => s.Machine).Where(
                    m => m.Archived == null && m.MachineType.IsSteriliser == isSteriliser);
            return machines;
        }

        /// <summary>
        /// Gets all sterilised machines by station.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <param name="isSteriliser">if set to <c>true</c> [is steriliser].</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllSterilisedMachinesByStation operation
        /// </summary>
        public IQueryable<Machine> GetAllSterilisedMachinesByStation(int stationId, bool isSteriliser)
        {
            IQueryable<Machine> machinestation =
                Repository.Find(s => s.StationId == stationId).SelectMany(s => s.Machine).Where(
                    m => m.Archived == null && m.MachineType.IsSteriliser == isSteriliser);

            var machineRepository = MachineRepository.New(Repository.UnitOfWork);
            IQueryable<Machine> machines = machineRepository.All();

            return (from machine in machines
                    join ms in machinestation on machine.MachineId equals ms.MachineId
                    select machine);
        }

        /// <summary>
        /// Gets all machines stations by station.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllMachinesStationsByStation operation
        /// </summary>
        public IQueryable<Machine> GetAllMachinesStationsByStation(int stationId)
        {
            IQueryable<Machine> machines =
                Repository.Find(s => s.StationId == stationId).SelectMany(s => s.Machine).Where(
                    m => m.Archived == null);
            return machines;
        }

        /// <summary>
        /// Gets all machines by station.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllMachinesByStation operation
        /// </summary>
        public IQueryable<Machine> GetAllMachinesByStation(int stationId)
        {
            IQueryable<Machine> machinestation =
                Repository.Find(s => s.StationId == stationId).SelectMany(s => s.Machine).Where(m => m.Archived == null);

            var machineRepository = MachineRepository.New(Repository.UnitOfWork);
            IQueryable<Machine> machines = machineRepository.All();

            return (from machine in machines
                    join ms in machinestation on machine.MachineId equals ms.MachineId
                    select machine);
        }

        /// <summary>
        /// Reads the stations by facility.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadStationsByFacility operation
        /// </summary>
        public IQueryable<Station> ReadStationsByFacility(short facilityId)
        {
            return Repository.Find(s => s.FacilityId == facilityId && s.Archived == null);
        }

        /// <summary>
        /// Reads the printers by station.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadPrintersByStation operation
        /// </summary>
        public IQueryable<StationPrinter> ReadPrintersByStation(int stationId)
        {
            return Get(stationId).StationPrinter.Where(sp => sp.Printer.Archived == null).AsQueryable();
        }

        /// <summary>
        /// Finds the facilities by station.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// FindFacilitiesByStation operation
        /// </summary>
        public IQueryable<IFacility> FindFacilitiesByStation(int stationId)
        {
            return Repository.Find(s => s.StationId == stationId).Select(station => station.Facility);
        }

        /// <summary>
        /// ReadAdminStationByFacility operation
        /// </summary>
        public Station ReadAdminStationByFacility(int facilityId)
        {
            return Repository.Find(s => s.FacilityId == facilityId && s.StationTypeId == (int)StationTypeIdentifier.Admin && s.Archived == null).FirstOrDefault();
        }

        /// <summary>
        /// Validate NT Logon uniqueness
        /// </summary>
        /// <param name="ntLogon">NT Logon of Station</param>
        /// <param name="stationId"></param>
        /// <returns>bool</returns>
        /// <remarks></remarks>
        /// <summary>
        /// ValidateUniqueNTLogonForStation operation
        /// </summary>
        public bool ValidateUniqueNTLogonForStation(string ntLogon, int stationId)
        {
            if (stationId > 0)
            {
                var result = Repository.Find(station => station.NTLogon == ntLogon && station.Archived == null && station.StationId != stationId);
                if (result.Count() > 0)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return Repository.Find(station => station.NTLogon.ToLower() == ntLogon.ToLower() && station.Archived == null).Count() == 0;
            }
        }

        /// <summary>
        /// Get processing facility Id by Station Id
        /// </summary>
        /// <param name="StationId">StationId</param>
        /// <returns>Facility</returns>
        /// <summary>
        /// GetFacilityByStationId operation
        /// </summary>
        public int GetFacilityByStationId(int stationid)
        {
            return Repository.Find(s => s.StationId == stationid).FirstOrDefault().FacilityId;
        }

        /// <summary>
        /// GetAersByStation operation
        /// </summary>
        public IEnumerable<Machine> GetAersByStation(int stationId, int? machineId = null)
        {
            var station = Repository.Find(s => s.StationId == stationId).Single();

            return station.Machine.Where(machine => machine.ArchivedUserId == null && machine.MachineTypeId == (int)MachineTypeIdentifier.Aer && (machineId == null || machine.MachineId == machineId.Value));
        }

        /// <summary>
        /// GetVacPackMachinesByStation operation
        /// </summary>
        public IEnumerable<Machine> GetVacPackMachinesByStation(int stationId, int? machineId = null)
        {
            var station = Repository.Find(s => s.StationId == stationId).Single();

            return station.Machine.Where(machine => machine.ArchivedUserId == null && machine.MachineTypeId == (int)MachineTypeIdentifier.VacuumPacker && (machineId == null || machine.MachineId == machineId.Value));
        }
    }
}