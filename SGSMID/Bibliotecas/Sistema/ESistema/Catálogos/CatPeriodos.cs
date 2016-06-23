using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema
{
    public class CatPeriodos
    {
        public int iIdPeriodo_p { get; set; }
        public string cNombre_p { get; set; }
        public DateTime dtFechaInicial_p { get; set; }
        public DateTime dtFechaFinal_p { get; set; }
        public string cPresidenteMuninicipal_p { get; set; }
        public DateTime dtFechaRegistro_p { get; set; }
        public bool bActivo_p { get; set; }
        public int iIdUsuario_p { get; set; }


        public CatPeriodos() { }
    }
}

