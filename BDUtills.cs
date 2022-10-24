using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabota4
{
    class BDUtills
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "37.77.105.162";
            string db = "University";
            int port = 3306;
            string user = "Lyuts";
            string pass = "meox9AKR@";

            return BD.GetConnection(host, db, port, user, pass);
        }
    }
}
