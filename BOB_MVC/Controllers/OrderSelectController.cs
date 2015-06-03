using BOB_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOB_MVC.Controllers
{
    public class OrderSelectController : Controller
    {
        //
        // GET: /OrderSelect/

        public ActionResult Index()
        {
            OrderModel m = new OrderModel();
            DataTable dt = m.GetOrder();

            return View(dt);
            
        }
        public ActionResult OrderSelectALL()
        {


            OrderModel m = new OrderModel();
            DataTable dt = m.GetOrder();

            return View(dt);
            
        }

    }
}
