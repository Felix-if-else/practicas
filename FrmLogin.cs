using Applogin1.Controlador;
using Applogin1.Modelo;
using AppLoginMVC.Vista;
using System.Drawing;
using System.Windows.Forms;

namespace Applogin1
{
    public partial class FrmLogin : Form, IFrmLogin
    {
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnLogin, btnRegistrar;
        private Label lblEstado;
        private CircularProgressBar barraLogin;

        public FrmLogin()
        {
            InitComponentsManual();
            ConfigurarVentana();
        }

        private void InitComponentsManual()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 248, 255),
                Padding = new Padding(40)
            };

            // Título
            var lblTitulo = new Label
            {
                Text = "Iniciar Sesión",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 60, 107),
                Location = new Point(40, 26),
                Size = new Size(300, 36),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Barra circular
            barraLogin = new CircularProgressBar
            {
                Location = new Point(145, 62),
                Size = new Size(90, 90),
                Grosor = 12
            };

            // Usuario ✔ CORREGIDO (TextBox REAL)
            var lblUsr = new Label
            {
                Text = "Usuario:",
                Location = new Point(40, 168),
                Size = new Size(80, 22)
            };

            txtUsuario = new TextBox
            {
                Location = new Point(125, 165),
                Size = new Size(210, 26)
            };

            // Contraseña
            var lblPass = new Label
            {
                Text = "Contraseña:",
                Location = new Point(40, 208),
                Size = new Size(80, 22)
            };

            txtContraseña = new TextBox
            {
                Location = new Point(125, 205),
                Size = new Size(210, 26),
                PasswordChar = '●'
            };

            // Estado
            lblEstado = new Label
            {
                Text = "",
                Location = new Point(40, 242),
                Size = new Size(300, 20),
                ForeColor = Color.Red,
                Font = new Font("Arial", 9, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Botón Login
            btnLogin = new Button
            {
                Text = "Ingresar",
                Location = new Point(40, 272),
                Size = new Size(120, 36),
                BackColor = Color.FromArgb(46, 93, 168),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            // Botón Registro
            btnRegistrar = new Button
            {
                Text = "Registrarse",
                Location = new Point(210, 272),
                Size = new Size(120, 36),
                Font = new Font("Arial", 10),
                FlatStyle = FlatStyle.Flat
            };

            // 🔥 EVENTOS

            txtContraseña.TextChanged += (s, e) =>
            {
                int nivel = PasswordUtils.CalcularFortaleza(txtContraseña.Text);
                barraLogin.AnimarHacia(nivel * 25);
            };

            // LOGIN SIN ANIMACIÓN (más estable)
            btnLogin.Click += (s, e) =>
            {
                SetEstado("");

                new LoginController().ProcesarLogin(
                    txtUsuario.Text.Trim(),
                    txtContraseña.Text.Trim(),
                    this);
            };

            txtContraseña.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    btnLogin.PerformClick();
            };

            btnRegistrar.Click += (s, e) =>
            {
                new FrmRegistro().Show();
                Hide();
            };

            panel.Controls.AddRange(new Control[]
            {
                lblTitulo, barraLogin,
                lblUsr, txtUsuario,
                lblPass, txtContraseña,
                lblEstado,
                btnLogin, btnRegistrar
            });

            Controls.Add(panel);
        }

        public void SetEstado(string mensaje)
        {
            lblEstado.Text = mensaje;
        }

        private void ConfigurarVentana()
        {
            Text = "Login - Sistema de Acceso";
            Size = new Size(400, 350);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
    }
}
