using MStart.BusinessLogicLayer;
using MStart.Controllers.Base;
using MStart.Mapper;
using MStart.Models;
using MStart.UIHelper.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MStart.Controllers
{
    public class UserAccountController : BaseController
    {
        
        private AccountsBusinessLogic _AccountsBusinessLogic;
        private LookupsBusinessLogic _LookupsBusinessLogic;
        private TransactionsBusinessLogic _TransactionsBusinessLogic;
        private UsersAccountsBusinessLogic _UsersAccountsBusinessLogic;
        private AccountsMapper mapper;
        public UserAccountController()
        {
            _UsersAccountsBusinessLogic = new UsersAccountsBusinessLogic();
            _AccountsBusinessLogic = new AccountsBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
            _TransactionsBusinessLogic = new TransactionsBusinessLogic();
            mapper = new AccountsMapper();
        }
        [HttpGet]
        public ActionResult Index(int totalRecords = 0, int page = 1, int pageSize = 10)
        {
            var UserAccounts = mapper.ConvertUserAccountsToWeb(_UsersAccountsBusinessLogic.GetAccounts(out totalRecords,
                                                        page,
                                                        pageSize));
            UserAccountUIViewModel model = new UserAccountUIViewModel();
            List<UserAccountViewModel> List = new List<UserAccountViewModel>();
            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");
            List = UserAccounts;
            var pagedList = List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);
            model.UserAccounts = pagedList;
            return View(model);
        }
        public ActionResult LoadResultsPage(int page = 1)
        {
            int totalRecords;
            var pagedList = GetList(out totalRecords, page, 10);
            // get the corresponding page for the results table            
            return PartialView("~/Views/Shared/Partials/_AccountsList.cshtml", pagedList);
        }
        private IEnumerable<UserAccountViewModel> GetList(out int totalRecords, int page = 1, int pageSize = 10)
        {
            List<UserAccountViewModel> List = new List<UserAccountViewModel>();
            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");

            var accounts = mapper.ConvertUserAccountsToWeb(_UsersAccountsBusinessLogic.GetAccounts(out totalRecords,
                                                        page,
                                                        pageSize));
            List = accounts;
            return List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);
        }
        [HttpGet]
        public ActionResult AddAccount(int UserId)
        {
            UserAccountViewModel model = new UserAccountViewModel();
            model.DateTime_UTC = DateTime.UtcNow;
            model.Update_DateTime_UTC = DateTime.UtcNow;
            model.Server_Date_Time = DateTime.Now;
            model.User_ID = UserId;
            model.statuses = _LookupsBusinessLogic.GetLookupsByLookupCategoryCode("Status", base.CurrentCulture);

            return View(model);
        }
        [HttpPost]
        public ActionResult AddAccount(UserAccountViewModel model)
        {

            bool isAdded = _UsersAccountsBusinessLogic.AddAccount(mapper.ConvertUserAccountToBLL(model));
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
        public ActionResult EditAccount(int AccountId)
        {
            UserAccountViewModel model = new UserAccountViewModel();

            model = mapper.ConvertUserAccountToWeb(_UsersAccountsBusinessLogic.GetAccount(AccountId));
            model.ID = AccountId;
            model.statuses = _LookupsBusinessLogic.GetLookupsByLookupCategoryCode("Status", base.CurrentCulture);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditAccount(UserAccountViewModel model)
        {
            bool isupdated = _UsersAccountsBusinessLogic.EditAccounts(mapper.ConvertUserAccountToBLL(model));
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
        public ActionResult DeleteAccount(int AccountId)
        {
            bool isdeleted = _UsersAccountsBusinessLogic.DeleteAccount(AccountId);
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
        public ActionResult Index(UserAccountViewModel model)
        {

            bool isdeleted = _UsersAccountsBusinessLogic.DeleteAccounts(model.empids);
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