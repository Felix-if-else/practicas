using System;

namespace Applogin1.Modelo
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;

        public byte[] Foto { get; set; }

        public int NivelSeguridad { get; set; }

        public bool Bloqueado { get; set; }
        public int Intentos { get; set; }

        public DateTime? UltimoAcceso { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public bool Activo { get; set; } = true;

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }

        public override string ToString()
        {
            return NombreCompleto + " (@" + NombreUsuario + ")";
        }
    }
}