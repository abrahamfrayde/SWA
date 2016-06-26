using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema.Catalogos
{
    public class CatStatus
    {
        public int iIdStatus { get; set; }
        public string cNombre { get; set; }
        public int iOrden { get; set; }
        public CatProcesos objProcesos { get; set; }
        public Usuarios ObjUsuarioGestion { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public Boolean bActivo { get; set; }

    }
}
