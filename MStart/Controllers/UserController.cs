using MStart.BusinessLogicLayer;
using MStart.Common.DTO_s;
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
    public class UserController : BaseController
    {
        private UsersBusinessLogic _UsersBusinessLogic;
        private AccountsBusinessLogic _AccountsBusinessLogic;
        private LookupsBusinessLogic _LookupsBusinessLogic;
        private UsersMapper mapper;
        public UserController()
        {
            _UsersBusinessLogic = new UsersBusinessLogic();
            _AccountsBusinessLogic = new AccountsBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
            mapper = new UsersMapper();
        }
        [HttpGet]
        public ActionResult Index(int totalRecords = 0, int page = 1, int pageSize = 10)
        {
            var Users = mapper.ConvertUsersToWeb(_UsersBusinessLogic.GetUsers(out totalRecords,
                                                        page,
                                                        pageSize));
            UserUIViewModel model = new UserUIViewModel();
            List<UsersViewModel> List = new List<UsersViewModel>();
            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");
            List = Users;
            var pagedList = List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);
            model.Users = pagedList;
            return View(model);
        }
        public ActionResult LoadResultsPage(int page = 1)
        {
            int totalRecords;
            var pagedList = GetList(out totalRecords, page, 10);
            // get the corresponding page for the results table            
            return PartialView("~/Views/Shared/Partials/_EmployeesList.cshtml", pagedList);
        }
        private IEnumerable<UsersViewModel> GetList(out int totalRecords, int page = 1, int pageSize = 10)
        {
            List<UsersViewModel> List = new List<UsersViewModel>();
            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");

            var Employees = mapper.ConvertUsersToWeb(_UsersBusinessLogic.GetUsers(out totalRecords,
                                                        page,
                                                        pageSize));
            List = Employees;
            return List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            UsersViewModel model = new UsersViewModel();
            model.genders = _LookupsBusinessLogic.GetLookupsByLookupCategoryCode("Gender", base.CurrentCulture);
            model.DateTime_UTC = DateTime.UtcNow;
            model.Update_DateTime_UTC = DateTime.UtcNow;
            model.Server_Date_Time = DateTime.Now;

            return View(model);
        }
        [HttpPost]
        public ActionResult AddUser(UsersViewModel model)
        {

            bool isAdded = _UsersBusinessLogic.AddUser(mapper.ConvertUserToBLL(model));
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
        public ActionResult EditUser(int UserId)
        {
            UsersViewModel model = new UsersViewModel();

            model = mapper.ConvertUserToWeb(_UsersBusinessLogic.GetUser(UserId));
            model.genders = _LookupsBusinessLogic.GetLookupsByLookupCategoryCode("Gender", base.CurrentCulture);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditUser(UsersViewModel model)
        {
            bool isupdated = _UsersBusinessLogic.EditUser(mapper.ConvertUserToBLL(model));
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
        public ActionResult DeleteUser(int EmployeeId)
        {
            bool isdeleted = _UsersBusinessLogic.DeleteUser(EmployeeId);
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
        [HttpGet]
        public ActionResult AddImage(int UserId)
        {
            UsersImageViewModel model = new UsersImageViewModel();
            model.UserId = UserId;

            return PartialView("~/Views/Shared/Partials/_Images.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddUserImage(int EmployeeId)
        {
            UsersImageViewModel model = new UsersImageViewModel();
            model.UserId = EmployeeId;
            if (EmployeeId > 1)
            {
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].FileName != "")
                    {
                        string fileName = Request.Files[upload].FileName;
                        string contentType = Request.Files[upload].ContentType;
                        long fileLength = Request.Files[upload].InputStream.Length;
                        byte[] fileContent = new byte[fileLength];

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            Request.Files[upload].InputStream.CopyTo(memoryStream);

                            fileContent = memoryStream.ToArray();
                            var image = Image.FromStream(memoryStream);

                            var ratioX = (double)350 / image.Width;
                            var ratioY = (double)200 / image.Height;
                            var ratio = Math.Min(ratioX, ratioY);

                            var width = (int)(image.Width * ratio);
                            var height = (int)(image.Height * ratio);

                            var newImage = new Bitmap(width, height);
                            Graphics.FromImage(newImage).DrawImage(image, 0, 0, width, height);
                            Bitmap bmp = new Bitmap(newImage);

                            ImageConverter converter = new ImageConverter();

                            fileContent = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

                        }
                        //string directory = Server.MapPath("/Image/");
                        HttpPostedFileBase photo = Request.Files["ImageFile"];
                        string ImagePath = "";
                        if (photo != null && photo.ContentLength > 0)
                        {
                            var PhfileName = Path.GetFileName(photo.FileName);
                            //var path = Path.Combine(directory, PhfileName);
                            //photo.SaveAs(path);
                            ImagePath = "~/Image/" + PhfileName;
                        }
                        UserImageDTO dto = new UserImageDTO();
                        dto.EmployeeId = EmployeeId;
                        dto.file_stream = fileContent;
                        dto.ContentType = contentType;
                        dto.FileNameWithExtension = fileName;
                        int saved = _UsersBusinessLogic.AddImages(dto);
                    }
                    TempData["Success"] = MStart.Common.App_LocalResources.Resource.Success;
                }
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Success"] = MStart.Common.App_LocalResources.Resource.Error;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Index(UsersViewModel model)
        {

            bool isdeleted = _UsersBusinessLogic.DeleteUsers(model.empids);
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