
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Applogin1.Modelo
{
    public static class PasswordUtils
    {
        public const int MIN_LONGITUD = 8;
        public const int FUERTE_LONGITUD = 12;

        private static readonly Regex RgxMayuscula = new Regex(@"[A-Z]");
        private static readonly Regex RgxMinuscula = new Regex(@"[a-z]");
        private static readonly Regex RgxNumero = new Regex(@"[0-9]");
        private static readonly Regex RgxSimbolo = new Regex(@"[!@#$%^&*()_\-=\[\]{};':.,<>?]");

        public static int CalcularFortaleza(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return 0;

            int score = 0;

            if (pass.Length >= MIN_LONGITUD) score++;
            if (pass.Length >= FUERTE_LONGITUD) score++;
            if (RgxMayuscula.IsMatch(pass)) score++;
            if (RgxMinuscula.IsMatch(pass)) score++;
            if (RgxNumero.IsMatch(pass)) score++;
            if (RgxSimbolo.IsMatch(pass)) score++;

            return Math.Min(4, Math.Max(0, score - 1));
        }

        public static bool EsValida(string pass)
        {
            return !string.IsNullOrEmpty(pass) &&
                   pass.Length >= MIN_LONGITUD &&
                   RgxMayuscula.IsMatch(pass) &&
                   RgxMinuscula.IsMatch(pass) &&
                   RgxNumero.IsMatch(pass) &&
                   RgxSimbolo.IsMatch(pass);
        }

        public static List<string> GetRequisitosIncumplidos(string pass)
        {
            var faltantes = new List<string>();

            if (string.IsNullOrEmpty(pass) || pass.Length < MIN_LONGITUD)
                faltantes.Add("Mínimo 8 caracteres");

            if (!RgxMayuscula.IsMatch(pass ?? ""))
                faltantes.Add("Al menos 1 letra mayúscula");

            if (!RgxMinuscula.IsMatch(pass ?? ""))
                faltantes.Add("Al menos 1 letra minúscula");

            if (!RgxNumero.IsMatch(pass ?? ""))
                faltantes.Add("Al menos 1 número");

            if (!RgxSimbolo.IsMatch(pass ?? ""))
                faltantes.Add("Al menos 1 símbolo especial");

            return faltantes;
        }

        public static string GetEtiqueta(int nivel)
        {
            switch (nivel)
            {
                case 0: return "Muy débil";
                case 1: return "Débil";
                case 2: return "Media";
                case 3: return "Fuerte";
                case 4: return "Muy fuerte";
                default: return "";
            }
        }

        public static Color GetColor(int nivel)
        {
            switch (nivel)
            {
                case 0: return Color.FromArgb(176, 0, 0);
                case 1: return Color.FromArgb(200, 80, 0);
                case 2: return Color.FromArgb(190, 160, 0);
                case 3: return Color.FromArgb(0, 130, 50);
                case 4: return Color.FromArgb(0, 100, 30);
                default: return Color.Gray;
            }
        }
    }
}