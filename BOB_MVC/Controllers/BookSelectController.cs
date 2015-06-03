//使用Models資料夾的檔案
using BOB_MVC.Models;
/*------------------------------*/
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOB_MVC.Controllers
{
    public class BookSelectController : Controller
    {
        //
        // GET: /Book/

        public ActionResult Index()
        {
            BookModel m = new BookModel();                       
            return View(m);
            
        }
        public ActionResult BookSelectALL()
        {
            BookModel m = new BookModel();
            DataTable dt = m.GetBook();
            return View(dt);
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(FormCollection fc)
        {
            string bookname = fc["bookname"];
            string author = fc["author"];
            int  price = Int16.Parse( fc["price"]);
            string publisher = fc["publisher"];
            BookModel m = new BookModel();
            m.InsertBook(bookname, author, price, publisher);
            return RedirectToAction("BookSelectALL");
        }
        public ActionResult Delete_page()/*刪除頁面*/
        {
            // no = HttpUtility.UrlDecode(Request.Url.AbsolutePath.Split('/').Last().ToString());
            BookModel m = new BookModel();
            return View(m);
        }
        public ActionResult Delete(int id)/*執行刪除功能*/
        {
            (new BookModel()).DeleteBook(id);
            return RedirectToAction("BookSelectALL");
        }
        public ActionResult Edit(int id)
        {
            BookModel m = new BookModel();
            DataRow row = m.GetBookByID(id);
            BookModel.BookEditModel em = new BookModel.BookEditModel()
            {
                id = row["id"].ToString(),
                bookname = row["bookname"].ToString(),
                author = row["author"].ToString(),
                price = Int16.Parse( row["price"].ToString()),
                publisher=row["publisher"].ToString()
            };
            return View(em);
        }
        [HttpPost]
        public ActionResult Edit( BookModel.BookEditModel em, int id)
        {
            (new BookModel()).UpdateBook(em, id);
            return RedirectToAction("BookSelectALL");
        }

        public ActionResult BookSelectByBookName(string bookname)
        {
            bookname = HttpUtility.UrlDecode(Request.Url.AbsolutePath.Split('/').Last().ToString());
            BookModel m = new BookModel();
            DataTable dt = m.GetBookStoreByBookName(bookname);
            return View(dt);
        }
        public ActionResult BookSelectByAuthor(string Author)
        {
            Author = HttpUtility.UrlDecode(Request.Url.AbsolutePath.Split('/').Last().ToString());
            BookModel m = new BookModel();
            DataTable dt = m.GetBookStoreByAuthor(Author);
            return View(dt);
        }
        public ActionResult BookSelectByPrice(string Price)
        {
            Price = HttpUtility.UrlDecode(Request.Url.AbsolutePath.Split('/').Last().ToString());
           
            BookModel m = new BookModel();
            DataTable dt = m.GetBookStoreByPrice(Price);
            return View(dt);
        }
        public ActionResult BookSelectByPublisher(string Publisher)
        {
            Publisher = HttpUtility.UrlDecode(Request.Url.AbsolutePath.Split('/').Last().ToString());
            BookModel m = new BookModel();
            DataTable dt = m.GetBookStoreByPublisher(Publisher);
            return View(dt);
        }
        private NameValueCollection GetQueryParameters(string dataWithQuery)
        {
            return HttpUtility.ParseQueryString(dataWithQuery);
        }

        

    }
}
