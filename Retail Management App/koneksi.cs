using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Retail_Management_App
{
    class koneksi
    {
        public static MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=retail_management");
    }
}
