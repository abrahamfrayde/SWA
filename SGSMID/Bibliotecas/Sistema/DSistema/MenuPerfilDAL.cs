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
    public class MenuPerfilDAL
    {

        private Conexion.Conexion cn;

        public MenuPerfilDAL()
        {
            cn = new Conexion.Conexion();
        }

        public int insertarMenuPerfil(Perfiles _objperfil, Menu _objmenu)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_MENUPERFILES_INS", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdMenu", _objmenu.iIdMenu);
                    command.Parameters.AddWithValue("@iIdPerfil", _objperfil.iIdPerfil);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _objperfil.iIdUsuarioGestion);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del menu perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del menu perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return id;
        }
        public void actualizarMenuPerfiles(Perfiles _objperfil, List<Menu> _lstmenu)
        {
            try
            {

                eliminarMenuPerfiles(_objperfil);
                foreach (ESistema.Menu _objmenu in _lstmenu.GroupBy(i => i.iIdMenu).Select(g => g.First()).ToList())
                {

                    insertarMenuPerfil(_objperfil, _objmenu);

                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar el registro del menu perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el registro del menu perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }
        public void eliminarMenuPerfiles(Perfiles _objperfil)
        {
           
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_MENUPERFILES_DEL", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdPerfil", _objperfil.iIdPerfil);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro del menu perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro del menu perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
         
        }

        public List<MenuPerfil> obtenerMenuPerfiles(int id = 0)
        {
            List<MenuPerfil> list = new List<MenuPerfil>();
            MenuPerfil obj;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_MENUPERFILES_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdPerfil", id == 0 ? (object)DBNull.Value : id);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new MenuPerfil();
                        obj.objMenu = new Menu();
                        obj.objPerfil = new Perfiles();
                        obj.iIdMenuPerfil = (int)reader["iIdMenuPerfil"];
                        obj.objMenu.iIdMenu = (int)reader["iIdMenu"];
                        obj.objPerfil.iIdPerfil = (int)reader["iIdPerfil"];
                        obj.dtFechaRegistro = (DateTime)reader["dtFechaRegistro"];
                        list.Add(obj);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros de los menu perfiles" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros de los menu perfiles" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }
    }
}
