using MStart.DataAccess.Entities;
using MStart.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.DataAccess.CustomRepositories
{
    public class UserImageRepository : Repository<User>
    {
        public UserImageRepository(UnitOfWork uow) : base(uow) { }



    }
}
