using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSistema;
using ESistema;


namespace NSistema
{
    public class CatProcesosBL
    {
        // Método para insertar Procesos BL
        public int InsertarProcesos(CatProcesos _CatProcesos)
        {
            // Bloque para manejos de errores 
            try
            {
                // Definición y creación de la instancia DAL del tipo CatProcesosDAL
                CatProcesosDAL DAL = new CatProcesosDAL();
                return DAL.InsertarProceso(_CatProcesos);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para modificar Procesos BL
        public void ModificarProcesos(CatProcesos _CatProcesos)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatProcesosDAL
                CatProcesosDAL DAL = new CatProcesosDAL();
                DAL.ModificarProceso(_CatProcesos);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para eliminar Procesos BL
        public int EliminarProcesos(CatProcesos _CatProcesos)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatProcesosDAL
                CatProcesosDAL DAL = new CatProcesosDAL();
                return DAL.EliminarProceso(_CatProcesos);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para obtener Procesos BL
        public List<CatProcesos> ObtenerProcesos(int id = 0, string filtro = null)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatProcesosDAL
                CatProcesosDAL DAL = new CatProcesosDAL();
                return DAL.ObtenerProceso(id, filtro);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
