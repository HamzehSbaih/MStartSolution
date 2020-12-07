using MStart.Common.DTO_s;
using MStart.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.BusinessLogicLayer
{
   public class UsersAccountsBusinessLogic
    {
        public bool AddAccount(AccountDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var EmployeeAdded = uow.Accounts.AddAccount(dto);
                    if (EmployeeAdded != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("AddTransactions", "An error occurred while trying to create AddEmployee Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public bool EditAccounts(AccountDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var EmployeeUpdated = uow.Accounts.EditAccount(dto);
                    if (EmployeeUpdated != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("EditAccounts", "An error occurred while trying to create EditEmployee Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public bool DeleteAccount(int AccountId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var DeletedEmployee = uow.Accounts.DeleteAccount(AccountId);
                    if (DeletedEmployee != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("DeleteAccount", "An error occurred while trying to create DeleteEmployee Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public bool DeleteAccounts(int[] accounts)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var BaseQuestionAdded = uow.Accounts.DeleteAccounts(accounts);
                    if (BaseQuestionAdded != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("DeleteAccounts", "An error occurred while trying to create DeleteAccounts Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public AccountDTO GetAccount(int accountId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var employee = uow.Accounts.GetAccount(accountId);
                    if (employee != null)
                    {
                        return employee;
                    }
                    else
                    {
                        return employee;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetAccount", "An error occurred while trying to create GetAccount Record - BLL");
                    uow.Rollback();
                    return null;
                }
            }
        }
        public List<AccountDTO> GetAccounts(out int totalRecords, int page = 1, int pageSize = 10)
        {
            totalRecords = 0;
            List<AccountDTO> emps = new List<AccountDTO>();
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var accounts = uow.Accounts.GetAccounts();
                    if (accounts != null)
                    {
                        totalRecords = accounts.Count();
                        accounts = accounts.OrderByDescending(x => x.ID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize).ToList();
                        return accounts.ToList();
                    }
                    else
                    {
                        return accounts;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetAccounts", "An error occurred while trying to create GetAccounts Record - BLL");
                    uow.Rollback();
                    return emps;
                }
            }
        }
    }
}
