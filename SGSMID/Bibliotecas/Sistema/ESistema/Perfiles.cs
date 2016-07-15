using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema
{
    public class Perfiles
    {
        public int iIdPerfil { get; set; }
        public string cNombre { get; set; }
        
        public string cDescripcion { get; set; }
        public int iIdCentroCosto { get; set; }
        public string cNombreDepartamento { get; set; } 
        public int iIdUsuarioGestion { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public bool bActivo { get; set; }
    }
}
