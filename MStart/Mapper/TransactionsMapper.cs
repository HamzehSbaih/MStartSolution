using MStart.BusinessLogicLayer;
using MStart.Common.DTO_s;
using MStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MStart.Mapper
{
    public class TransactionsMapper
    {
        private LookupsBusinessLogic _LookupsBusinessLogic;
        public TransactionsMapper()
        {
            _LookupsBusinessLogic = new LookupsBusinessLogic();
        }
        #region Transactions Mapper
        public List<TranactionViewModel> ConvertTransactionsToWeb(List<TranactionDTO> TransactionsDto)
        {
            List<TranactionViewModel> TransactionsList = new List<TranactionViewModel>();
            if (TransactionsDto == null)
            {
                return TransactionsList;
            }
            foreach (var Transaction in TransactionsDto)
            {
                var newTransaction = new TranactionViewModel()
                {
                    Account_ID = Transaction.Account_ID,
                    Amount = Transaction.Amount,
                    User_ID = Transaction.User_ID,
                    Currency = Transaction.Currency,
                    DateTime_UTC = Transaction.DateTime_UTC,
                    ID = Transaction.ID,
                    Is_Credit = Transaction.Is_Credit,
                    Server_Date_Time = Transaction.Server_Date_Time,
                };
                TransactionsList.Add(newTransaction);
            }
            return TransactionsList;




        }
        public TranactionViewModel ConvertTransactionToWeb(TranactionDTO Transaction)
        {
            TranactionViewModel Transactions = new TranactionViewModel();
            if (Transaction == null)
            {
                return Transactions;
            }
            Transactions = new TranactionViewModel()
            {
                Account_ID = Transaction.Account_ID,
                Amount = Transaction.Amount,
                User_ID = Transaction.User_ID,
                Currency = Transaction.Currency,
                DateTime_UTC = Transaction.DateTime_UTC,
                ID = Transaction.ID,
                Is_Credit = Transaction.Is_Credit,
                Server_Date_Time = Transaction.Server_Date_Time,
            };

            return Transactions;
        }
        public TranactionDTO ConvertTransactionToBLL(TranactionViewModel model)
        {
            TranactionDTO Transactions = new TranactionDTO();
            if (model == null)
            {
                return Transactions;
            }
            Transactions = new TranactionDTO()
            {
                Account_ID = model.Account_ID,
                Amount = model.Amount,
                User_ID = model.User_ID,
                Currency = model.Currency,
                DateTime_UTC = model.DateTime_UTC,
                ID = model.ID,
                Is_Credit = model.Is_Credit,
                Server_Date_Time = model.Server_Date_Time,
            };
            return Transactions;
        }
        public List<TranactionDTO> ConvertTransactionToBLL(List<TranactionViewModel> model)
        {
            List<TranactionDTO> TransactionsList = new List<TranactionDTO>();
            if (model == null)
            {
                return TransactionsList;
            }
            foreach (var Transaction in model)
            {
                var newTransaction = new TranactionDTO()
                {
                    Account_ID = Transaction.Account_ID,
                    Amount = Transaction.Amount,
                    User_ID = Transaction.User_ID,
                    Currency = Transaction.Currency,
                    DateTime_UTC = Transaction.DateTime_UTC,
                    ID = Transaction.ID,
                    Is_Credit = Transaction.Is_Credit,
                    Server_Date_Time = Transaction.Server_Date_Time,
                };
                TransactionsList.Add(newTransaction);
            }
            return TransactionsList;
        }
        #endregion
    }
}