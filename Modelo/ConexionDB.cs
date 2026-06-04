using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Applogin1.Modelo
{
    public class ConexionDB
    {
        private static string CadenaConexion =
            "Server=localhost;Port=3306;Database=app_login_csharp;User=root;Password=1012;";

        public static MySqlConnection GetConexion()
        {
            MySqlConnection conn = new MySqlConnection(CadenaConexion);
            conn.Open();
            return conn;
        }

        public static bool ProbarConexion()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CadenaConexion))
                {
                    conn.Open();
                    MessageBox.Show("Conectado correctamente");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión:\n" + ex.Message);
                return false;
            }
        }
    }
}
