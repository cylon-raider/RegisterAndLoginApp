using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services.Utility;
using System;

namespace RegisterAndLoginApp.Controllers
{
    internal class LogActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            UserModel userModel = (UserModel)((Controller)context.Controller).ViewData.Model;
            MyLogger.GetInstance().Info("Parameter: " + userModel.ToString());
            MyLogger.GetInstance().Info("Leaving the ProcessLogin method.");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            MyLogger.GetInstance().Info("Entering the ProcessLogin method.");
        }
    }
}