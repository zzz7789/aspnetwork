using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPwork.Controllers
{
    public class topicController : System.Web.Mvc.Controller
    {
        // GET: Zone
        public ActionResult list(int subject)
        {
            ViewBag.subject = subject;
            return View();
        }

        [Filler.userfiller]
        public ActionResult Post()
        {

            return View();
        }

        [HttpPost]
        [Filler.userfiller]
        public ActionResult Post(string title,string content)
        {
            return View();
        }
    }
}