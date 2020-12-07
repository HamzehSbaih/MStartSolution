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
    public class TransactionsRepository : Repository<Tranaction>
    {
        public TransactionsRepository(UnitOfWork uow) : base(uow) { }
        public bool AddTransaction(TranactionDTO dto)
        {
            try
            {
                var record = new Tranaction()
                {
                    Account_ID=dto.Account_ID,
                    Amount=dto.Amount,
                    Currency=dto.Currency,
                    DateTime_UTC=dto.DateTime_UTC,
                    Is_Credit=dto.Is_Credit,
                    Server_Date_Time=dto.Server_Date_Time,
                    User_ID=dto.User_ID,

                };

                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddTransaction", "An error occurred while trying to  AddTransaction Record - DAL");

                _uow.Rollback();
                return false;
            }
        }
        public bool EditTransaction(TranactionDTO dto)
        {
            try
            {
                var record = GetQuerable(x => x.ID == dto.ID).FirstOrDefault();
                record.Account_ID = dto.Account_ID;
                record.Amount = dto.Amount;
                record.Currency = dto.Currency;
                record.DateTime_UTC = dto.DateTime_UTC;
                record.Is_Credit = dto.Is_Credit;
                record.Server_Date_Time = dto.Server_Date_Time;

                Update(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("EditTransaction", "An error occurred while trying to Edit Transaction Record - DAL");

                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteTransaction(int TransactionId)
        {
            try
            {
                var record = GetQuerable(x => x.ID == TransactionId).FirstOrDefault();

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
                ex.Data.Add("DeleteTransaction", "An error occurred while trying to Delete Transaction Record - DAL");

                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteTransactions(int[] emplyees)
        {
            try
            {

                List<Tranaction> gettrnsids = new List<Tranaction>();
                gettrnsids = _db.Tranactions.Where(x => emplyees.Contains(x.ID)).ToList();

                foreach (var s in gettrnsids)
                {
                    _db.Tranactions.Remove(s);

                }
                _uow.Save();
                return true;

            }
            catch (Exception ex)
            {
                ex.Data.Add("DeleteTransactions", "An error occurred while trying to Delete Transactions Records - DAL");

                _uow.Rollback();
                return false;
            }
        }
        public TranactionDTO GetTransaction(int TransactionId)
        {
            try
            {
                var record = GetQuerable(x => x.ID == TransactionId).Select(u => new TranactionDTO()
                {
                    Account_ID=u.Account_ID,
                    Amount=u.Amount,
                    Currency=u.Currency,
                    DateTime_UTC=u.DateTime_UTC,
                    ID=u.ID,
                    Server_Date_Time=u.Server_Date_Time,
                    Is_Credit=u.Is_Credit,
                    User_ID=u.User_ID
                }).FirstOrDefault();

                return record;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetTransaction ", "An error occurred while trying to GetTransaction record  in DAL ");

                _uow.Rollback();
                return null;
            }
        }
        public List<TranactionDTO> GetTransactions()
        {
            try
            {
                var record = GetQuerable(x => x.ID > 0).Select(u => new TranactionDTO()
                {
                    Account_ID = u.Account_ID,
                    Amount = u.Amount,
                    Currency = u.Currency,
                    DateTime_UTC = u.DateTime_UTC,
                    ID = u.ID,
                    Server_Date_Time = u.Server_Date_Time,
                    Is_Credit = u.Is_Credit,
                    User_ID = u.User_ID
                }).ToList();
                if (record != null && record.Count > 0)
                {
                    return record;
                }
                return null;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetTransactions ", "An error occurred while trying to GetTransactions records  in DAL ");

                _uow.Rollback();
                return null;
            }
        }
    }
}
