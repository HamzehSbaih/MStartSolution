using MStart.BusinessLogicLayer;
using MStart.Controllers.Base;
using MStart.Mapper;
using MStart.Models;
using MStart.UIHelper.PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MStart.Controllers
{
    public class TransactionController : BaseController
    {
        private UsersBusinessLogic _UsersBusinessLogic;
        private AccountsBusinessLogic _AccountsBusinessLogic;
        private LookupsBusinessLogic _LookupsBusinessLogic;
        private TransactionsBusinessLogic _TransactionsBusinessLogic;
        private TransactionsMapper mapper;
        public TransactionController()
        {
            _UsersBusinessLogic = new UsersBusinessLogic();
            _AccountsBusinessLogic = new AccountsBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
            _TransactionsBusinessLogic = new TransactionsBusinessLogic();
            mapper = new TransactionsMapper();
        }
        [HttpGet]
        public ActionResult Index(int totalRecords = 0, int page = 1, int pageSize = 10)
        {
            var Transactions = mapper.ConvertTransactionsToWeb(_TransactionsBusinessLogic.GetTransactions(out totalRecords,
                                                        page,
                                                        pageSize));
            TranactionUIViewModel model = new TranactionUIViewModel();
            List<TranactionViewModel> List = new List<TranactionViewModel>();
            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");
            List = Transactions;
            var pagedList = List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);
            model.Tranactions = pagedList;
            return View(model);
        }
        public ActionResult LoadResultsPage(int page = 1)
        {
            int totalRecords;
            var pagedList = GetList(out totalRecords, page, 10);
            // get the corresponding page for the results table            
            return PartialView("~/Views/Shared/Partials/_EmployeesList.cshtml", pagedList);
        }
        private IEnumerable<TranactionViewModel> GetList(out int totalRecords, int page = 1, int pageSize = 10)
        {
            List<TranactionViewModel> List = new List<TranactionViewModel>();
            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");

            var Employees = mapper.ConvertTransactionsToWeb(_TransactionsBusinessLogic.GetTransactions(out totalRecords,
                                                        page,
                                                        pageSize));
            List = Employees;
            return List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);
        }
        [HttpGet]
        public ActionResult AddTranaction(int AccountId)
        {
            TranactionViewModel model = new TranactionViewModel();
            model.DateTime_UTC = DateTime.UtcNow;
            model.Server_Date_Time = DateTime.Now;
            model.Account_ID = AccountId;

            return View(model);
        }
        [HttpPost]
        public ActionResult AddTranaction(TranactionViewModel model)
        {

            bool isAdded = _TransactionsBusinessLogic.AddTransactions(mapper.ConvertTransactionToBLL(model));
            if (isAdded == true)
            {
                TempData["Success"] = MStart.Common.App_LocalResources.Resource.UpdateSucces;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = MStart.Common.App_LocalResources.Resource.UpdateFailed;
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult EditTranaction(int TranactionId)
        {
            TranactionViewModel model = new TranactionViewModel();

            model = mapper.ConvertTransactionToWeb(_TransactionsBusinessLogic.GetTransaction(TranactionId));
            return View(model);
        }
        [HttpPost]
        public ActionResult EditTranaction(TranactionViewModel model)
        {
            bool isupdated = _TransactionsBusinessLogic.EditTransactions(mapper.ConvertTransactionToBLL(model));
            if (isupdated == true)
            {
                TempData["Success"] = MStart.Common.App_LocalResources.Resource.UpdateSucces;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = MStart.Common.App_LocalResources.Resource.UpdateFailed;
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult DeleteTranaction(int TranactionId)
        {
            bool isdeleted = _UsersBusinessLogic.DeleteUser(TranactionId);
            if (isdeleted == true)
            {
                TempData["Success"] = MStart.Common.App_LocalResources.Resource.DeleteSucces;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = MStart.Common.App_LocalResources.Resource.DeleteFailed;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Index(TranactionViewModel model)
        {

            bool isdeleted = _TransactionsBusinessLogic.DeleteTransactions(model.empids);
            if (isdeleted == true)
            {
                TempData["Success"] = MStart.Common.App_LocalResources.Resource.DeleteSucces;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = MStart.Common.App_LocalResources.Resource.DeleteFailed;
                return RedirectToAction("Index");
            }


        }
    }
}