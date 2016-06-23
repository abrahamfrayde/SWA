using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESistema;
using System.Data;
using System.Data.SqlClient;

namespace DSistema
{
    public class CatPeriodosDAL
    {
        private Conexion.Conexion cn;

        public CatPeriodosDAL()
        {
            cn = new Conexion.Conexion();
        }
        /// <summary>
        /// Clase para insertar registro en la tabla Periodos
        /// </summary>
        /// <param name="_catperiodos"></param>
        /// <returns></returns>
        public int insertarPeriodo(CatPeriodos _catperiodos)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_PERIODOS_INS", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cNombre", _catperiodos.cNombre_p);
                    command.Parameters.AddWithValue("@dtFechaInicial", _catperiodos.dtFechaInicial_p);
                    command.Parameters.AddWithValue("@dtFechaFinal", _catperiodos.dtFechaFinal_p);
                    command.Parameters.AddWithValue("@cPresidenteMunicipal", _catperiodos.cPresidenteMuninicipal_p);
                    command.Parameters.AddWithValue("@Activo", _catperiodos.bActivo_p);
                    command.Parameters.AddWithValue("@idUsuario", _catperiodos.iIdUsuario_p);
                    
                    cn.OpenConnection();
                    id = (int)command.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del puesto" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del puesto" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return id;

        }

        /// <summary>
        /// Clase para eliminar registro en la tabla Periodos
        /// </summary>
        /// <param name="_catperiodos"></param>
        public void EliminaPeriodo(CatPeriodos _catperiodos)
        {
            var command = new SqlCommand("SPD_CAT_PERIODOS_DEL", cn.Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_periodo", _catperiodos.iIdPeriodo_p);        
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el store procedure" + ex.Message);
            }
            cn.CloseConnection();
        }

        public void modificarPeriodo(CatPeriodos _catperiodos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_PERIODOS_UPD", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_p", _catperiodos.iIdPeriodo_p);
                    command.Parameters.AddWithValue("@cNombre_p", _catperiodos.cNombre_p);
                    command.Parameters.AddWithValue("@FechaInicial", _catperiodos.dtFechaInicial_p);
                    command.Parameters.AddWithValue("@FechaFinal", _catperiodos.dtFechaInicial_p);
                    command.Parameters.AddWithValue("@PresidenteMunicipal", _catperiodos.cPresidenteMuninicipal_p);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();

                }

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro del puesto" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro del puesto" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }

       public List<CatPeriodos> obtenerPeriodos()
        {
            List<CatPeriodos> list = new List<CatPeriodos>();
            CatPeriodos per;
            try
            {
                var command = new SqlCommand("SPD_CAT_PERIODOS_GET", cn.Connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    per = new CatPeriodos();
                    per.iIdPeriodo_p = (int)reader["idPeriodo"];
                    per.cNombre_p = (string)reader["nombre_per"];
                    per.dtFechaInicial_p = (DateTime)reader["fecha_inicial"];
                    per.dtFechaFinal_p = (DateTime)reader["fecha_final"];
                    per.cPresidenteMuninicipal_p = (string)reader["presidente_municipal"];
                    per.dtFechaRegistro_p = (DateTime)reader["fecha_registro"];
                    per.iIdUsuario_p = (int)reader["id_usuario_gestion"];
                    list.Add(per);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("SQl Error en obtener los datos de software" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Code Error en obtener los datos de software" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }

    }
}
