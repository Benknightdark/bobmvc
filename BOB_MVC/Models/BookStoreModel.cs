using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//處理表格資料的套件
using System.Data;
using System.Data.Common;
//連結sql server的套件
using System.Data.SqlClient;
//查詢語法Linq的套件
using System.Linq;
//呼叫Web.Config檔裡參數的套件
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
//MVC套件
using System.Web.Mvc;

namespace BOB_MVC.Models
{
    public class BookStoreModel
    {
        public DataTable GetBookStore()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from bookstores order by no ",
          WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            
            DataTable dt = new DataTable();
            
            da.Fill(dt);
            return dt;
        }
        /*--------------------------------------刪除功能function------------------------------------------*/
        public DataTable GetBookStoreCascade()/*查詢bookstores表格有關的外來鍵規則*/
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "exec sp_fkeys bookstores",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
       
        public DataTable GetBookStoreByNo(int id)/*回傳與no相符的bookstores表格*/
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select * from bookstores where no = @id",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetOrdersNo(int id)/*回傳與no相符的orders表格*/
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select * from orders where no = @id",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void DeleteBookStore(int id)/*執行刪除功能*/
        {
            SqlConnection cn = new SqlConnection(
              WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(
              "begin "+                
                "delete from orders where no=@no "+
                "delete from bookstores where no=@no "+
                "end"
                , cn);
            cmd.Parameters.AddWithValue("no", id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
      /*---------------------------------------------------------------------*/

        
        public DataRow GetBookStoreByID(int id)/*進行更新用的function*/
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select * from bookstores where no = @id",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];
        }
       public DataTable GetBookStoreByName(string name)
        {
            
            SqlDataAdapter da = new SqlDataAdapter(
              "select * from bookstores where name = @name",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("name", name);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
       public DataTable GetBookStoreByRank(string rank)
       {

           SqlDataAdapter da = new SqlDataAdapter(
             "select * from bookstores where rank = @rank",
     WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
           da.SelectCommand.Parameters.AddWithValue("rank", rank);
           DataTable dt = new DataTable();
           da.Fill(dt);
           return dt;
       }
       public DataTable GetBookStoreByCity(string city)
       {

           SqlDataAdapter da = new SqlDataAdapter(
             "select * from bookstores where city = @city",
     WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
           da.SelectCommand.Parameters.AddWithValue("city", city);
           DataTable dt = new DataTable();
           da.Fill(dt);
           return dt;
       }

        public void UpdateBookStore(EditModel em, int id)
        {
            SqlConnection cn = new SqlConnection(
              WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand(
                "UPDATE bookstores SET  name = @name,rank=@rank,city=@city WHERE no = @no", cn);

            cmd.Parameters.AddWithValue("no", id);
            cmd.Parameters.AddWithValue("name", em.name);
            cmd.Parameters.AddWithValue("rank", em.rank);
            cmd.Parameters.AddWithValue("city", em.city);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void InsertBookStore( string name, string rank,string city)
        {
            SqlConnection cn = new SqlConnection(
              WebConfigurationManager.
              ConnectionStrings["socialstreamConnectionString"].
              ConnectionString);
            SqlCommand cmd = new SqlCommand(
              "Insert into bookstores Values(@name , @rank , @city)",
              cn);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("rank", rank);
            cmd.Parameters.AddWithValue("city", city);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public DataTable GetBookStoreByName_option()
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select distinct(name) as name from bookstores",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);            
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBookStoreByRank_option()
        {

            SqlDataAdapter da = new SqlDataAdapter(
              "select distinct(rank) as rank  from bookstores ",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetBookStoreByCity_option()
        {
            SqlDataAdapter da = new SqlDataAdapter(
              "select distinct(city) as city from bookstores ",
      WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);
           
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        

    }
    public class EditModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Key]
        [Display(Name = "書局編號")]
        public string no { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "書局名稱")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "書局居住地")]
        public string city { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "書局排名")]
        public string rank { get; set; }

    }


}