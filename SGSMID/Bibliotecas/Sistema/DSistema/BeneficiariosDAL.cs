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
    public class BeneficiariosDAL
    {
        //Define la variable cn de tipo Conexion
        Conexion.Conexion cn;

        // Constructor de la clase BeneficiariosDAL
        public BeneficiariosDAL()
        {
            // Crea una instacia cn de la clase Conexion
            cn = new Conexion.Conexion();
        }

        // Método para insertar un beneficiario en la tabla tbl_beneficiarios, utilizando el procedimiento almacenado SPD_BENEFICIARIOS_INS
        // Recibe el objeto _Beneficiarios con los datos a insertar y una vez insertado devuelve el id del registro insertado
        public int InsertarBeneficiarios(Beneficiarios _Beneficiarios)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro insertado
            int id = 0;
            // Bloque para manejos de errores 
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_BENEFICIARIOS_INS", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@cNombre", _Beneficiarios.cNombre);
                    command.Parameters.AddWithValue("@cApellidoPaterno", _Beneficiarios.cApellidoPaterno);
                    command.Parameters.AddWithValue("@cApellidoMaterno", _Beneficiarios.cApellidoMaterno);
                    command.Parameters.AddWithValue("@iNumeroInterior", _Beneficiarios.iNumeroInterior);
                    command.Parameters.AddWithValue("@cLetraInterior", _Beneficiarios.cLetraInterior);
                    command.Parameters.AddWithValue("@iNumeroExterior", _Beneficiarios.iNumeroExterior);
                    command.Parameters.AddWithValue("@cLetraExterior", _Beneficiarios.cLetraExterior);
                    command.Parameters.AddWithValue("@iCallePrincipal", _Beneficiarios.iCallePrincipal);
                    command.Parameters.AddWithValue("@cLetraPrincipal", _Beneficiarios.cLetraPrincipal);
                    command.Parameters.AddWithValue("@iCalleA", _Beneficiarios.iCalleA);
                    command.Parameters.AddWithValue("@cLetraA", _Beneficiarios.cLetraA);
                    command.Parameters.AddWithValue("@iCalleB", _Beneficiarios.iCalleB);
                    command.Parameters.AddWithValue("@cLetraB", _Beneficiarios.cLetraB);
                    command.Parameters.AddWithValue("@cNombreLocalidad", _Beneficiarios.cNombreLocalidad);
                    command.Parameters.AddWithValue("@iIdLocalidad", _Beneficiarios.iIdLocalidad);
                    command.Parameters.AddWithValue("@cAliasLocalidad", _Beneficiarios.cAliasLocalidad);
                    command.Parameters.AddWithValue("@iIdColonia", _Beneficiarios.iIdColonia);
                    command.Parameters.AddWithValue("@cNombreColonia", _Beneficiarios.cNombreColonia);
                    command.Parameters.AddWithValue("@cRFC", _Beneficiarios.cRFC);
                    command.Parameters.AddWithValue("@cCURP", _Beneficiarios.cCURP);
                    command.Parameters.AddWithValue("@dtFechaNacimiento", _Beneficiarios.dtFechaNacimiento);
                    command.Parameters.AddWithValue("@iTelefono", _Beneficiarios.iTelefono);
                    command.Parameters.AddWithValue("@cEmail", _Beneficiarios.cEmail);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _Beneficiarios.ObjUsuarioGestion.iIdUsuarioGestion);

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

        // Método para modificar un beneficiario en la tabla tbl_beneficiarios, utilizando el procedimiento almacenado SPD_BENEFICIARIOS_UPD
        // Recibe el objeto _Beneficiarios con los datos a modificar y una vez modificado devuelve el id del registro modificado
        public int ModificarBeneficiarios(Beneficiarios _Beneficiarios)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            int id = 0;
            // Bloque para manejos de errores 
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_BENEFICIARIOS_UPD", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@cNombre", _Beneficiarios.cNombre);
                    command.Parameters.AddWithValue("@cApellidoPaterno", _Beneficiarios.cApellidoPaterno);
                    command.Parameters.AddWithValue("@cApellidoMaterno", _Beneficiarios.cApellidoMaterno);
                    command.Parameters.AddWithValue("@iNumeroInterior", _Beneficiarios.iNumeroInterior);
                    command.Parameters.AddWithValue("@cLetraInterior", _Beneficiarios.cLetraInterior);
                    command.Parameters.AddWithValue("@iNumeroExterior", _Beneficiarios.iNumeroExterior);
                    command.Parameters.AddWithValue("@cLetraExterior", _Beneficiarios.cLetraExterior);
                    command.Parameters.AddWithValue("@iCallePrincipal", _Beneficiarios.iCallePrincipal);
                    command.Parameters.AddWithValue("@cLetraPrincipal", _Beneficiarios.cLetraPrincipal);
                    command.Parameters.AddWithValue("@iCalleA", _Beneficiarios.iCalleA);
                    command.Parameters.AddWithValue("@cLetraA", _Beneficiarios.cLetraA);
                    command.Parameters.AddWithValue("@iCalleB", _Beneficiarios.iCalleB);
                    command.Parameters.AddWithValue("@cLetraB", _Beneficiarios.cLetraB);
                    command.Parameters.AddWithValue("@cNombreLocalidad", _Beneficiarios.cNombreLocalidad);
                    command.Parameters.AddWithValue("@iIdLocalidad", _Beneficiarios.iIdLocalidad);
                    command.Parameters.AddWithValue("@cAliasLocalidad", _Beneficiarios.cAliasLocalidad);
                    command.Parameters.AddWithValue("@iIdColonia", _Beneficiarios.iIdColonia);
                    command.Parameters.AddWithValue("@cNombreColonia", _Beneficiarios.cNombreColonia);
                    command.Parameters.AddWithValue("@cRFC", _Beneficiarios.cRFC);
                    command.Parameters.AddWithValue("@cCURP", _Beneficiarios.cCURP);
                    command.Parameters.AddWithValue("@dtFechaNacimiento", _Beneficiarios.dtFechaNacimiento);
                    command.Parameters.AddWithValue("@iTelefono", _Beneficiarios.iTelefono);
                    command.Parameters.AddWithValue("@cEmail", _Beneficiarios.cEmail);
                    command.Parameters.AddWithValue("@iIdUsuarioGestion", _Beneficiarios.ObjUsuarioGestion.iIdUsuarioGestion);

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
            // Devuelve el id del registro insertado
            return id;
        }

        // Método para eliminar un beneficiario en la tabla tbl_beneficiarios, utilizando el procedimiento almacenado SPD_BENEFICIARIOS_DEL
        // Recibe el objeto _Beneficiarios con los datos a eliminar y una vez eliminado devuelve el id del registro eliminado
        public int EliminarBeneficiarios(Beneficiarios _Beneficiarios)
        {
            // Define e inicializa la variable id en donde recibira el valor devuelto por el procedimiento almacenado, que es el id del registro modificado
            // Esto debido a que el procedimiento eliminar únicamente modifica el valor bActivo de la tabla, por lo cual es finalmente un proceso de modificación
            int id = 0;
            // Bloque para manejos de errores
            try
            {
                // Define y crea la instancia command de la clase SqlCommand que representa una instrucción SQL
                using (SqlCommand command = new SqlCommand("SPD_BENEFICIARIOS_DEL", cn.Connection))
                {
                    // Establece que es un procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Establece los valores que recibirá el procedimiento almacenado
                    command.Parameters.AddWithValue("@iIdBeneficiario", _Beneficiarios.iIdBeneficiario);

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

        // Método para obtener un beneficiario o mas beneficiarios de la tabla tbl_beneficiarios, utilizando el procedimiento almacenado SPD_CAT_GET
        // Recibe el id del beneficiario a obtener, este parámetro no es requerido
        // Recibe el filtro con el nombre del o los beneficiarios a obtener que cumplan con este filtro, este parámetro no es requerido
        // El resultado de la consulta a obtener dependera de los parámetros enviados en caso que no se envíe ninguno se obtiene toda la tabla
        // Los resultados son devueltos en una lista de objetos de tipo Beneficiarios
        public List<Beneficiarios> ObtenerBeneficiarios(int id = 0, string filtro = null)
        {
            // Define e incializa la variable tipo que indica al procedimiento a que tabla hace referencia
            string tipo = "beneficiarios";
            // Define e incializa la lista que devolverá el método
            List<Beneficiarios> list = new List<Beneficiarios>();
            // Define _Beneficiarios de tipo Beneficiarios en donde pondrá el resultado de cada registro el cual se irá añadiendo a la lista que se devolverá
           Beneficiarios _Beneficiarios;
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
                    // El tipo SqlDataReader permite leer los datos obtenidos registro por registro para asignarlos al objeto _Beneficiarios y posteriormente agregarlo a la lista 
                    SqlDataReader reader = command.ExecuteReader();

                    // Realizamos un ciclo para leer cada registro obtenido mientras haya registros
                    while (reader.Read())
                    {
                        // Creamos la instancia de _Beneficiarios en donde se pondrán los datos del registro
                        _Beneficiarios = new Beneficiarios();
                        // Definimos y creamos los objetos asociados a esta entidad _Benefciarios en donde se depositarán los valores del registro correspondiente a estos objetos
                        _Beneficiarios.ObjUsuarioGestion = new Usuarios();

                        // Asignamos los valores del registro al objeto _Beneficiarios

                        _Beneficiarios.iIdBeneficiario = (int)reader["iIdBeneficiario"];
                        _Beneficiarios.cNombre = (string)reader["cNombre"];
                        _Beneficiarios.cApellidoPaterno = (string)reader["cApellidoPaterno"];
                        _Beneficiarios.cApellidoMaterno = (string)reader["cApellidoMaterno"];
                        _Beneficiarios.cNombreCompleto = (string)reader["cNombreCompleto"];
                        _Beneficiarios.iNumeroInterior = (int)reader["iNumeroInterior"];
                        _Beneficiarios.cLetraInterior = (string)reader["cLetraInterior"];
                        _Beneficiarios.iNumeroExterior = (int)reader["iNumeroExterior"];
                        _Beneficiarios.cLetraExterior = (string)reader["cLetraExterior"];
                        _Beneficiarios.iCallePrincipal = (int)reader["iCallePrincipal"];
                        _Beneficiarios.cLetraPrincipal = (string)reader["cLetraPrincipal"];
                        _Beneficiarios.iCalleA = (int)reader["iCalleA"];
                        _Beneficiarios.cLetraA = (string)reader["cLetraA"];
                        _Beneficiarios.iCalleB = (int)reader["iCalleB"];
                        _Beneficiarios.cLetraB = (string)reader["cLetraB"];
                        _Beneficiarios.cNombreLocalidad = (string)reader["cNombreLocalidad"];
                        _Beneficiarios.iIdLocalidad = (int)reader["iIdLocalidad"];
                        _Beneficiarios.cAliasLocalidad = (string)reader["cAliasLocalidad"];
                        _Beneficiarios.iIdColonia = (int)reader["iIdColonia"];
                        _Beneficiarios.cNombreColonia = (string)reader["cNombreColonia"];
                        _Beneficiarios.cRFC = (string)reader["cRFC"];
                        _Beneficiarios.cCURP = (string)reader["cCURP"];
                        _Beneficiarios.dtFechaNacimiento = (DateTime)reader["dtFechaNacimiento"];
                        _Beneficiarios.iTelefono = (int)reader["iTelefono"];
                        _Beneficiarios.cEmail = (string)reader["cEmail"];
                        _Beneficiarios.ObjUsuarioGestion.iIdUsuario = (int)reader["iIdUsuarioGestion"];
                        _Beneficiarios.dtFechaRegistro = (DateTime)reader["dtFechaRegistro"];
                        _Beneficiarios.bActivo = Convert.ToBoolean(reader["bActivo"]); 

                        // Agregamos el objeto con los datos a la lista que se devolverá
                        list.Add(_Beneficiarios);
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
