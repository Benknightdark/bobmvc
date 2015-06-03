using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOB_MVC.Controllers
{
    public class BOBController : Controller
    {
        //
        // GET: /BOB/
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BookStore()
        {
            return View();
        }
        public ActionResult Book()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
    }
}
