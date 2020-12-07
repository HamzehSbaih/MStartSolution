using MStart.DataAccess.Entities;
using MStart.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.DataAccess.CustomRepositories
{
    public class AspNetUserRepository : Repository<AspNetUser>
    {
        public AspNetUserRepository(UnitOfWork uow) : base(uow) { }

        public string GetUserIdByUserName(string UserName)
        {

            var userId = GetQuerable(x => x.UserName == UserName).FirstOrDefault().Id;

            if (!String.IsNullOrEmpty(userId))
            {
                return userId;
            }
            {
                return "";
            }
        }

    }
}
