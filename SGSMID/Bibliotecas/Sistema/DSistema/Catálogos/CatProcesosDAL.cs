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
    public class CatProcesosDAL
    {
        //Propiedades de la clase
        private Conexion.Conexion cn;

        //Constructor por default de la clase
        public CatProcesosDAL()
        {
            cn = new Conexion.Conexion();
        }

        public int InsertarProceso(CatProcesos _catProceso)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_PROCESOS_INS", cn.Connection))
                {
                    // Establece los valores que recibirá el procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cNombre", _catProceso.cNombre);
                    command.Parameters.AddWithValue("@iIdRama", _catProceso.objRamas.iIdRama);
                    command.Parameters.AddWithValue("@iIdPeriodo", _catProceso.objPeriodos.iIdPeriodo);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _catProceso.ObjUsuarioGestion.iIdUsuario);

                    // Abre la conexión a la BD
                    cn.OpenConnection();

                    //Ejecuta la instrucción y la variable id recibe el valor que devuelve el procedimiento almacenado
                    id = (int)command.ExecuteScalar();
                    //command.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del Proceso" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del Proceso" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return id;
        }
        public void ModificarProceso(CatProcesos _catProceso)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            //int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_PROCESOS_UPD", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdProceso", _catProceso.iIdProceso);
                    command.Parameters.AddWithValue("@cNombre", _catProceso.cNombre);
                    command.Parameters.AddWithValue("@iIdRama", _catProceso.objRamas.iIdRama);
                    command.Parameters.AddWithValue("@iIdPeriodo", _catProceso.objPeriodos.iIdPeriodo);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _catProceso.ObjUsuarioGestion.iIdUsuario);

                    // Abre la conexión a la BD
                    cn.OpenConnection();

                    // Ejecuta la instrucción y la variable id recibe el valor que devuelve el procedimiento almacenado
                    //id = (int)command.ExecuteScalar();
                    command.ExecuteNonQuery();
                }
            }
            // Manejo de las excepciones de bloque try
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro" + ex.Message);
            }
            // Ejecución existosa del bloque try
            finally
            {
                // Cierra la conexión a la BD
                cn.CloseConnection();
            }
            // Devuelve el id del registro modificado
            //return id;
        }
        public int EliminarProceso(CatProcesos _catProceso)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            // Esto debido a que el procedimiento eliminar únicamente modifica el valor bActivo de la tabla, por lo cual es finalmente un proceso de modificación
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_PROCESOS_DEL", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdProceso", _catProceso.iIdProceso);

                    // Abre la conexión a la BD
                    cn.OpenConnection();

                    // Ejecuta la instrucción y la variable id recibe el valor que devuelve el procedimiento almacenado
                    id = (int)command.ExecuteScalar();
                }
            }
            // Manejo de las excepciones de bloque try
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro" + ex.Message);
            }
            // Ejecución existosa del bloque try
            finally
            {
                // Cierra la conexión a la BD
                cn.CloseConnection();
            }
            // Devuelve el id del registro eliminado
            return id;
        }
        public List<CatProcesos> ObtenerProceso(int id = 0, string filtro = null)
        {
            // Define e incializa la variable tipo que indica al procedimiento a que tabla hace referencia
            string tipo = "procesos";
            // Define e incializa la lista que devolverá el método
            List<CatProcesos> list = new List<CatProcesos>();
            // Define _CatRamas de tipo CatRamas en donde pondrá el resultado de cada registro el cual se irá añadiendo a la lista que se devolverá
            CatProcesos _CatProcesos;
            // Bloque para manejos de errores
            try
            {
                // Crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_GET", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@id", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@tipo", tipo);
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);

                    // Abre la conexión a la BD
                    cn.OpenConnection();

                    // Define y crea la instancia reader de tipo SqlDataReader en donde almacenará los resultados al ejecutar la instrucción
                    // El tipo SqlDataReader permite leer los datos obtenidos registro por registro para asignarlos al objeto _CatProcesos
                    SqlDataReader reader = command.ExecuteReader();

                    // Realizamos un ciclo para leer cada registro obtenido mientras haya registros
                    while (reader.Read())
                    {
                        // Creamos la instancia de _CatProcesos en donde se pondrán los datos del registro
                        _CatProcesos = new CatProcesos();
                        // Definimos y creamos los objetos asociados a esta entidad _CatProcesos
                        _CatProcesos.objPeriodos = new CatPeriodos();
                        _CatProcesos.objRamas = new CatRamas();
                        _CatProcesos.ObjUsuarioGestion = new Usuarios();

                        // Asignamos los valores del registro al objeto _CatProcesos
                        _CatProcesos.iIdProceso = (int)reader["iIdProceso"];
                        _CatProcesos.cNombre = (string)reader["cNombre"];
                        _CatProcesos.objRamas.iIdRama = (int)reader["iIdRama"];
                        _CatProcesos.objRamas.cNombre = (string)reader["r.cNombre"];
                        _CatProcesos.objPeriodos.iIdPeriodo = (int)reader["iIdPeriodo"];
                        _CatProcesos.objPeriodos.cNombre = (string)reader["pe.cNombre"];
                        _CatProcesos.ObjUsuarioGestion.iIdUsuario = (int)reader["iIdUsuarioGestion"];
                        _CatProcesos.ObjUsuarioGestion.cNombreUsuario = (string)reader["us.cNombre"];
                        _CatProcesos.dtFechaRegistro = (DateTime)reader["dtFechaRegistro"];

                        // Agregamos el objeto con los datos a la lista que se devolverá
                        list.Add(_CatProcesos);
                    }
                }
            }
            // Manejo de las excepciones de bloque try
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener los registros" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener los registros" + ex.Message);
            }
            // Ejecución existosa del bloque try
            finally
            {
                // Cierra la conexión a la BD
                cn.CloseConnection();
            }
            // Devuelve la lista con los resultados obtenido
            return list;
        }
    }
}
