using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema.Catalogos
{
    public class CatStatusOrden
    {
        public int iIdStatusOrden { get; set; }
        public CatProcesos objProcesos { get; set; }
        public CatStatus objStatus { get; set; }
        public CatStatus objStatusDestino { get; set; }
        public Usuarios ObjUsuarioGestion { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public Boolean bActivo { get; set; }

        //Constructor por default
        public CatStatusOrden() { }
    }
}
