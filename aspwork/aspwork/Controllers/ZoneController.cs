using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPwork.Controllers
{
    public class ZoneController : Controller
    {
        // GET: Zone
        public ActionResult Index()
        {
            return View();
        }

        [Filler.userfiller]
        public ActionResult Post()
        {
            return View();
        }
    }
}