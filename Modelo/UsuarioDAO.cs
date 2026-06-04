using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Applogin1.Modelo
{
    public class UsuarioDAO
    {
        private MySqlConnection GetConn()
        {
            return ConexionDB.GetConexion();
        }

        // INSERTAR
        public bool Insertar(Usuario u)
        {
            const string sql = @"INSERT INTO usuarios 
            (nombre, apellido, email, usuario, contrasena, foto, nivel_seg)
            VALUES (@nom, @ape, @mail, @usr, @pass, @foto, @niv)";

            try
            {
                using (var conn = GetConn())
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", u.Nombre);
                    cmd.Parameters.AddWithValue("@ape", u.Apellido);
                    cmd.Parameters.AddWithValue("@mail", u.Email);
                    cmd.Parameters.AddWithValue("@usr", u.NombreUsuario);
                    cmd.Parameters.AddWithValue("@pass", u.Contrasena);
                    cmd.Parameters.AddWithValue("@foto", (object)u.Foto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@niv", u.NivelSeguridad);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DAO] Error Insertar: " + ex.Message);
                return false;
            }
        }

        // LOGIN
        public Usuario Login(string usuario, string contrasena)
        {
            const string sql = @"SELECT * FROM usuarios
            WHERE usuario = @usr AND contrasena = @pass
            AND activo = 1 AND bloqueado = 0";

            try
            {
                using (var conn = GetConn())
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@usr", usuario);
                    cmd.Parameters.AddWithValue("@pass", contrasena);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearUsuario(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DAO] Error Login: " + ex.Message);
            }

            return null;
        }

        // LISTAR
        public List<Usuario> ListarTodos()
        {
            var lista = new List<Usuario>();

            const string sql = @"SELECT id, nombre, apellido, email, usuario,
            nivel_seg, intentos, bloqueado, ultimo_acc, fecha_reg
            FROM usuarios";

            try
            {
                using (var conn = GetConn())
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearUsuario(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DAO] Error Listar: " + ex.Message);
            }

            return lista;
        }

        // BLOQUEADO
        public bool EstasBloqueado(string usuario)
        {
            const string sql = "SELECT bloqueado FROM usuarios WHERE usuario = @usr";

            try
            {
                using (var conn = GetConn())
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@usr", usuario);

                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        return Convert.ToBoolean(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DAO] Error Bloqueado: " + ex.Message);
            }

            return false;
        }

        // ACTUALIZAR
        public bool Actualizar(Usuario u)
        {
            const string sql = @"UPDATE usuarios
            SET nombre=@nom, apellido=@ape, email=@mail,
                contrasena=@pass, foto=@foto, nivel_seg=@niv
            WHERE id=@id";

            try
            {
                using (var conn = GetConn())
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", u.Nombre);
                    cmd.Parameters.AddWithValue("@ape", u.Apellido);
                    cmd.Parameters.AddWithValue("@mail", u.Email);
                    cmd.Parameters.AddWithValue("@pass", u.Contrasena);
                    cmd.Parameters.AddWithValue("@foto", (object)u.Foto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@niv", u.NivelSeguridad);
                    cmd.Parameters.AddWithValue("@id", u.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DAO] Error Actualizar: " + ex.Message);
                return false;
            }
        }

        // ELIMINAR
        public bool Eliminar(int id)
        {
            const string sql = "UPDATE usuarios SET activo=0 WHERE id=@id";

            try
            {
                using (var conn = GetConn())
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DAO] Error Eliminar: " + ex.Message);
                return false;
            }
        }

        // EXISTE
        public bool UsuarioExiste(string usuario)
        {
            const string sql = "SELECT COUNT(*) FROM usuarios WHERE usuario=@u";

            using (var conn = GetConn())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@u", usuario);

                var val = cmd.ExecuteScalar();

                return val != null && Convert.ToInt32(val) > 0;
            }
        }

        // MAPEAR
        private static Usuario MapearUsuario(MySqlDataReader r)
        {
            Usuario u = new Usuario();

            u.Id = r.GetInt32("id");
            u.Nombre = r.GetString("nombre");
            u.Apellido = r.GetString("apellido");
            u.Email = r.GetString("email");
            u.NombreUsuario = r.GetString("usuario");

            if (!r.IsDBNull(r.GetOrdinal("foto")))
                u.Foto = (byte[])r["foto"];

            u.NivelSeguridad = r.GetInt32("nivel_seg");
            u.Bloqueado = r.GetBoolean("bloqueado");
            u.Intentos = r.GetInt32("intentos");
            u.Activo = r.GetBoolean("activo");

            return u;
        }
    }
}