using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInstruments.Models;

namespace WebInstruments.Filters
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            User user = (User)HttpContext.Current.Session["User"];

            if ((filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                && user != null
                && user.Role.HasAccess)
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller
                return;
            }

            else if (HttpContext.Current.Session["User"] != null)
            {
                return;
            }

            else
            {
                filterContext.Result = filterContext.Result = new HttpUnauthorizedResult();
                return;
            }
        }
    }
}