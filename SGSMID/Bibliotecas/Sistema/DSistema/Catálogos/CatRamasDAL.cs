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
    public class CatRamasDAL
    {
        //Define la variable cn de tipo Conexion
        Conexion.Conexion cn;

        // Constructor de la clase CatRamasDAL
        public CatRamasDAL()
        {
            // Crea una instacia cn de la clase Conexion
            cn = new Conexion.Conexion();
        }

        // Método para insertar una rama en la tabla tbl_cat_ramas, utilizando el procedimiento almacenado SPD_CAT_RAMAS_INS
        // Recibe el objeto _CatRamas con los datos a insertar y una vez insertado devuelve el id del registro insertado
        public int InsertarRamas(ESistema.Catalogos.CatRamas _CatRamas)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro insertado
            int id = 0;
            // Bloque para manejos de errores 
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_RAMAS_INS", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@cNombre", _CatRamas.cNombre);
                    command.Parameters.AddWithValue("@iIdCentroCosto", _CatRamas.ObjCentroCostos.iIdCentroCosto);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _CatRamas.ObjUsuarioGestion.iIdUsuario);

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

        // Método para modificar una rama en la tabla tbl_cat_ramas, utilizando el procedimiento almacenado SPD_CAT_RAMAS_UPD
        // Recibe el objeto _CatRamas con los datos a modificar y una vez modificado devuelve el id del registro modificado
        public int ModificarRamas(ESistema.Catalogos.CatRamas _CatRamas)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_RAMAS_UPD", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdRama", _CatRamas.iIdRama);
                    command.Parameters.AddWithValue("@cNombre", _CatRamas.cNombre);
                    command.Parameters.AddWithValue("@iIdCentroCosto", _CatRamas.ObjCentroCostos.iIdCentroCosto);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _CatRamas.ObjUsuarioGestion.iIdUsuario);

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

        // Método para eliminar una rama en la tabla tbl_cat_ramas, utilizando el procedimiento almacenado SPD_CAT_RAMAS_DEL
        // Recibe el objeto _CatRamas con los datos a eliminar y una vez eliminado devuelve el id del registro eliminado
        public int EliminarRamas(ESistema.Catalogos.CatRamas _CatRamas)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            // Esto debido a que el procedimiento eliminar únicamente modifica el valor bActivo de la tabla, por lo cual es finalmente un proceso de modificación
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_CAT_RAMAS_DEL", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdRama", _CatRamas.iIdRama);

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

        // Método para obtener una rama o mas ramas de la tabla tbl_cat_ramas, utilizando el procedimiento almacenado SPD_CAT_GET
        // Recibe el id de la rama a obtener, este parámetro no es requerido
        // Recibe el filtro para el nombre de la o las rama a obtener que cumplan con este filtro, este parámetro no es requerido
        // El resultado de la consulta a obtener dependera de los parámetros enviados en caso que no se envíe ninguno se obtiene toda la tabla
        // Los resultados son devueltos en una lista de objetos de tipo CatRamas
        public List<CatRamas> ObtenerRamas(int id = 0, string filtro = null)
        {
            // Define e incializa la variable tipo que indica al procedimiento a que tabla hace referencia
            string tipo = "ramas";
            // Define e incializa la lista que devolverá el método
            List<CatRamas> list = new List<CatRamas>();
            // Define _CatRamas de tipo CatRamas en donde pondrá el resultado de cada registro el cual se irá añadiendo a la lista que se devolverá
            CatRamas _CatRamas;
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
                    // El tipo SqlDataReader permite leer los datos obtenidos registro por registro para asignarlos al objeto _CatRamas y posteriormente agregarlo a la lista 
                    SqlDataReader reader = command.ExecuteReader();

                    // Realizamos un ciclo para leer cada registro obtenido mientras haya registros
                    while (reader.Read())
                    {
                        // Creamos la instancia de _CatRamas en donde se pondrán los datos del registro
                        _CatRamas = new CatRamas();
                        // Definimos y creamos los objetos asociados a esta entidad _CatRamas en donde se depositarán los valores del registro correspondiente a estos objetos
                        _CatRamas.ObjCentroCostos = new CentroCostos();
                        _CatRamas.ObjUsuarioGestion = new Usuarios();

                        // Asignamos los valores del registro al objeto _CatRamas
                        _CatRamas.iIdRama = (int)reader["iIdRama"];
                        _CatRamas.cNombre = (string)reader["cNombre"];
                        _CatRamas.ObjCentroCostos.iIdCentroCosto = (int)reader["iIdCentroCosto"];
                        _CatRamas.ObjUsuarioGestion.iIdUsuario = (int)reader["iIdUsuario"];
                        _CatRamas.dtFechaRegistro = (DateTime)reader["dtFechaRegistro"];
                        _CatRamas.bActivo = Convert.ToBoolean(reader["bActivo"]);

                        // Agregamos el objeto con los datos a la lista que se devolverá
                        list.Add(_CatRamas);
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
