using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESistema;
using System.Data;
using System.Data.SqlClient;
using Conexion;

namespace DSistema
{
    public class PerfilesDAL
    {
        private Conexion.Conexion cn;

        public PerfilesDAL()
        {
            cn = new Conexion.Conexion();
        }
       
        public int insertarPerfil(Perfiles _objperfil, List<Menu> _lstmenu)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_PERFILES_INS", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cNombre", _objperfil.cNombre);
                    command.Parameters.AddWithValue("@cDescripcion", _objperfil.cDescripcion);
                    command.Parameters.AddWithValue("@iIdCentroCosto", _objperfil.iIdCentroCosto);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _objperfil.iIdUsuarioGestion);
                    cn.OpenConnection();
                    id = (int)command.ExecuteScalar();
                    Perfiles _objperfiltemp = new Perfiles();
                    _objperfiltemp = _objperfil;
                    _objperfiltemp.iIdPerfil = id;
                    MenuPerfilDAL _objmenuperfil = new MenuPerfilDAL();

                    foreach (ESistema.Menu _objmenu in _lstmenu.GroupBy(i=>i.iIdMenu).Select(g=>g.First()).ToList())
                    {

                        _objmenuperfil.insertarMenuPerfil(_objperfiltemp, _objmenu);

                    }
                  

                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            return id;


        }

        public void modificarPerfil(Perfiles _objperfil)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_PERFILES_UPD", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdPerfil", _objperfil.iIdPerfil);
                    command.Parameters.AddWithValue("@cDescripcion", _objperfil.cDescripcion);
                    command.Parameters.AddWithValue("@iIdCentroCosto", _objperfil.iIdCentroCosto);
                    command.Parameters.AddWithValue("@cNombre", _objperfil.cNombre);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();      
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro del perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro del perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }

        public void eliminarPerfil(Perfiles _objperfil)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_PERFILES_DEL", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdPerfil", _objperfil.iIdPerfil);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro del perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro del perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }
        public List<Perfiles> obtenerPerfiles(int id=0,string filtro = null)
        {
            List<Perfiles> list = new List<Perfiles>();
            Perfiles cat;
            CentrosCostosDAL _centrocostosdal = new CentrosCostosDAL();
            List<CentrosCostos> _lstcentroscostos = new List<CentrosCostos>();
           
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_PERFILES_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdPerfil", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cat = new Perfiles();
                        
                        cat.iIdPerfil = (int)reader["iIdPerfil"];
                        cat.cNombre = (string)reader["cNombre"];
                        cat.dtFechaRegistro = (DateTime)reader["dtFechaRegistro"];
                        if(reader["cDescripcion"] == DBNull.Value)
                        {
                            
                        }
                        else
                        {
                            cat.cDescripcion = (string)reader["cDescripcion"];
                        }
                        cat.iIdCentroCosto = (int)reader["iIdCentroCosto"];
                        _lstcentroscostos = _centrocostosdal.obtenerCentrosCostos(cat.iIdCentroCosto);
                        cat.cNombreDepartamento = _lstcentroscostos[0].cNombre;
                        list.Add(cat);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros de los perfiles" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros de los perfiles" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }

        public List<Menu> obtenerMenus(int id=0)
        {
            List<Menu> list = new List<Menu>();
            Menu obj;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_MENU_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdMenu", id == 0 ? (object)DBNull.Value : id);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new Menu();
                        obj.iIdMenu = (int)reader["iIdMenu"];
                        obj.cNombreMenu = "&nbsp;&nbsp;<i class='" + (string) reader["cIcono"] + "'></i>&nbsp;&nbsp;" + (string)reader["cNombre"];
                        obj.iIdPadre = (int)reader["iIdPadre"];
                  
                        list.Add(obj);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo de departamentos" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo de departamentos" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }

    }
}
