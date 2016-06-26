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
    public class CatStatusDAL
    {
        //Propiedades de la clase
        private Conexion.Conexion cn;

        //Constructor por default de la clase
        public CatStatusDAL()
        {
            cn = new Conexion.Conexion();
        }

        public int InsertarStatus(CatStatus _catStatus)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_STATUS_INS", cn.Connection))
                {
                    // Establece los valores que recibirá el procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cNombre", _catStatus.cNombre);
                    command.Parameters.AddWithValue("@iIdProceso",_catStatus.objProcesos.iIdProceso);
                    command.Parameters.AddWithValue("@iOrden", _catStatus.iOrden);                    
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _catStatus.ObjUsuarioGestion.iIdUsuario);
               
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
        public int ModificarStatus(CatStatus _catStatus)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_STATUS_UPD", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdStatus", _catStatus.iIdStatus);
                    command.Parameters.AddWithValue("@cNombre", _catStatus.cNombre);
                    command.Parameters.AddWithValue("@iIdProceso", _catStatus.objProcesos.iIdProceso);
                    command.Parameters.AddWithValue("@iOrden", _catStatus.iOrden);                    
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _catStatus.ObjUsuarioGestion.iIdUsuario);

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
        public int EliminarProceso(CatStatus _catStatus)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            // Esto debido a que el procedimiento eliminar únicamente modifica el valor bActivo de la tabla, por lo cual es finalmente un proceso de modificación
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_STATUS_DEL", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdRama", _catStatus.iIdStatus);

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
        public List<CatStatus> ObtenerStatus(int id = 0, string filtro = null)
        {
            // Define e incializa la variable tipo que indica al procedimiento a que tabla hace referencia
            string tipo = "status";
            // Define e incializa la lista que devolverá el método
            List<CatStatus> list = new List<CatStatus>();
            // Define CatStatus de tipo CatRamas en donde pondrá el resultado de cada registro el cual se irá añadiendo a la lista que se devolverá
            CatStatus _CatStatus;
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
                        _CatStatus = new CatStatus();                        
                        _CatStatus.objProcesos = new CatProcesos();                        
                        _CatStatus.ObjUsuarioGestion = new Usuarios();

                        // Asignamos los valores del registro al objeto _CatProcesos
                        _CatStatus.iIdStatus                    = (int)reader["iIdStatus"];
                        _CatStatus.cNombre                      = (string)reader["cNombre"];
                        _CatStatus.objProcesos.iIdProceso       = (int)reader["iIdProceso"];
                        _CatStatus.iOrden                       = (int)reader["iOrden"];
                        _CatStatus.ObjUsuarioGestion.iIdUsuario = (int)reader["iIdUsuarioGestion"];
                        _CatStatus.dtFechaRegistro              = (DateTime)reader["dtFechaRegistro"];
                        _CatStatus.bActivo                      = Convert.ToBoolean(reader["bActivo"]);

                        // Agregamos el objeto con los datos a la lista que se devolverá
                        list.Add(_CatStatus);
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
