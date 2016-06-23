using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema
{
    public class CentrosCostos
    {
        public int iIdCentroCosto { get; set; }
        public int iIdParent { get; set; }
        public int iNivel { get; set; }
        public int iPeriodo { get; set; }
        public string cNombre { get; set; }
        public int iIdUsuarioResponsable { get; set; }
        public string cCorreosElectronicos { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public Boolean bActivo { get; set; }
    }
}
