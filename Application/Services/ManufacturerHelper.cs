using System.Collections.Generic;
using System.Linq;
using Manufacturer = Pathway.Data.Models.Operative.Manufacturer;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ManufacturerHelper
    /// </summary>
    public class ManufacturerHelper
    {
        public ManufacturerHelper()
        {

        }

        /// <summary>
        /// GetAllDistinct operation
        /// </summary>
        public ManufacturerListDataContract GetAllDistinct()
        {
            using (var unitOfWork = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {

                var manufacturerRepository = ManufacturerRepository.New(unitOfWork);

                var results = manufacturerRepository.GetActive();

                var manufacturerListDataContract = new ManufacturerListDataContract();

                var manufacturers = results.Select(x => new ManufacturerDataContract
                {
                    ManufacturerId = x.ManufacturerId,
                    Name = x.Name

                });
                manufacturerListDataContract.Manufacturers = new List<ManufacturerDataContract>();
                manufacturerListDataContract.Manufacturers.AddRange(manufacturers);

                return manufacturerListDataContract;

            }
        }

        /// <summary>
        /// GetbyId operation
        /// </summary>
        public ManufacturerDataContract GetbyId(int Id)
        {
            {
                var manufacturerRepository = ManufacturerRepository.New(unitOfWork);

                var result = manufacturerRepository.Repository.Find(x => x.ManufacturerId == Id).FirstOrDefault();

                if (result == null) return null;

                return new ManufacturerDataContract
                {
                    ManufacturerId = result.ManufacturerId,
                    Name = result.Name
                };
            }
        }

        /// <summary>
        /// Save operation
        /// </summary>
        public int Save(ManufacturerDataContract manufacturer)
        {
            {
                var manufacturerRepository = ManufacturerRepository.New(unitOfWork);

                var data = ManufacturerFactory.CreateEntity(unitOfWork,
                    manufacturerId: manufacturer.ManufacturerId,
                    name: manufacturer.Name  //may need to strip this of spaces and extra characters
                );
                manufacturerRepository.Add(data);
                manufacturerRepository.Save();

                return data.ManufacturerId;
            }
        }
    }
}