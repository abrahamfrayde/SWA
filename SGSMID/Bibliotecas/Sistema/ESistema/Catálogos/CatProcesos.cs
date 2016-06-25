using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema.Catalogos
{
    public class CatProcesos
    {
        //Propiedades publicas de la clase CatProcesos
        public int iIdProceso { get; set; }
        public string cNombre { get; set; }
        public CatPeriodos objPeriodos {get; set;}
        public CatRamas objRamas { get; set; }
        public Usuarios ObjUsuarioGestion { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public Boolean bActivo { get; set; }
        
        //Constructor Default de la clase CatProcesos
        public CatProcesos (){}        
    }
}
