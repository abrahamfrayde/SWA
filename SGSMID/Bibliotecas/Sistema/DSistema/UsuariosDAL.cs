using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;
using ESistema;
using System.Data;
using System.Data.SqlClient;

namespace DSistema
{
    public class UsuariosDAL
    {
        Conexion.Conexion cn;
        public UsuariosDAL()
        {
            cn = new Conexion.Conexion();
        }

        public Usuarios Sigin(string user, string password)
        {
            Usuarios usuario = new Usuarios() { objPerfil=new Perfiles()};
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_USUARIO_SIGIN", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cNombreUsuario", user);
                    command.Parameters.AddWithValue("@cPassword", password);

                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario.iIdUsuario=(int)reader["iIdUsuario"];
                            usuario.cNombreUsuario=(string)reader["cNombreUsuario"];
                            usuario.objPerfil.iIdPerfil=(int)reader["iIdPerfil"];
                            usuario.objPerfil.cNombre=(string)reader["cNombre"];
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD al Autenticar Usuario. " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Code al Autenticar Usuario. "+ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            return usuario;
        }

        public void insertarUsuarios(UsuariosDatos _catusuariosdatos)
        {
           // int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_USUARIOS_INS", cn.Connection))
                {
                    
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cNombreUsuario", _catusuariosdatos.objUsuario.cNombreUsuario);
                    command.Parameters.AddWithValue("@cPassword", _catusuariosdatos.objUsuario.cPassword);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _catusuariosdatos.objUsuario.iIdUsuarioGestion);
                    command.Parameters.AddWithValue("@iIdPerfil", _catusuariosdatos.objUsuario.objPerfil.iIdPerfil);
                    command.Parameters.AddWithValue("@cNombre", _catusuariosdatos.cNombre);
                    command.Parameters.AddWithValue("@cApellidoPaterno", _catusuariosdatos.cApellidoPaterno);
                    command.Parameters.AddWithValue("@cApellidoMaterno", _catusuariosdatos.cApellidoMaterno);
                    command.Parameters.AddWithValue("@iNumeroEmpleado", _catusuariosdatos.iNumeroEmpleado);
                    command.Parameters.AddWithValue("@iIdPuesto", _catusuariosdatos.objPuesto.iIdPuesto);
                    command.Parameters.AddWithValue("@iIdCentroCosto", _catusuariosdatos.iIdCentroCosto == 0 ? (object)DBNull.Value : _catusuariosdatos.iIdCentroCosto);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                   // id = (int)command.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            //return id;

        }

        public void modificarUsuarios(UsuariosDatos _catusuariosdatos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_USUARIOS_UPD", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdUsuario", _catusuariosdatos.objUsuario.iIdUsuario);
                    command.Parameters.AddWithValue("@cNombreUsuario", _catusuariosdatos.objUsuario.cNombreUsuario);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _catusuariosdatos.objUsuario.iIdUsuarioGestion);
                    command.Parameters.AddWithValue("@iIdPerfil", _catusuariosdatos.objUsuario.objPerfil.iIdPerfil);
                    command.Parameters.AddWithValue("@cNombre", _catusuariosdatos.cNombre);
                    command.Parameters.AddWithValue("@cApellidoPaterno", _catusuariosdatos.cApellidoPaterno);
                    command.Parameters.AddWithValue("@cApellidoMaterno", _catusuariosdatos.cApellidoMaterno);
                    command.Parameters.AddWithValue("@iNumeroEmpleado", _catusuariosdatos.iNumeroEmpleado);
                    command.Parameters.AddWithValue("@iIdPuesto", _catusuariosdatos.objPuesto.iIdPuesto);
                    command.Parameters.AddWithValue("@iIdCentroCosto", _catusuariosdatos.iIdCentroCosto == 0 ? (object)DBNull.Value : _catusuariosdatos.iIdCentroCosto);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }

        public void eliminarUsuario(UsuariosDatos _catusuariosdatos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_USUARIOS_DEL", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdUsuario", _catusuariosdatos.objUsuario.iIdUsuario);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }

        public void cambiarPassword(UsuariosDatos _catusuariosdatos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_USUARIOS_PASS", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdUsuario", _catusuariosdatos.objUsuario.iIdUsuario);
                    command.Parameters.AddWithValue("@cPassword", _catusuariosdatos.objUsuario.cPassword);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }


        public List<UsuariosDatos> obtenerUsuarios(int idpuesto=0, int idperfil=0, int id=0,string filtro = null)
        {
            List<UsuariosDatos> list = new List<UsuariosDatos>();
            UsuariosDatos _catusuariosdatos;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_USUARIOS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdUsuario", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    command.Parameters.AddWithValue("@iIdPuesto", idpuesto == 0 ? (object)DBNull.Value : idpuesto);
                    command.Parameters.AddWithValue("@iIdPerfil", idperfil == 0 ? (object)DBNull.Value : idperfil);
                    
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime fechatemp;
                        _catusuariosdatos = new UsuariosDatos();
                        _catusuariosdatos.objUsuario = new Usuarios();
                        _catusuariosdatos.objUsuario.iIdUsuario = (int)reader["iIdUsuario"];
                        _catusuariosdatos.objUsuario.cNombreUsuario = (string)reader["cNombreUsuario"];
                        _catusuariosdatos.objUsuario.objPerfil = new Perfiles();
                        _catusuariosdatos.objUsuario.objPerfil.iIdPerfil = (int)reader["iIdPerfil"];
                        _catusuariosdatos.objUsuario.objPerfil.cNombre = (String)reader["cNombrePerfil"];
                        _catusuariosdatos.cNombre = (string)reader["cNombre"];
                        _catusuariosdatos.cApellidoPaterno = (string)reader["cApellidoPaterno"];
                        _catusuariosdatos.cApellidoMaterno = (string)reader["cApellidoMaterno"];
                        _catusuariosdatos.cNombreCompleto = (string)reader["cNombreCompleto"];
                        _catusuariosdatos.iNumeroEmpleado = (int)reader["iNumeroEmpleado"];
                        _catusuariosdatos.iIdCentroCosto = (int)reader["iIdCentroCosto"];
                        _catusuariosdatos.objPuesto = new CatPuestos();
                        _catusuariosdatos.objPuesto.iIdPuesto = (int)reader["iIdPuesto"];
                        _catusuariosdatos.objPuesto.cNombre = (string)reader["cNombrePuesto"];
                        fechatemp  = (DateTime) (reader["dtFechaAlta"]);
                        _catusuariosdatos.objUsuario.dtFechaAlta = fechatemp.ToShortDateString();
                        list.Add(_catusuariosdatos);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }

        
    }
}
