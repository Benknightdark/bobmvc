using BOB_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace BOB_MVC.Controllers
{
    public class BookStoreSelectController : Controller
    {
       
        
        //
        // GET: /BookStoreSelect/
       
        public ActionResult Index()
        {
            BookStoreModel m = new BookStoreModel();
            DataTable dt = m.GetBookStore();

          
            return View(m);
        }
     
        public ActionResult BookStore_Name_Option()
        {
            BookStoreModel m = new BookStoreModel();
            DataTable dt = m.GetBookStoreByName_option();
            return View(dt);
        }
        public ActionResult BookStore_Rank_Option()
        {
            BookStoreModel m = new BookStoreModel();
            DataTable dt = m.GetBookStoreByRank_option();
            return View(dt);
        }
        public ActionResult BookStore_City_Option()
        {
            BookStoreModel m = new BookStoreModel();
            DataTable dt = m.GetBookStoreByCity_option();
            return View(dt);
        }

        public ActionResult BookStoreSelectALL()
        {


            BookStoreModel m = new BookStoreModel();
            DataTable dt = m.GetBookStore();

            return View(dt);
        }
     
        
         public ActionResult Delete_page()/*刪除頁面*/
        {
           
            BookStoreModel m = new BookStoreModel();
            return View(m);
        }
        public ActionResult Delete(int id)/*執行刪除功能*/
        {
            (new BookStoreModel()).DeleteBookStore(id);
            return RedirectToAction("BookStoreSelectALL");
        }

        public ActionResult BookStoreSelectByName(string name)
        {
            
            name = HttpUtility.UrlDecode(Request.Url.AbsolutePath.Split('/').Last().ToString());
          
           BookStoreModel m = new BookStoreModel();

           DataTable dt = m.GetBookStoreByName(name);

            return View(dt);
        }

        public ActionResult BookStoreSelectByRank(string rank)
        {
            rank = HttpUtility.UrlDecode(Request.Url.AbsolutePath.Split('/').Last().ToString());
            BookStoreModel m = new BookStoreModel();
            DataTable dt = m.GetBookStoreByRank(rank);
            return View(dt);
        }
        public ActionResult BookStoreSelectByCity(string city)
        {
            city = HttpUtility.UrlDecode(Request.Url.AbsolutePath.Split('/').Last().ToString());
            BookStoreModel m = new BookStoreModel();
            DataTable dt = m.GetBookStoreByCity(city);
            return View(dt);
        }
        
       

        
       
      

        public ActionResult Edit(int id)
        {
            BookStoreModel empM = new BookStoreModel();
            DataRow row = empM.GetBookStoreByID(id);
            EditModel em = new EditModel()
            {
                no = row["no"].ToString(),
                name = row["name"].ToString(),
                city = row["city"].ToString(),
                rank = row["rank"].ToString()
            };
            return View(em);
        }
        [HttpPost]
        public ActionResult Edit(EditModel em, int id)
        {
            (new BookStoreModel()).UpdateBookStore(em, id);
            return RedirectToAction("BookStoreSelectALL");
        }
        public ActionResult Insert()
        {
            return View();
        }
             
          [HttpPost] 
        public ActionResult Insert(FormCollection fc)
        {
            BookStoreModel m = new BookStoreModel();
            DataTable dt = m.GetBookStore();
           string name = fc["name"];
            string rank = fc["rank"];
            string city = fc["city"];
            
            m.InsertBookStore(name, rank, city);
            return RedirectToAction("BookStoreSelectALL");
              
        }


       



       

        
        

    }
}
