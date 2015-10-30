using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web;
using System.Net;
using USASMVC.Helpers;

namespace USASMVC.ExceptionHandling
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        //private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            if (filterContext.Exception is HttpAntiForgeryException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                string afgMessage = "Invalid post from URL" + filterContext.HttpContext.Request.Url.ToString();
                Logger.LogError("USAS - Antiforgery Error", afgMessage);
                return;
            }

            if (filterContext.Exception is HttpRequestValidationException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                string xssMessage = "Invalid request sent: " + filterContext.Exception.Message;
                Logger.LogError("USAS - XSS Error", xssMessage);
                return;
            }

            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            filterContext.Result = new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            string errMsg = "Error in Controller: " + controllerName + " Action: " + actionName + " Error: " + model.Exception.Message;
            Logger.LogError("USAS - Unhandled Error", errMsg);
            
        }
    }
}