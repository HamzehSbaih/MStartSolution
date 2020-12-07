using MStart.BusinessLogicLayer;
using MStart.Common.DTO_s;
using MStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MStart.Mapper
{
    public class AccountsMapper
    {
        private LookupsBusinessLogic _LookupsBusinessLogic;
        public AccountsMapper()
        {
            _LookupsBusinessLogic = new LookupsBusinessLogic();
        }
        #region Accounts Mapper
        public List<UserAccountViewModel> ConvertUserAccountsToWeb(List<AccountDTO> AccountsDto)
        {
            List<UserAccountViewModel> UserAccountsList = new List<UserAccountViewModel>();
            if (AccountsDto == null)
            {
                return UserAccountsList;
            }
            foreach (var UserAccount in AccountsDto)
            {
                var newUserAccount = new UserAccountViewModel()
                {
                    
                    Server_Date_Time = UserAccount.Server_Date_Time,
                    Update_DateTime_UTC = UserAccount.Update_DateTime_UTC,
                    ID = UserAccount.ID,
                    Account_Number=UserAccount.Account_Number,
                    Available_Balance=UserAccount.Available_Balance,
                    Balance=UserAccount.Balance,
                    Currency=UserAccount.Currency,
                    DateTime_UTC=UserAccount.DateTime_UTC,
                    NameAr=UserAccount.NameAr,
                    Status=UserAccount.Status,
                    User_ID=UserAccount.User_ID,
                
                };
                UserAccountsList.Add(newUserAccount);
            }
            return UserAccountsList;




        }
        public UserAccountViewModel ConvertUserAccountToWeb(AccountDTO UserAccount)
        {
            UserAccountViewModel UserAccounts = new UserAccountViewModel();
            if (UserAccount == null)
            {
                return UserAccounts;
            }
            UserAccounts = new UserAccountViewModel()
            {
                Server_Date_Time = UserAccount.Server_Date_Time,
                Update_DateTime_UTC = UserAccount.Update_DateTime_UTC,
                ID = UserAccount.ID,
                Account_Number = UserAccount.Account_Number,
                Available_Balance = UserAccount.Available_Balance,
                Balance = UserAccount.Balance,
                Currency = UserAccount.Currency,
                DateTime_UTC = UserAccount.DateTime_UTC,
                NameAr = UserAccount.NameAr,
                Status = UserAccount.Status,
                User_ID = UserAccount.User_ID,
            };

            return UserAccounts;
        }
        public AccountDTO ConvertUserAccountToBLL(UserAccountViewModel model)
        {
            AccountDTO UserAccounts = new AccountDTO();
            if (model == null)
            {
                return UserAccounts;
            }
            UserAccounts = new AccountDTO()
            {
                Server_Date_Time = model.Server_Date_Time,
                Update_DateTime_UTC = model.Update_DateTime_UTC,
                ID = model.ID,
                Account_Number = model.Account_Number,
                Available_Balance = model.Available_Balance,
                Balance = model.Balance,
                Currency = model.Currency,
                DateTime_UTC = model.DateTime_UTC,
                NameAr = model.NameAr,
                Status = model.Status,
                User_ID = model.User_ID,

            };
            return UserAccounts;
        }
        public List<AccountDTO> ConvertUserAccountToBLL(List<UserAccountViewModel> model)
        {
            List<AccountDTO> UserAccountsList = new List<AccountDTO>();
            if (model == null)
            {
                return UserAccountsList;
            }
            foreach (var UserAccount in model)
            {
                var newUserAccount = new AccountDTO()
                {
                    Server_Date_Time = UserAccount.Server_Date_Time,
                    Update_DateTime_UTC = UserAccount.Update_DateTime_UTC,
                    ID = UserAccount.ID,
                    Account_Number = UserAccount.Account_Number,
                    Available_Balance = UserAccount.Available_Balance,
                    Balance = UserAccount.Balance,
                    Currency = UserAccount.Currency,
                    DateTime_UTC = UserAccount.DateTime_UTC,
                    NameAr = UserAccount.NameAr,
                    Status = UserAccount.Status,
                    User_ID = UserAccount.User_ID,
                };
                UserAccountsList.Add(newUserAccount);
            }
            return UserAccountsList;
        }
        #endregion
    }
}