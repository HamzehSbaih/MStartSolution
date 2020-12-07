using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.Common
{
    public class Constants
    {
        public class Languages
        {
            public const string Arabic = "Ar";
            public const string English = "En";
        }

        public class Claims
        {
            public const string ID = "ID";
            public const string UserName = "UserName";
            public const string AccountTypeId = "AccountTypeId";
            public const string FirstNameAr = "FirstNameAr";
            public const string LastNameAr = "LastNameAr";
            public const string FirstNameEn = "FirstNameEn";
            public const string LastNameEn = "LastNameEn";
            public const string UserStatus = "UserStatus";
            public const string Email = "Email";
            public const string Nationality = "Nationality";
        }
        public class UserRoles
        {
            public const string RegisteredUser = "RegisteredUser";
            public const string Admin = "Admin";
            public const string Employee = "Employee";
            public const string AnonymousUser = "AnonymousUser";
        }

        public class ErrorsCodes
        {
            public const int UnhandledException = -101;
            public const int LookupDoesNotExist = -200;
            public const int NotificationDoesNotExist = -201;
            public const int SettingsGroupNameDoesNotExits = -202;
        }


        public class Gender
        {
            public const string Male = "Male";
            public const string Female = "Female";
        }
    }
}
