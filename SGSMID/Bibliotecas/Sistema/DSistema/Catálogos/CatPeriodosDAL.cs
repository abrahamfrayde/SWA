using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ESistema;
using System.Data;

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
                    command.Parameters.AddWithValue("@cNombre", _catperiodos.cNombre);
                    command.Parameters.AddWithValue("@dtFechaInicial", _catperiodos.dtFechaInicial);
                    command.Parameters.AddWithValue("@dtFechaFinal", _catperiodos.dtFechaFinal);
                    command.Parameters.AddWithValue("@cPresidenteMunicipal", _catperiodos.cPresidenteMunicipal);
                    command.Parameters.AddWithValue("@idUsuario", _catperiodos.iIdUsuario);

                    cn.OpenConnection();
                    id = (int)command.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del periodo" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del periodo" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return id;

        }


        public void modificarPeriodo(CatPeriodos _catperiodos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_PERIODOS_UPD", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdperiodo", _catperiodos.iIdPeriodo);
                    command.Parameters.AddWithValue("@cNombre", _catperiodos.cNombre);
                    command.Parameters.AddWithValue("@dtFechaInicial", _catperiodos.dtFechaInicial);
                    command.Parameters.AddWithValue("@dtFechaFinal", _catperiodos.dtFechaInicial);
                    command.Parameters.AddWithValue("@cPresidenteMunicipal", _catperiodos.cPresidenteMunicipal);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();

                }

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro del periodo" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro del periodo" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }

        /// <summary>
        /// Clase para eliminar registro en la tabla Periodos
        /// </summary>
        /// <param name="_catperiodos"></param>
        public void eliminarPeriodo(CatPeriodos _catperiodos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_PERIODOS_DEL", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iIdPeriodo", _catperiodos.iIdPeriodo);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro del periodo" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro del periodo" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }
        public List<CatPeriodos> obtenerPeriodos(int id = 0, string filtro = null)
        {
            List<CatPeriodos> list = new List<CatPeriodos>();
            CatPeriodos per;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_PERIODOS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@tipo", "periodos");
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        per = new CatPeriodos();
                        per.iIdPeriodo = (int)reader["iIdPeriodo"];
                        per.cNombre = (string)reader["cNombre"];
                        per.dtFechaInicial = (DateTime)reader["dtFechaInicial"];
                        per.dtFechaFinal = (DateTime)reader["dtFechaFinal"];
                        per.cPresidenteMunicipal = (string)reader["cPresidenteMunicipal"];
                        per.iIdUsuario = (int)reader["iIdUsuarioGestion"];
                        per.dtFechaRegistro = (DateTime)reader["dtFechaRegistro"];
                        list.Add(per);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("SQl Error en obtener los datos de periodo" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Code Error en obtener los datos de periodo" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }

    }
}
