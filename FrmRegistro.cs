using Applogin1.Controlador;
using AppLoginMVC;
using AppLoginMVC.Controlador;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Applogin1
{
    public partial class FrmRegistro : Form
    {
        private TextBox txtNombre, txtApellido, txtEmail, txtUsuario;
        private TextBox txtContraseña, txtConfirmar;
        private PictureBox picFoto;
        private Button btnSelFoto, btnGuardar, btnCancelar;
        private PasswordStrengthControl ctrlFortaleza;

        public byte[] FotoBytes { get; private set; }

        public FrmRegistro()
        {
            InitComponentManual();
            ConfigurarVentana();
        }

        private void InitComponentManual()
        {
            Panel panel = new Panel();
            panel.AutoScroll = true;
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.FromArgb(245, 250, 255);
            panel.Padding = new Padding(30);

            Label titulo = new Label();
            titulo.Text = "Registro de Usuario";
            titulo.Font = new Font("Arial", 16, FontStyle.Bold);
            titulo.Location = new Point(30, 15);
            titulo.Size = new Size(340, 30);
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(titulo);

            int y = 55;

            txtNombre = CrearCampo(panel, "Nombre:", y);
            y += 36;
            txtApellido = CrearCampo(panel, "Apellido:", y);
            y += 36;
            txtEmail = CrearCampo(panel, "Email:", y);
            y += 36;
            txtUsuario = CrearCampo(panel, "Usuario:", y);
            y += 36;
            txtContraseña = CrearCampo(panel, "Contraseña:", y);
            txtContraseña.PasswordChar = '●';
            y += 36;
            txtConfirmar = CrearCampo(panel, "Confirmar:", y);
            txtConfirmar.PasswordChar = '●';
            y += 36;

            ctrlFortaleza = new PasswordStrengthControl();
            ctrlFortaleza.Location = new Point(30, y);
            ctrlFortaleza.Size = new Size(340, 115);
            panel.Controls.Add(ctrlFortaleza);
            y += 125;

            txtContraseña.TextChanged += delegate
            {
                ctrlFortaleza.Actualizar(txtContraseña.Text);
            };

            Label lblFoto = new Label();
            lblFoto.Text = "Foto:";
            lblFoto.Location = new Point(30, y + 8);
            lblFoto.Size = new Size(60, 22);
            panel.Controls.Add(lblFoto);

            picFoto = new PictureBox();
            picFoto.Location = new Point(95, y);
            picFoto.Size = new Size(90, 90);
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            picFoto.BorderStyle = BorderStyle.FixedSingle;
            picFoto.BackColor = Color.White;
            panel.Controls.Add(picFoto);

            btnSelFoto = new Button();
            btnSelFoto.Text = "Seleccionar Foto";
            btnSelFoto.Location = new Point(195, y + 25);
            btnSelFoto.Size = new Size(130, 32);
            panel.Controls.Add(btnSelFoto);
            y += 100;

            btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(30, y + 10);
            btnGuardar.Size = new Size(140, 36);

            btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(210, y + 10);
            btnCancelar.Size = new Size(140, 36);

            panel.Controls.Add(btnGuardar);
            panel.Controls.Add(btnCancelar);
            Controls.Add(panel);

            btnSelFoto.Click += delegate
            {
                SeleccionarFoto();
            };

            btnGuardar.Click += delegate
            {
                RegistroController controller = new RegistroController();
                controller.ProcesarRegistro(
                    txtNombre.Text,
                    txtApellido.Text,
                    txtEmail.Text,
                    txtUsuario.Text,
                    txtContraseña.Text,
                    txtConfirmar.Text,
                    FotoBytes,
                    this);
            };

            btnCancelar.Click += delegate
            {
                FrmLogin login = new FrmLogin();
                login.Show();
                Close();
            };
        }

        private TextBox CrearCampo(Panel panel, string texto, int y)
        {
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.Size = new Size(90, 22);
            lbl.Location = new Point(30, y);
            panel.Controls.Add(lbl);

            TextBox txt = new TextBox();
            txt.Location = new Point(125, y);
            txt.Size = new Size(215, 26);
            panel.Controls.Add(txt);

            return txt;
        }

        private void SeleccionarFoto()
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Title = "Seleccionar fotografía";
            dig.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (dig.ShowDialog() == DialogResult.OK)
            {
                FotoBytes = File.ReadAllBytes(dig.FileName);
                picFoto.Image = Image.FromFile(dig.FileName);
            }

            dig.Dispose();
        }

        private void ConfigurarVentana()
        {
            Text = "Registro de Usuario";
            Size = new Size(430, 660);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
    }
}