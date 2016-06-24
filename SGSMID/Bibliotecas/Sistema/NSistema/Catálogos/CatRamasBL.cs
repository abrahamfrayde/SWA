using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DSistema;
using ESistema;
using ESistema.Catalogos;

namespace NSistema.Catálogos
{
    public class CatRamasBL
    {

        // Método para insertar ramas BL
        public int InsertarRamas(CatRamas _CatRamas)
        {
            // Bloque para manejos de errores 
            try
            {
                // Definición y creación de la instancia DAL del tipo CatRamasDAL
                CatRamasDAL DAL = new CatRamasDAL();
                return DAL.InsertarRamas(_CatRamas);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para modificar ramas BL
        public int ModificarRamas(CatRamas _CatRamas)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatRamasDAL
                CatRamasDAL DAL = new CatRamasDAL();
                return DAL.ModificarRamas(_CatRamas);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para eliminar ramas BL
        public int EliminarRamas(CatRamas _CatRamas)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatRamasDAL
                CatRamasDAL DAL = new CatRamasDAL();
                return DAL.EliminarRamas(_CatRamas);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para obtener ramas BL
        public List<CatRamas> ObtenerRamas(int _id = 0, string _filtro = null)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatRamasDAL
                CatRamasDAL DAL = new CatRamasDAL();
                return DAL.ObtenerRamas(_id, _filtro);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
