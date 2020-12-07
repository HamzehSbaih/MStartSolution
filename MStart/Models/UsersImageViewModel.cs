using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MStart.Models
{
    public class UsersImageViewModel
    {
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public byte[] file_stream { get; set; }
    }
}