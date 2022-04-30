using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using RegisterAndLoginApp.Services.Utility;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorization]
        public IActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("I am a protected method if the proper attribute is applied to me");
        }

        [LogActionFilter]
        public IActionResult ProcessLogin(UserModel userModel)
        {
            //MyLogger.GetInstance().Info("Entering the ProcessLogin method.");

            // records the user who attempts to login
            //MyLogger.GetInstance().Info("Parameter: " + userModel.ToString());

            SecurityService securityService = new SecurityService();


            //   if (userModel.UserName == "Chris")
            //      System.Diagnostics.Debugger.Break();

            if (securityService.IsValid(userModel))
            {
                MyLogger.GetInstance().Info("Login success.");
                // remember who is logged in
                HttpContext.Session.SetString("username", userModel.UserName);
                //MyLogger.GetInstance().Info("Leaving the ProcessLogin Method.");
                return View("LoginSuccess", userModel);
            }

            else
            {
                MyLogger.GetInstance().Warning("Login failure.");
                //MyLogger.GetInstance().Info("Leaving the ProcessLogin Method.");
                // cancel any existing valid login
                HttpContext.Session.Remove("username");
                return View("LoginFailure", userModel);
            }

        }
    }
}
