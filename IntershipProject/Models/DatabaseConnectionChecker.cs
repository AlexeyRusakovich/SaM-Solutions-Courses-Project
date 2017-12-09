using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;

namespace IntershipProject.Models
{
    class DatabaseConnectionChecker
    {
        public async static Task<bool> IsConnected()
        {
                try
                {
                    SqlConnection cn;
                    String connectionString = "data source = localhost; initial catalog = Orders; integrated security = True;";
                    cn = new SqlConnection(connectionString);
                    if (cn.State == System.Data.ConnectionState.Closed)
                        await cn.OpenAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
        }
    }
}
