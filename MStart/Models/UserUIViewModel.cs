using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MStart.Models
{
    public class UserUIViewModel
    {
        public IEnumerable<UsersViewModel> Users { get; set; }
    }
}