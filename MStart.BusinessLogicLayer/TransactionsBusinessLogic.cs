using MStart.Common.DTO_s;
using MStart.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.BusinessLogicLayer
{
    public class TransactionsBusinessLogic
    {
        public string GetUserIdByUserName(string UserName)
        {

            using (var uow = new UnitOfWork())
            {
                string UserId = uow.AspNetUser.GetUserIdByUserName(UserName);
                return UserId;
            }

        }
        public bool AddTransactions(TranactionDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    dto.User_ID = uow.Accounts.getUserIdBuUserAccountId(dto.Account_ID);
                    var EmployeeAdded = uow.Transactions.AddTransaction(dto);
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
        public bool EditTransactions(TranactionDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var EmployeeUpdated = uow.Transactions.EditTransaction(dto);
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
                    ex.Data.Add("EditTransactions", "An error occurred while trying to create EditEmployee Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public bool DeleteTransaction(int EmployeeId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var DeletedEmployee = uow.Users.DeleteUser(EmployeeId);
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
                    ex.Data.Add("DeleteTransaction", "An error occurred while trying to create DeleteEmployee Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public bool DeleteTransactions(int[] emplyees)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var BaseQuestionAdded = uow.Transactions.DeleteTransactions(emplyees);
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
                    ex.Data.Add("DeleteTransactions", "An error occurred while trying to create DeleteEmployees Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public TranactionDTO GetTransaction(int EmployeeId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var employee = uow.Transactions.GetTransaction(EmployeeId);
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
                    ex.Data.Add("GetTransaction", "An error occurred while trying to create GetEmployee Record - BLL");
                    uow.Rollback();
                    return null;
                }
            }
        }
        public List<TranactionDTO> GetTransactions(out int totalRecords, int page = 1, int pageSize = 10)
        {
            totalRecords = 0;
            List<TranactionDTO> emps = new List<TranactionDTO>();
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var users = uow.Transactions.GetTransactions();
                    if (users != null)
                    {
                        totalRecords = users.Count();
                        users = users.OrderByDescending(x => x.ID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize).ToList();
                        return users.ToList();
                    }
                    else
                    {
                        return users;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetTransactions", "An error occurred while trying to create GetEmployees Record - BLL");
                    uow.Rollback();
                    return emps;
                }
            }
        }
    }
}
