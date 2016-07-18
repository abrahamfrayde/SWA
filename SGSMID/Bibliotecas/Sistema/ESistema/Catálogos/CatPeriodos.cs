using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema
{
    public class CatPeriodos
    {
        public int iIdPeriodo { get; set; }
        public string cNombre { get; set; }
        public DateTime dtFechaInicial { get; set; }
        public DateTime dtFechaFinal { get; set; }
        public string cPresidenteMunicipal { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public bool bActivo { get; set; }
        public int iIdUsuario { get; set; }


        public CatPeriodos() { }
    }
}
