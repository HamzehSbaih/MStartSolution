using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.Common.DTO_s
{
    public class AccountDTO
    {
        public int ID { get; set; }

        public int User_ID { get; set; }

        public string NameAr { get; set; }

        public DateTime Server_Date_Time { get; set; }

        public DateTime DateTime_UTC { get; set; }

        public DateTime Update_DateTime_UTC { get; set; }

        public string Account_Number { get; set; }

        public decimal Balance { get; set; }

        public decimal Available_Balance { get; set; }

        public string Currency { get; set; }

        public int Status { get; set; }

        public  List<TranactionDTO> Tranactions { get; set; }

    }
}
