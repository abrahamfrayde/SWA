using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;
using ESistema;
using ESistema.Catalogos;
using System.Data;
using System.Data.SqlClient;

namespace DSistema
{
    public class CatStatusOrdenDAL
    {
        private Conexion.Conexion cn;

        public CatStatusOrdenDAL()
        {
            cn = new Conexion.Conexion();
        }

         public int InsertarStatus(CatStatusOrden _catStatusOrden)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_STATUS_ORDEN_INS", cn.Connection))
                {
                    // Establece los valores que recibirá el procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;                    
                    command.Parameters.AddWithValue("@iIdProceso",_catStatusOrden.objProcesos.iIdProceso);
                    command.Parameters.AddWithValue("@iIdStatus", _catStatusOrden.objStatus.iIdStatus);
                    command.Parameters.AddWithValue("@iIdStatusDestino", _catStatusOrden.objStatusDestino.iIdStatus);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _catStatusOrden.ObjUsuarioGestion.iIdUsuario);                    

                    // Abre la conexión a la BD
                    cn.OpenConnection();

                    //Ejecuta la instrucción y la variable id recibe el valor que devuelve el procedimiento almacenado
                    id = (int)command.ExecuteScalar();
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro: " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return id;
        }
        public int ModificarStatus(CatStatusOrden _catStatusOrden)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_STATUS_ORDEN_UPD", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdStatusOrden", _catStatusOrden.iIdStatusOrden);                    
                    command.Parameters.AddWithValue("@iIdStatus", _catStatusOrden.objStatus.iIdStatus);
                    command.Parameters.AddWithValue("@iIdStatusDestino", _catStatusOrden.objStatusDestino.iIdStatus);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _catStatusOrden.ObjUsuarioGestion.iIdUsuario);

                    // Abre la conexión a la BD
                    cn.OpenConnection();

                    // Ejecuta la instrucción y la variable id recibe el valor que devuelve el procedimiento almacenado
                    id = (int)command.ExecuteScalar();
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
            return id;
        }
        public int EliminarStatus(CatStatusOrden _catStatusOrden)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            // Esto debido a que el procedimiento eliminar únicamente modifica el valor bActivo de la tabla, por lo cual es finalmente un proceso de modificación
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_STATUS_ORDEN_DEL", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdStatusOrden", _catStatusOrden.iIdStatusOrden);

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
        public List<CatStatusOrden> ObtenerStatusOrden(int id = 0, string filtro = null)
        {
            // Define e incializa la variable tipo que indica al procedimiento a que tabla hace referencia
            string tipo = "status";
            // Define e incializa la lista que devolverá el método
            List<CatStatusOrden> list = new List<CatStatusOrden>();
            // Define CatStatus de tipo CatRamas en donde pondrá el resultado de cada registro el cual se irá añadiendo a la lista que se devolverá
            CatStatusOrden _CatStatusOrden;
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
                        _CatStatusOrden = new CatStatusOrden();
                        _CatStatusOrden.objProcesos = new CatProcesos();
                        _CatStatusOrden.ObjUsuarioGestion = new Usuarios();

                        // Asignamos los valores del registro al objeto _CatProcesos                        
                        _CatStatusOrden.objProcesos.iIdProceso       = (int)reader["iIdProceso"];
                        _CatStatusOrden.objStatus.iIdStatus          = (int)reader["iIdStatus"];
                        _CatStatusOrden.objStatusDestino.iIdStatus   = (int)reader["iIdStatusDestino"];
                        _CatStatusOrden.ObjUsuarioGestion.iIdUsuario = (int)reader["iIdUsuarioGestion"];
                        _CatStatusOrden.dtFechaRegistro              = (DateTime)reader["dtFechaRegistro"];
                        _CatStatusOrden.bActivo                      = Convert.ToBoolean(reader["bActivo"]);

                        // Agregamos el objeto con los datos a la lista que se devolverá
                        list.Add(_CatStatusOrden);
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
