using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.Common.DTO_s
{
    public class UserDTO
    {
        public int ID { get; set; }
        public int Department_ID { get; set; }
        public DateTime Server_Date_Time { get; set; }
        public DateTime DateTime_UTC { get; set; }
        public DateTime Update_DateTime_UTC { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Mobile_Number { get; set; }
        public string UserImage { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public int? PhotoId { get; set; }
        public string AspNetUserId { get; set; }
        public string First_Name_AR { get; set; }
        public string Last_Name_AR { get; set; }
        public string Address_AR { get; set; }
        public List<AccountDTO> Accounts { get; set; }

        public UserImageDTO image { get; set; }
    }
}
