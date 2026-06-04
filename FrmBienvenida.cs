using Applogin1.Modelo;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Applogin1
{
    public class FrmBienvenida : Form
    {
        public FrmBienvenida(Usuario u)
        {
            if (u == null)
            {
                MessageBox.Show("Error: usuario no válido");
                Close();
                return;
            }

            InitComponentManual(u);
            ConfigurarVentana();
        }

        private void InitComponentManual(Usuario u)
        {
            BackColor = Color.FromArgb(235, 245, 255);

            PictureBox picFoto = new PictureBox();
            picFoto.Location = new Point(20, 20);
            picFoto.Size = new Size(150, 150);
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            picFoto.BorderStyle = BorderStyle.FixedSingle;
            picFoto.BackColor = Color.FromArgb(210, 230, 250);

            if (u.Foto != null && u.Foto.Length > 0)
            {
                MemoryStream ms = new MemoryStream(u.Foto);
                picFoto.Image = Image.FromStream(ms);
            }

            Label lblBienvenida = new Label();
            lblBienvenida.Text = "¡Bienvenido al Sistema!";
            lblBienvenida.Location = new Point(170, 25);
            lblBienvenida.Size = new Size(280, 30);
            lblBienvenida.Font = new Font("Arial", 14, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(26, 60, 107);

            Label lblNombre = new Label();
            lblNombre.Text = u.NombreCompleto;
            lblNombre.Location = new Point(170, 62);
            lblNombre.Size = new Size(280, 26);
            lblNombre.Font = new Font("Arial", 13);
            lblNombre.ForeColor = Color.Black;

            Label lblUsuario = new Label();
            lblUsuario.Text = u.NombreUsuario + " | " + u.Email;
            lblUsuario.Location = new Point(170, 92);
            lblUsuario.Size = new Size(280, 20);
            lblUsuario.Font = new Font("Arial", 9, FontStyle.Italic);
            lblUsuario.ForeColor = Color.Gray;

            string etiq = PasswordUtils.GetEtiqueta(u.NivelSeguridad);
            Color col = PasswordUtils.GetColor(u.NivelSeguridad);

            Label lblSeg = new Label();
            lblSeg.Text = "Seguridad de contraseña: " + etiq;
            lblSeg.Location = new Point(170, 118);
            lblSeg.Size = new Size(280, 20);
            lblSeg.Font = new Font("Arial", 9, FontStyle.Bold);
            lblSeg.ForeColor = col;

            Panel separador = new Panel();
            separador.Location = new Point(20, 165);
            separador.Size = new Size(450, 1);
            separador.BackColor = Color.FromArgb(46, 93, 168);

            Label lblAcceso = new Label();
            if (u.UltimoAcceso.HasValue)
                lblAcceso.Text = "Último acceso: " + u.UltimoAcceso.Value.ToString("dd/MM/yyyy HH:mm");
            else
                lblAcceso.Text = "Primer acceso al sistema";

            lblAcceso.Location = new Point(20, 175);
            lblAcceso.Size = new Size(440, 20);
            lblAcceso.Font = new Font("Arial", 9, FontStyle.Italic);
            lblAcceso.ForeColor = Color.Gray;
            lblAcceso.TextAlign = ContentAlignment.MiddleCenter;

            Button btnSalir = new Button();
            btnSalir.Text = "Cerrar Sesión";
            btnSalir.Location = new Point(160, 205);
            btnSalir.Size = new Size(160, 38);
            btnSalir.BackColor = Color.FromArgb(176, 0, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Font = new Font("Arial", 11, FontStyle.Bold);
            btnSalir.FlatStyle = FlatStyle.Flat;

            btnSalir.Click += delegate
            {
                FrmLogin login = new FrmLogin();
                login.Show();
                Close();
            };

            Controls.Add(picFoto);
            Controls.Add(lblBienvenida);
            Controls.Add(lblNombre);
            Controls.Add(lblUsuario);
            Controls.Add(lblSeg);
            Controls.Add(separador);
            Controls.Add(lblAcceso);
            Controls.Add(btnSalir);
        }

        private void ConfigurarVentana()
        {
            Text = "Bienvenida";
            Size = new Size(500, 300);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
    }
}