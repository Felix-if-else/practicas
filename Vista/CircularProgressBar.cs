using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AppLoginMVC.Vista
{
    public class CircularProgressBar : Panel
    {
        private int _valor = 0;
        private int _grosor = 14;
        private System.Windows.Forms.Timer? _timer = null;
        private int _objetivo = 0;

        public CircularProgressBar()
        {
            Size = new Size(100, 100);
            DoubleBuffered = true;
            BackColor = Color.Transparent;

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
        }

        // Valor (0-100)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Valor
        {
            get => _valor;
            set
            {
                _valor = Math.Clamp(value, 0, 100);
                Invalidate();
            }
        }

        // Grosor del arco
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Grosor
        {
            get => _grosor;
            set
            {
                _grosor = value;
                Invalidate();
            }
        }

        // Color dinámico según valor
        private Color GetColorArco() => _valor switch
        {
            < 25 => Color.FromArgb(200, 40, 40),
            < 50 => Color.FromArgb(220, 130, 0),
            < 75 => Color.FromArgb(200, 180, 0),
            _ => Color.FromArgb(40, 160, 60)
        };

        // Animación del progreso
        public void AnimarHacia(int objetivo, Action? onComplete = null)
        {
            _objetivo = Math.Clamp(objetivo, 0, 100);

            _timer?.Stop();
            _timer?.Dispose();

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 12;

            _timer.Tick += (s, e) =>
            {
                if (_valor < _objetivo)
                    Valor = Math.Min(_valor + 3, _objetivo);
                else if (_valor > _objetivo)
                    Valor = Math.Max(_valor - 3, _objetivo);
                else
                {
                    _timer?.Stop();
                    onComplete?.Invoke();
                }
            };

            _timer.Start();
        }

        // Dibujo del control
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            int margen = _grosor / 2 + 4;
            var rect = new Rectangle(
                margen,
                margen,
                Width - 2 * margen,
                Height - 2 * margen
            );

            // Fondo
            using var penFondo = new Pen(Color.LightGray, _grosor)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };

            g.DrawEllipse(penFondo, rect);

            // Progreso
            if (_valor > 0)
            {
                float angulo = 360f * _valor / 100f;

                using var penArco = new Pen(GetColorArco(), _grosor)
                {
                    StartCap = LineCap.Round,
                    EndCap = LineCap.Round
                };

                g.DrawArc(penArco, rect, -90, angulo);
            }

            // Texto
            string texto = $"{_valor}%";

            using var font = new Font("Arial", rect.Width / 5f, FontStyle.Bold);
            var size = g.MeasureString(texto, font);

            float x = rect.X + (rect.Width - size.Width) / 2f;
            float y = rect.Y + (rect.Height - size.Height) / 2f;

            using var brush = new SolidBrush(Color.FromArgb(30, 60, 100));
            g.DrawString(texto, font, brush, x, y);
        }
    }
}