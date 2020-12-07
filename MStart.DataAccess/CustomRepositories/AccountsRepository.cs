using MStart.Common.DTO_s;
using MStart.DataAccess.Entities;
using MStart.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.DataAccess.CustomRepositories
{
    public class AccountsRepository : Repository<Account>
    {
        public AccountsRepository(UnitOfWork uow) : base(uow) { }
        public bool AddAccount(AccountDTO dto)
        {
            try
            {
                var record = new Account()
                {
                    Account_Number = dto.Account_Number,
                    Balance = dto.Balance,
                    Currency = dto.Currency,
                    DateTime_UTC = dto.DateTime_UTC,
                    Server_Date_Time = dto.Server_Date_Time,
                    Available_Balance=dto.Available_Balance,
                    NameAr=dto.NameAr,
                    Status=dto.Status,
                    User_ID=dto.User_ID,
                    Update_DateTime_UTC=DateTime.Now,
                };

                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddAccount", "An error occurred while trying to  AddAccount Record - DAL");

                _uow.Rollback();
                return false;
            }
        }
        public bool EditAccount(AccountDTO dto)
        {
            try
            {
                var record = GetQuerable(x => x.ID == dto.ID).FirstOrDefault();
                record.Account_Number = dto.Account_Number;
                record.Balance = dto.Balance;
                record.Currency = dto.Currency;
                record.DateTime_UTC = DateTime.Now;
                record.Server_Date_Time = DateTime.Now;
                record.Available_Balance = dto.Available_Balance;
                record.NameAr = dto.NameAr;
                record.Status = dto.Status;
                record.User_ID = dto.User_ID;
                record.Update_DateTime_UTC = DateTime.Now;
                
                Update(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("EditAccount", "An error occurred while trying to Edit Account Record - DAL");

                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteAccount(int AccountId)
        {
            try
            {
                var record = GetQuerable(x => x.ID == AccountId).FirstOrDefault();
                if (record != null)
                {
                    Delete(record);
                    _uow.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("DeleteAccount", "An error occurred while trying to Delete Account Record - DAL");

                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteAccounts(int[] accounts)
        {
            try
            {

                List<Account> getempids = new List<Account>();
                getempids = _db.Accounts.Where(x => accounts.Contains(x.ID)).ToList();

                foreach (var s in getempids)
                {
                    _db.Accounts.Remove(s);

                }
                _uow.Save();
                return true;

            }
            catch (Exception ex)
            {
                ex.Data.Add("DeleteAccounts", "An error occurred while trying to Delete Accounts Records - DAL");

                _uow.Rollback();
                return false;
            }
        }
        public AccountDTO GetAccount(int AccountId)
        {
            try
            {
                var record = GetQuerable(x => x.ID == AccountId).Select(u => new AccountDTO()
                {
                    Currency = u.Currency,
                    DateTime_UTC = u.DateTime_UTC,
                    ID = u.ID,
                    Server_Date_Time = u.Server_Date_Time,
                    User_ID = u.User_ID,
                    Account_Number=u.Account_Number,
                    Available_Balance=u.Available_Balance,
                    Balance=u.Balance,
                    NameAr=u.NameAr,
                    Status=u.Status,
                    Update_DateTime_UTC=u.Update_DateTime_UTC
                }).FirstOrDefault();

                return record;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetAccount ", "An error occurred while trying to GetAccount record  in DAL ");

                _uow.Rollback();
                return null;
            }
        }
        public List<AccountDTO> GetAccounts()
        {
            try
            {
                var record = GetQuerable(x => x.ID > 0).Select(u => new AccountDTO()
                {
                    Currency = u.Currency,
                    DateTime_UTC = u.DateTime_UTC,
                    ID = u.ID,
                    Server_Date_Time = u.Server_Date_Time,
                    User_ID = u.User_ID,
                    Account_Number = u.Account_Number,
                    Available_Balance = u.Available_Balance,
                    Balance = u.Balance,
                    NameAr = u.NameAr,
                    Status = u.Status,
                    Update_DateTime_UTC = u.Update_DateTime_UTC
                }).ToList();
                if (record != null && record.Count > 0)
                {
                    return record;
                }
                return null;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetAccounts ", "An error occurred while trying to GetAccounts records  in DAL ");

                _uow.Rollback();
                return null;
            }
        }


        public int getUserIdBuUserAccountId(int AccountId)
        {
            return GetQuerable(x => x.ID == AccountId).FirstOrDefault().User_ID;
        }
    }
}
