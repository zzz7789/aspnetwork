using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPwork.Filler
{
    public class userfiller:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["username"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Account/login");
             }
        }
    }
}