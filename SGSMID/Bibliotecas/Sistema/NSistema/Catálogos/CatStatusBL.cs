using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DSistema;
using ESistema;

namespace NSistema
{
    public class CatStatusBL
    {
        // Método para insertar Status BL
        public int InsertarStatus(CatStatus _CatStatus)
        {
            // Bloque para manejos de errores 
            try
            {
                // Definición y creación de la instancia DAL del tipo CatStatusDAL
                CatStatusDAL DAL = new CatStatusDAL();
                return DAL.InsertarStatus(_CatStatus);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para modificar Status BL
        public int ModificarStatus(CatStatus _CatStatus)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatStatusDAL
                CatStatusDAL DAL = new CatStatusDAL();
                return DAL.ModificarStatus(_CatStatus);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para eliminar Status BL
        public int EliminarStatus(CatStatus _CatStatus)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatStatusDAL
                CatStatusDAL DAL = new CatStatusDAL();
                return DAL.EliminarStatus(_CatStatus);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para obtener Status BL
        public List<CatStatus> ObtenerStatus(int _id = 0, string _filtro = null)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatStatusDAL
                CatStatusDAL DAL = new CatStatusDAL();
                return DAL.ObtenerStatus(_id, _filtro);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
