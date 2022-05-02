using CRUD.Models;
using System.Data.SqlClient;
using System.Data;



namespace CRUD.Datos
{
    public class UsuarioDatos
    {


        public List<UsuarioModel> GetAll()
        {
            var oLista = new List<UsuarioModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("UsuarioGetAll", conexion);

                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new UsuarioModel()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Nombre = dr["Nombre"].ToString(),
                            ApellidoPaterno = dr["ApellidoPaterno"].ToString(),
                            ApellidoMaterno = dr["ApellidoMaterno"].ToString(),
                            UserName = dr["UserName"].ToString()



                        });
                    }
                }

            }

            return oLista;
        }

        public UsuarioModel GetById(int IdUsuario)
        {
            var oUsuario = new UsuarioModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("UsuarioGetById", conexion);
                cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUsuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        oUsuario.Nombre = dr["Nombre"].ToString();
                        oUsuario.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                        oUsuario.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                        oUsuario.UserName = dr["UserName"].ToString();
                    }
                }

            }

            return oUsuario;
        }
        public bool Add(UsuarioModel oUsuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    
                    SqlCommand cmd = new SqlCommand("UsuarioAdd", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
                    cmd.Parameters.AddWithValue("ApellidoPaterno", oUsuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("ApellidoMaterno", oUsuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("UserName", oUsuario.UserName);
                   

                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;

            }

            return rpta;

        }


        public bool Update(UsuarioModel oUsuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("UsuarioUpdate", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
                    cmd.Parameters.AddWithValue("ApellidoPaterno", oUsuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("ApellidoMaterno", oUsuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("UserName", oUsuario.UserName);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;

            }

            return rpta;

        }


        public bool Delete(int IdUsuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("UsuarioDelete", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
            
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;

            }

            return rpta;

        }
    }

}
