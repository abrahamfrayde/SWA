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
    // Método para insertar tipos de solicitudes BL
    public class CatTiposSolicitudBL
    {

        public int InsertarTiposSolicitud(CatTiposSolicitud _CatTiposSolicitud)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatTiposSolicitud
                CatTiposSolicitudDAL DAL = new CatTiposSolicitudDAL();
                return DAL.InsertarTiposSolicitud(_CatTiposSolicitud);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para modificar tipos de solicitudes BL
        public int ModificarTiposSolicitud(CatTiposSolicitud _CatTiposSolicitud)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatTiposSolicitud
                CatTiposSolicitudDAL DAL = new CatTiposSolicitudDAL();
                return DAL.ModificarTiposSolicitud(_CatTiposSolicitud);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para eliminar tipos de solicitudes BL
        public int EliminarTiposSolicitud(CatTiposSolicitud _CatTiposSolicitud)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatTiposSolicitud
                CatTiposSolicitudDAL DAL = new CatTiposSolicitudDAL();
                return DAL.EliminarTiposSolicitud(_CatTiposSolicitud);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para obtener tipos de solicitudes BL
        public List<CatTiposSolicitud> ObtenerTiposSolicitud(int _id = 0, string _filtro = null)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatTiposSolicitud
                CatTiposSolicitudDAL DAL = new CatTiposSolicitudDAL();
                return DAL.ObtenerTiposSolicitud(_id, _filtro);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
