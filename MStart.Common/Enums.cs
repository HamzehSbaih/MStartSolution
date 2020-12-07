using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.Common
{
    public class Enums
    {
        public enum CultureID
        {
            Ar = 1,
            En = 2,
        }

        public enum Culture
        {
            Arabic = 9,
            English = 10
        }
        public enum UserType
        {
            Administrator = 2,
            Authority = 3,
            Registerd = 1,
            Anonymous = 5
        }
        public enum UserRole
        {
            RegisteredUser = 1,
            Admin = 2,
            Employee = 3,
            AnonymousUser = 4,
        }

    }
}
