using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MStart.Attributes
{
    public class HandleException : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

          

            var result = new ViewResult()
            {
                ViewName = "~/Views/Errors/index.cshtml"
            };

            result.TempData["Error"] = filterContext.Exception;

            filterContext.Result = result;
            filterContext.ExceptionHandled = true;
        }
    }
}