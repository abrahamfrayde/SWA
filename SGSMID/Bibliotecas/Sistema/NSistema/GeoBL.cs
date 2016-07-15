using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESistema.Geo;
using DSistema;

namespace NSistema
{
    public class GeoBL
    {
        GeoDAL _geodal = new GeoDAL();
        public Task<string> InicioSesion(string usuario, string clave, string aplicacion)
        {
            try
            {
                return _geodal.InicioSesion(usuario, clave, aplicacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CierreSesion(string Authorization)
        {
            try
            {
                _geodal.CierreSesion(Authorization);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<ResponseJsonGeo> BusquedaInteraccion(string criterio, string Authorization)
        {
            try
            {
                return _geodal.BusquedaInteraccion(criterio, Authorization);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Task<ResponseJsonGeo> Busqueda(string criterio, string Authorization)
        {
            try
            {
                return _geodal.Busqueda(criterio, Authorization);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InteraccionesMapa(string accion, string argumento, string Authorization)
        {
            try
            {
                _geodal.InteraccionesMapa(accion, argumento, Authorization);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LimpiarUbicacion(string Authorization)
        {
            try
            {
                _geodal.LimpiarUbicacion(Authorization);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultaUbicacion(string clave, string folio, string Authorization)
        {
            try
            {
                _geodal.ConsultaUbicacion(clave, folio, Authorization);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GuardarActualizarUbicacion(string clave, string folio, string Authorization, dynamic dynamicJson)
        {
            try
            {
                _geodal.GuardarActualizarUbicacion(clave, folio, Authorization, dynamicJson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
