using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace RegisterAndLoginApp.Controllers
{

    internal class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userName = context.HttpContext.Session.GetString("username");

            if (userName == null)
            {
                // session username is not set. Deny access by sending them to the /login screen
                context.Result = new RedirectResult("/login");
            }
            else
            {
                // do nothing. Let the filter pass the request through since the user IS logged in.
            }

        }
    }
}