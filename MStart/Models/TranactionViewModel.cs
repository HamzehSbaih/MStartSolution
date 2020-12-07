using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MStart.Models
{
    public class TranactionViewModel
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Account_ID { get; set; }
        public DateTime Server_Date_Time { get; set; }
        public DateTime DateTime_UTC { get; set; }
        public bool Is_Credit { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int[] empids { get; set; }
    }
}