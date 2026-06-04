using Applogin1;
using Applogin1.Modelo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AppLoginMVC.Controlador
{
    public class RegistroController
    {
        private readonly UsuarioDAO _dao = new UsuarioDAO();

        public void ProcesarRegistro(
            string nombre, string apellido, string email,
            string usuario, string contrasena, string confirmar,
            byte[] foto, Applogin1.FrmRegistro vista)
        {
            // 1. Validación básica
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(contrasena) ||
                string.IsNullOrWhiteSpace(confirmar))
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2. Contraseñas iguales
            if (contrasena != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 3. Requisitos de contraseña
            var faltantes = PasswordUtils.GetRequisitosIncumplidos(contrasena);

            if (faltantes.Count > 0)
            {
                string msg = "La contraseña no cumple los requisitos:\n" +
                             string.Join("\n", faltantes.Select(f => "• " + f));

                MessageBox.Show(msg,
                    "Contraseña insegura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 4. Usuario existente
            if (_dao.UsuarioExiste(usuario))
            {
                MessageBox.Show("El usuario ya está en uso.",
                    "Duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 5. Crear usuario
            int nivel = PasswordUtils.CalcularFortaleza(contrasena);

            var u = new Usuario
            {
                Nombre = nombre.Trim(),
                Apellido = apellido.Trim(),
                Email = email.Trim(),
                NombreUsuario = usuario.Trim(),
                Contrasena = contrasena,
                Foto = foto,
                NivelSeguridad = nivel
            };

            // 6. Insertar en BD
            if (_dao.Insertar(u))
            {
                MessageBox.Show("Usuario registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FrmLogin login = new FrmLogin();
                login.Show();

                vista.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar en la base de datos.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        internal void ProcesarRegistro(string text1, string text2, string text3, string text4, string text5, string text6, byte[] fotoBytes, Applogin1.FrmRegistro frmRegistro)
        {
            throw new NotImplementedException();
        }
    }
}