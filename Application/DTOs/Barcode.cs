using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using SynergyApplicationFrameworkApi.Application.Interfaces;
//using SynergyApplicationFrameworkApi.Application.Services;
//using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
using static SynergyApplicationFrameworkApi.Application.DTOs.Constants;
using SynergyApplicationFrameworkApi.Application.DTOs.ContainerInstanceAsset;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Barcode
    /// </summary>
    public class Barcode
    {
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public Turnaround Turnaround { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public ContainerInstance ContainerInstance { get; set; }
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public ContainerMaster ContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public DeliveryPoint DeliveryPoint { get; set; }

        /// <summary>
        /// Gets or sets ContainerInstances
        /// </summary>
        public List<ContainerInstanceDetailsModel> ContainerInstances { get; set; }
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public List<Turnaround> Turnarounds { get; set; }        
        /// <summary>
        /// Gets or sets ContainerInstanceTableModel
        /// </summary>
        public TableModel ContainerInstanceTableModel { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundTableModel
        /// </summary>
        public TableModel TurnaroundTableModel { get; set; }
    }
}