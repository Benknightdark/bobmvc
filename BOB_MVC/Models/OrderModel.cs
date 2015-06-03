using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BOB_MVC.Models
{
    public class OrderModel
    {
        public DataTable GetOrder()
        {
            SqlDataAdapter da = new SqlDataAdapter("select b.bookname ,c.name,a.quantity from  orders a ,books b ,bookstores c where b.id=a.id and c.no=a.no order by a.quantity desc  ",
          WebConfigurationManager.ConnectionStrings["socialstreamConnectionString"].ConnectionString);

            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }
    }
}