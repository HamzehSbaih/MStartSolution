namespace MStart.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Tranactions = new HashSet<Tranaction>();
        }

        public int ID { get; set; }

        public int User_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NameAr { get; set; }

        public DateTime Server_Date_Time { get; set; }

        public DateTime DateTime_UTC { get; set; }

        public DateTime Update_DateTime_UTC { get; set; }

        [Required]
        [StringLength(50)]
        public string Account_Number { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Column(TypeName = "money")]
        public decimal Available_Balance { get; set; }

        [Required]
        [StringLength(50)]
        public string Currency { get; set; }

        public int Status { get; set; }

        public virtual Lookup Lookup { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tranaction> Tranactions { get; set; }
    }
}
