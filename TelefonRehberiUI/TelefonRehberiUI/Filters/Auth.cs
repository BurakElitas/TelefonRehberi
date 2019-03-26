using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberiUI.Models;

namespace TelefonRehberiUI.Filters
{
    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(CurrentSession.Admin==null)
            {
               filterContext.Result = new RedirectResult("/Admin/Login");
            }
        }
    }
}