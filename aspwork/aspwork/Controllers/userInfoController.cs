using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPwork.Controllers
{
    public class userInfoController : System.Web.Mvc.Controller
    {
        // GET: userInfo
        [Filler.userfiller]
        public ActionResult Index()
        {
            return View();
        }
    }
}