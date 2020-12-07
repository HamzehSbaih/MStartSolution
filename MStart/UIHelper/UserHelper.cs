using MStart.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MStart.Common.Constants;
using static MStart.Common.Enums;

namespace MStart.UIHelper
{
    public class UserHelper
    {
        public static UserType GetUserType(List<string> roles)
        {
            var userType = UserType.Anonymous;

            var rolesLowered =
                roles.Select(x => x.Trim().ToLower())
                .ToList();

            if (rolesLowered.Contains(UserRoles.Admin.ToLower()))
                userType = UserType.Administrator;
            else if (rolesLowered.Contains(UserRoles.RegisteredUser.ToLower()))
                userType = UserType.Registerd;

            else if (rolesLowered.Contains(UserRoles.AnonymousUser.ToLower()))
                userType = UserType.Anonymous;

            return userType;
        }


        private static UserType GetUserType(string username)
        {

            UsersBusinessLogic userRoles = new UsersBusinessLogic();

            var roles =
                userRoles.GetRolesByUserName(username)
                .Select(x => x.TrimEnd().ToLower());

            var userType = GetUserType(roles.ToList());

            return userType;

        }

    }
}