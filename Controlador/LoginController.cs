using Applogin1;
using Applogin1.Modelo;
using System;
using System.Windows.Forms;

namespace Applogin1.Controlador
{
    public class LoginController
    {
        private readonly UsuarioDAO _dao = new UsuarioDAO();

        public void ProcesarLogin(string usuario, string contrasena, FrmLogin vista)
        {
            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                vista.SetEstado("Ingresa usuario y contraseña.");
                return;
            }

            try
            {
                if (_dao.EstasBloqueado(usuario))
                {
                    MessageBox.Show(
                        "Esta cuenta está bloqueada por múltiples intentos fallidos.",
                        "Cuenta bloqueada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                Usuario u = _dao.Login(usuario, contrasena);

                if (u != null)
                {
                    MessageBox.Show("Login correcto");

                    FrmBienvenida bienvenida = new FrmBienvenida(u);
                    bienvenida.Show();

                    vista.Hide();
                }
                else
                {
                    vista.SetEstado("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en login:\n" + ex.Message);
            }
        }
    }
}