using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BOB_MVC.Models
{
    public class BookModel
    {
        public DataTable GetBook()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from books order by id ",
          WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);

            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }
        public void InsertBook(string bookname, string authoer, int price,string publisher)
        {
            SqlConnection cn = new SqlConnection(
              WebConfigurationManager.
              ConnectionStrings["socialstreamConnectionString"].
              ConnectionString);
            SqlCommand cmd = new SqlCommand(
              "Insert into books Values(@bookname , @authoer , @price,@publisher)",
              cn);
            cmd.Parameters.AddWithValue("bookname", bookname);
            cmd.Parameters.AddWithValue("authoer", authoer);
            cmd.Parameters.AddWithValue("price", price);
            cmd.Parameters.AddWithValue("publisher", publisher);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        

        public DataRow GetBookByID(int id)/*執行更新用的function*/
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select * from books where id = @id",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];
        }


        public void UpdateBook(BookEditModel em, int id)
        {
            SqlConnection cn = new SqlConnection(
              WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand(
                "UPDATE books SET  bookname = @bookname,author=@author,price=@price,publisher=@publisher WHERE id = @id", cn);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("bookname", em.bookname);
            cmd.Parameters.AddWithValue("author", em.author);
            cmd.Parameters.AddWithValue("price", em.price);
            cmd.Parameters.AddWithValue("publisher", em.publisher);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public class BookEditModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Key]
            [Display(Name = "書籍編號")]
            public string id { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "書籍名稱")]
            public string bookname { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "作者")]
            public string author { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "價格")]
            public int price { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "出版社")]
            public string publisher { get; set; }

        }

        public DataTable GetBookStoreByBookName(string BookName)
        {

            SqlDataAdapter da = new SqlDataAdapter(
              "select * from books where bookname = @bookname",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("bookname", BookName);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBookStoreByAuthor(string Author)
        {

            SqlDataAdapter da = new SqlDataAdapter(
              "select * from books where author = @author",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("author", Author);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBookStoreByPrice(string Price)
        {

            SqlDataAdapter da = new SqlDataAdapter(
              "select * from books where price= @price",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            
            da.SelectCommand.Parameters.AddWithValue("price", Price);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBookStoreByPublisher(string Publisher)
        {

            SqlDataAdapter da = new SqlDataAdapter(
              "select * from books where publisher = @publisher",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("publisher", Publisher);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBookByBookName_option()
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select distinct(bookname) from books",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBookByAuthor_option()
        {
            SqlDataAdapter da = new SqlDataAdapter(
             "select distinct(author) from books",
     WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
          
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBookByPrice_option()
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select distinct(price) from books",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBookByPublisher_option()
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select distinct(publisher) from books",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        /*--------------------------------------刪除功能function------------------------------------------*/
        public DataTable GetBookCascade()/*查詢books表格有關的外來鍵規則*/
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "exec sp_fkeys books",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetBookId(int id)/*回傳與no相符的books表格*/
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select * from books where id = @id",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetOrdersId(int id)/*回傳與id相符的orders表格*/
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select * from orders where id = @id",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void DeleteBook(int id)/*執行刪除功能*/
        {
            SqlConnection cn = new SqlConnection(
              WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(
              "begin " +
                "delete from orders where id=@id " +
                "delete from books where id=@id " +
                "end"
                , cn);
            cmd.Parameters.AddWithValue("id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        /*---------------------------------------------------------------------*/

    }

}