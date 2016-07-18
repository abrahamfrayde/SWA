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
    public class CatStatusOrdenBL
    {
        // Método para insertar Status BL
        public int InsertarStatus(CatStatusOrden _CatStatusOrden)
        {
            // Bloque para manejos de errores 
            try
            {
                // Definición y creación de la instancia DAL del tipo CatStatusDAL
                CatStatusOrdenDAL DAL = new CatStatusOrdenDAL();
                return DAL.InsertarStatus(_CatStatusOrden);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para modificar Status BL
        public int ModificarStatus(CatStatusOrden _CatStatusOrden)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatStatusDAL
                CatStatusOrdenDAL DAL = new CatStatusOrdenDAL();
                return DAL.ModificarStatus(_CatStatusOrden);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para eliminar Status BL
        public int EliminarStatus(CatStatusOrden _CatStatusOrden)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatStatusDAL
                CatStatusOrdenDAL DAL = new CatStatusOrdenDAL();
                return DAL.EliminarStatus(_CatStatusOrden);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para obtener Status BL
        public List<CatStatusOrden> ObtenerStatusOrden(int _id = 0, string _filtro = null)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatStatusDAL
                CatStatusOrdenDAL DAL = new CatStatusOrdenDAL();
                return DAL.ObtenerStatusOrden(_id, _filtro);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
