using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESistema;
using Conexion;
using System.Data;
using System.Data.SqlClient;

namespace DSistema
{
    public class CentrosCostosDAL
    {
        Conexion.Conexion cn;
        public CentrosCostosDAL()
        {
            cn = new Conexion.Conexion();
        }
        public List<CentrosCostos> obtenerCentrosCostos(int id = 0, int idparent = 0, int nivel = 0, string filtro = null)
        {
            List<CentrosCostos> list = new List<CentrosCostos>();
            CentrosCostos cat;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CENTROSCOSTOS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdCentroCosto", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@iIdParent", idparent == 0 ? (object)DBNull.Value : idparent);
                    command.Parameters.AddWithValue("@iNivel", nivel == 0 ? (object)DBNull.Value : nivel);
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cat = new CentrosCostos();
                        cat.iIdCentroCosto = (int)reader["iIdCentroCosto"];
                        cat.iIdParent = (int)reader["iIdParent"];
                        cat.iNivel = (int)reader["iNivel"];
                        cat.iPeriodo = (int)reader["iPeriodo"];
                        cat.cNombre = (string)reader["cNombre"];
                       // cat.iIdUsuarioResponsable = (int)reader["iIdUsuarioResponsable"];
                        cat.cCorreosElectronicos = (string)reader["cCorreosElectronicos"];
                        cat.dtFechaRegistro = (DateTime)reader["dtFechaRegistro"];
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

    }
}
