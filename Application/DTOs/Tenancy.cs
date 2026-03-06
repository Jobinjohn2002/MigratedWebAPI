using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Tenancy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TenancyFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Tenancy()
        {
            this.OwnersInTenancy = new HashSet<Owner>();
            this.TenancyCustomValue = new HashSet<TenancyCustomValue>();
            this.TenancySetting = new HashSet<TenancySetting>();
            this.User = new HashSet<User>();
            this.CustomerGroup = new HashSet<CustomerGroup>();
            this.CustomStationeryLogic = new HashSet<CustomStationeryLogic>();
            this.NotificationRules = new HashSet<NotificationRule>();
            this.Surgeon = new HashSet<Surgeon>();
            this.SurgicalProcedureType = new HashSet<SurgicalProcedureType>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TenancyId
        /// </summary>
        public int TenancyId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets OwnerId
        /// </summary>
        public Nullable<int> OwnerId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets OwnersInTenancy
        /// </summary>
        public virtual ICollection<Owner> OwnersInTenancy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TenancyCustomValue
        /// </summary>
        public virtual ICollection<TenancyCustomValue> TenancyCustomValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TenancySetting
        /// </summary>
        public virtual ICollection<TenancySetting> TenancySetting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual ICollection<User> User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CustomerGroup
        /// </summary>
        public virtual ICollection<CustomerGroup> CustomerGroup { get; set; }
        /// <summary>
        /// Gets or sets TenancyOwner
        /// </summary>
        public virtual Owner TenancyOwner { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CustomStationeryLogic
        /// </summary>
        public virtual ICollection<CustomStationeryLogic> CustomStationeryLogic { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets NotificationRules
        /// </summary>
        public virtual ICollection<NotificationRule> NotificationRules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Surgeon
        /// </summary>
        public virtual ICollection<Surgeon> Surgeon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SurgicalProcedureType
        /// </summary>
        public virtual ICollection<SurgicalProcedureType> SurgicalProcedureType { get; set; }
    }
}
