using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema.Catalogos
{
    /// <summary>
    /// Clase CatTiposSolicitud que hace referencia a la tabla tbl_cat_tipossolicitud de la base de datos BD_SGS
    /// </summary>
    public class CatTiposSolicitud
    {
        // Propiedades de la clase CatTiposSolicitud
        public int iIdTipoSolicitud { get; set; }
        public string cNombre { get; set; }
        public CatRamas ObjRamas { get; set; }
        public CatProcesos ObjProcesos { get; set; }
        public Usuarios ObjUsuarioGestion { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public Boolean bActivo { get; set; }

        // Constructor de la clase CatTiposSolicitud
        public CatTiposSolicitud() { }
    }
}
