namespace MStart.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tranaction
    {
        public int ID { get; set; }

        public int User_ID { get; set; }

        public int Account_ID { get; set; }

        public DateTime Server_Date_Time { get; set; }

        public DateTime DateTime_UTC { get; set; }

        public bool Is_Credit { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Currency { get; set; }

        public virtual Account Account { get; set; }

        public virtual User User { get; set; }
    }
}
