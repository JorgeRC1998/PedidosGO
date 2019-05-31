using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class ConexionDB
    {
        private static ConexionDB objConexionDB = null;
        private SqlConnection con;

        private ConexionDB()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-VK5MQEUU\SQLEXPRESS;Initial Catalog=Pedidos;Integrated Security=True");
        }

        public static ConexionDB saberEstado()
        {
            if (objConexionDB == null)
            {
                objConexionDB = new ConexionDB();

            }
            return objConexionDB;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void closeDB()
        {
            objConexionDB = null;
        }
    }
}
