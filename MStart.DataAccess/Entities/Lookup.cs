namespace MStart.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lookup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lookup()
        {
            Accounts = new HashSet<Account>();
            LookupCultures = new HashSet<LookupCulture>();
            Users = new HashSet<User>();
            Lookups1 = new HashSet<Lookup>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public int CategoryId { get; set; }

        [StringLength(100)]
        public string LookupCode { get; set; }

        public bool IsActive { get; set; }

        public bool IsInternal { get; set; }

        public int? LOrder { get; set; }

        public int? Sequance { get; set; }

        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }

        public virtual LookupCategory LookupCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LookupCulture> LookupCultures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lookup> Lookups1 { get; set; }

        public virtual Lookup Lookup1 { get; set; }
    }
}
