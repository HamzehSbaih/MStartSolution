using MStart.Common.Utilities;
using MStart.UIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using static MStart.Common.Enums;

namespace MStart.Controllers.Base
{
    public class BaseController : Controller
    {
        protected string CurrentUserName
        {
            get
            {
                var claims = HttpContext.Request.GetOwinContext().Authentication.User.Claims;
                return claims.Where(x => x.Type == MStart.Common.Constants.Claims.UserName).Single().Value;
            }
        }


        protected int CurrentID
        {
            get
            {
                var claims = HttpContext.Request.GetOwinContext().Authentication.User.Claims;
                return int.Parse(claims.Where(x => x.Type == MStart.Common.Constants.Claims.ID).Single().Value);

            }
        }
        protected Culture CurrentCulture
        {
            get
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.Contains(MStart.Common.Constants.Languages.Arabic.ToLower()))
                {
                    return MStart.Common.Enums.Culture.Arabic;
                }

                return MStart.Common.Enums.Culture.English;
            }
        }
        protected string CurrentUserEmail
        {
            get
            {
                var claims = HttpContext.Request.GetOwinContext().Authentication.User.Claims;
                return claims.Where(x => x.Type == MStart.Common.Constants.Claims.Email).Single().Value;
            }
        }
        public string UserMacAddress
        {
            get
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }
                return sMacAddress;
            }
        }

        protected List<IDisposable> ObjectsToCleanUp { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            LanguageSettingsHelper.SetCulture(RouteData);

        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            if (ObjectsToCleanUp != null)
            {
                foreach (var disposableObject in ObjectsToCleanUp)
                {
                    if (disposableObject != null)
                    {
                        try
                        {
                            disposableObject.Dispose();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }


            if (filterContext.HttpContext.Request.IsAjaxRequest())
                return;

            var redirectResult = filterContext.Result as RedirectToRouteResult;
            if (redirectResult == null)
                return;



            var query = filterContext.HttpContext.Request.QueryString;

            string key = "ReturnURL";
            if (query.AllKeys.Contains(key))
            {
                if (!redirectResult.RouteValues.ContainsKey("ReturnURL"))
                    redirectResult.RouteValues.Add(key, query[key]);
                else
                    redirectResult.RouteValues[key] = query[key];
            }

        }
        protected override void OnException(ExceptionContext filterContext)
        {
            if (AppSettings.DisableHandleWebExceptions)
            {
                //Tracer.Information($"{filterContext.Exception.Message}filterContext.Exception");
                base.OnException(filterContext);
            }
            else
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result =
                    filterContext.HttpContext.Request.IsAjaxRequest()
                    ? (ActionResult)Content(MStart.Common.App_LocalResources.Resource.GenericError)
                : (ActionResult)RedirectToAction("Index", "Errors");

                //Tracer.Information($"{filterContext.Exception.Message}filterContext.Exception");

                base.OnException(filterContext);


                if (filterContext.Exception.Message.StartsWith("24411 "))
                {
                    filterContext.Result =
                        filterContext.HttpContext.Request.IsAjaxRequest()
                            ? (ActionResult)Content(MStart.Common.App_LocalResources.Resource.YouAreNotAllowedToOpenThisTask)
                 : (ActionResult)RedirectToAction("Index", "Errors");
                }


                //Tracer.Information(string.Format("filterContext.Exception.ToString()\n {0}",
                    //filterContext.Exception.ToString()));

                //if (filterContext.Exception is System.Data.Entity.Validation.DbEntityValidationException)
                //{
                //    var e = filterContext.Exception as System.Data.Entity.Validation.DbEntityValidationException;

                //    foreach (var eve in e.EntityValidationErrors)
                //    {
                //        Tracer.Information(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //            eve.Entry.Entity.GetType().Name, eve.Entry.State));
                //        foreach (var ve in eve.ValidationErrors)
                //        {
                //            Tracer.Information(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                //                ve.PropertyName, ve.ErrorMessage));
                //        }
                //    }
                //}

                //Tracer.Information(string.Format("filterContext.Controller.ControllerContext.RequestContext.HttpContext.Request.RawUrl\n{0}\n",
                //   filterContext.Controller.ControllerContext.RequestContext.HttpContext.Request.RawUrl));
            }
        }
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            //disable caching
            if (filterContext.IsChildAction)
                return;

            var cache = filterContext.HttpContext.Response.Cache;
            cache.AppendCacheExtension("private");
            cache.SetNoStore();
            cache.SetCacheability(HttpCacheability.NoCache);
            cache.AppendCacheExtension("max-age=0");
            cache.AppendCacheExtension("post-check=0");
            cache.AppendCacheExtension("pre-check=0");
            cache.SetProxyMaxAge(TimeSpan.Zero);
            cache.SetExpires(DateTime.Now.AddYears(-5));
            cache.SetValidUntilExpires(false);
            cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        }
        /// <summary>
        /// create a delay on the page execution,
        ///  default to 2 seconds
        /// </summary>
        protected void Delay(int milliseconds = 2000)// 2 seconds.
        {
            System.Threading.Thread.Sleep(milliseconds);
        }



    }
}