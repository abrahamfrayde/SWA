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
    public class CatTiposSolicitudDAL
    {
        //Define la variable cn de tipo Conexion
        Conexion.Conexion cn;

        // Constructor de la clase CatTiposSolicitudDAL
        public CatTiposSolicitudDAL()
        {
            // Crea una instacia cn de la clase Conexion
            cn = new Conexion.Conexion();
        }

        // Método para insertar un Tipo de Solicitud en la tabla tbl_cat_tipossolicitud, utilizando el procedimiento almacenado SPD_CAT_TIPOSSOLICITUD_INS
        // Recibe el objeto _CatTiposSolicitud con los datos a insertar y una vez insertado devuelve el id del registro insertado
        public int InsertarTiposSolicitud(CatTiposSolicitud _CatTiposSolicitud)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro insertado
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_TIPOSSOLICITUD_INS", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@cNombre", _CatTiposSolicitud.cNombre);
                    command.Parameters.AddWithValue("@iIdRama", _CatTiposSolicitud.ObjRamas.iIdRama);
                    command.Parameters.AddWithValue("@iIdProceso", _CatTiposSolicitud.ObjProcesos.iIdProceso);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _CatTiposSolicitud.ObjUsuarioGestion.iIdUsuario);

                    // Abre la conexión a la BD
                    cn.OpenConnection();
                    // Ejecuta la instrucción y la variable id recibe el valor que devuelve el procedimiento almacenado
                    id = (int)command.ExecuteScalar();
                }
            }
            // Manejo de las excepciones de bloque try
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro" + ex.Message);
            }
            // Ejecución existosa del bloque try
            finally
            {
                // Cierra la conexión a la BD
                cn.CloseConnection();
            }
            // Devuelve el id del registro insertado
            return id;
        }

        // Método para modificar un Tipo de Solicitud en la tabla tbl_cat_tipossolicitud, utilizando el procedimiento almacenado SPD_CAT_TIPOSSOLICITUD_UPD
        // Recibe el objeto _CatTiposSolicitud con los datos a modificar y una vez modificado devuelve el id del registro modificado
        public int ModificarTiposSolicitud(CatTiposSolicitud _CatTiposSolicitud)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_TIPOSSOLICITUD_UPD", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdTipoSolicitud", _CatTiposSolicitud.iIdTipoSolicitud);
                    command.Parameters.AddWithValue("@cNombre", _CatTiposSolicitud.cNombre);
                    command.Parameters.AddWithValue("@iIdRama", _CatTiposSolicitud.ObjRamas.iIdRama);
                    command.Parameters.AddWithValue("@iIdProceso", _CatTiposSolicitud.ObjProcesos.iIdProceso);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _CatTiposSolicitud.ObjUsuarioGestion.iIdUsuario);

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

        // Método para eliminar un Tipo de Solicitud en la tabla tbl_cat_tipossolicitud, utilizando el procedimiento almacenado SPD_CAT_TIPOSSOLICITUD_DEL
        // Recibe el objeto _CatTiposSolicitud con los datos a eliminar y una vez eliminado devuelve el id del registro eliminado
        public int EliminarTiposSolicitud(CatTiposSolicitud _CatTiposSolicitud)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            // Esto debido a que el procedimiento eliminar únicamente modifica el valor bActivo de la tabla, por lo cual es finalmente un proceso de modificación
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_TIPOSSOLICITUD_DEL", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdTipoSolicitud", _CatTiposSolicitud.iIdTipoSolicitud);

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

        // Método para obtener un Tipo de Solicitud o mas Tipos de Solicitudes de la tabla tbl_cat_tipossolicitud, utilizando el procedimiento almacenado SPD_CAT_GET
        // Recibe el id del tipo de solicitud a obtener, este parámetro no es requerido
        // Recibe el filtro para el nombre de el o los Tipos de Solicitudes a obtener que cumplan con este filtro, este parámetro no es requerido
        // El resultado de la consulta a obtener dependera de los parámetros enviados en caso que no se envíe ninguno se obtiene toda la tabla
        // Los resultados son devueltos en una lista de objetos de tipo CatTiposSolicitud
        public List<CatTiposSolicitud> ObtenerTiposSolicitud(int id = 0, string filtro = null)
        {
            // Define e incializa la variable tipo que indica al procedimiento a que tabla hace referencia
            string tipo = "tipossolicitud";
            // Define e incializa la lista que devolverá el método
            List<CatTiposSolicitud> list = new List<CatTiposSolicitud>();
            // Define _CatTiposSolicitud de tipo CatTiposSolicitud en donde pondrá el resultado de cada registro el cual se irá añadiendo a la lista que se devolverá
            CatTiposSolicitud _CatTiposSolicitud;
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
                    // El tipo SqlDataReader permite leer los datos obtenidos registro por registro para asignarlos al objeto _CatTiposSolicitud y posteriormente agregarlo a la lista 
                    SqlDataReader reader = command.ExecuteReader();

                    // Realizamos un ciclo para leer cada registro obtenido mientras haya registros
                    while (reader.Read())
                    {
                        // Creamos la instancia de _CatTiposSolicitud en donde se pondrán los datos del registro
                        _CatTiposSolicitud = new CatTiposSolicitud();
                        // Definimos y creamos los objetos asociados a esta entidad _TiposSolicitud en donde se depositarán los valores del registro correspondiente a estos objetos
                        _CatTiposSolicitud.ObjProcesos = new CatProcesos();
                        _CatTiposSolicitud.ObjRamas = new CatRamas();
                        _CatTiposSolicitud.ObjUsuarioGestion = new Usuarios();

                        // Asignamos los valores del registro al objeto _CatTiposSolicitud
                        _CatTiposSolicitud.iIdTipoSolicitud = (int)reader["iIdTipoSolicitud"];
                        _CatTiposSolicitud.cNombre = (string)reader["cNombre"];
                        _CatTiposSolicitud.ObjRamas.iIdRama = (int)reader["iIdRama"];
                        _CatTiposSolicitud.ObjRamas.cNombre = (string)reader["r.cNombre"];
                        _CatTiposSolicitud.ObjProcesos.iIdProceso = (int)reader["iIdProceso"];
                        _CatTiposSolicitud.ObjProcesos.cNombre = (string)reader["p.cNombre"];
                        _CatTiposSolicitud.ObjUsuarioGestion.iIdUsuario = (int)reader["iIdUsuarioGestion"];
                        _CatTiposSolicitud.dtFechaRegistro = (DateTime)reader["dtFechaRegistro"];
                        _CatTiposSolicitud.bActivo = Convert.ToBoolean(reader["bActivo"]);

                        // Agregamos el objeto con los datos a la lista que se devolverá
                        list.Add(_CatTiposSolicitud);
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
