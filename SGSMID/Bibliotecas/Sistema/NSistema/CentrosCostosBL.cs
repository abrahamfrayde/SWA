using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSistema;
using ESistema;

namespace NSistema
{
    public class CentrosCostosBL
    {
        public List<CentrosCostos> list(int id = 0, int idparent = 0, int nivel = 0, string filtro = null)
        {
            try
            {
                CentrosCostosDAL _catcentroscostosdal = new CentrosCostosDAL();
                return _catcentroscostosdal.obtenerCentrosCostos(id, idparent, nivel,filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
