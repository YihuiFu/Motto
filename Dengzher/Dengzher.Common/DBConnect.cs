using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Dengzher.Common
{
   public static class DBConnect
    {
       private static string connectString = @"Data Source=FU-PC\SQLEXPRESS;Initial Catalog=motto;User ID=sa;Password=261092";
       public static SqlConnection Connect()
       {
           SqlConnection con = new SqlConnection(connectString);
           return con;
       }
    }
}
