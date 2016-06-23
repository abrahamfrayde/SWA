using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Conexion;
using ESistema;

namespace DSistema
{
    public class MenuDAL
    {
        private Conexion.Conexion cn;

        public MenuDAL()
        {
            cn = new Conexion.Conexion();
        }

        public List<Menu> GetMenus(int idperfil)
        {
            List<Menu> list = new List<Menu>();
            Menu ent;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_MENUS_BYPERFIL", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdPerfil", idperfil);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        ent = new Menu();
                        ent.iIdMenu = (int)reader["iIdMenu"];
                        ent.cNombreMenu = (string)reader["cNombreMenu"];
                        ent.cURLMenu = (string)reader["cURLMenu"];
                        ent.iOrden = (int)reader["iOrden"];
                        ent.iIdPadre = (int)reader["iIdPadre"];
                        ent.cIcono = (string)reader["cIcono"];
                        list.Add(ent);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD No se pudo obtener la lista de menus " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error code No se pudo obtener la lista de menus " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }
    }
}
