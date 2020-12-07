namespace MStart.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Accounts = new HashSet<Account>();
            Tranactions = new HashSet<Tranaction>();
        }

        public int ID { get; set; }

        public DateTime Server_Date_Time { get; set; }

        public DateTime DateTime_UTC { get; set; }

        public DateTime Update_DateTime_UTC { get; set; }

        [Required]
        [StringLength(50)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Last_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Mobile_Number { get; set; }

        public int Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public int? PhotoId { get; set; }

        [StringLength(128)]
        public string AspNetUserId { get; set; }

        [Required]
        [StringLength(50)]
        public string First_Name_AR { get; set; }

        [Required]
        [StringLength(50)]
        public string Last_Name_AR { get; set; }

        [Required]
        [StringLength(50)]
        public string Address_AR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Lookup Lookup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tranaction> Tranactions { get; set; }

        public virtual UserImage UserImage { get; set; }
    }
}
