using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema
{
    /// <summary>
    /// Clase CatRamas que hace referencia a la tabla tbl_cat_ramas de la base de datos BD_SGS
    /// </summary>
    public class CatRamas
    {
        // Propiedades de la clase CatRamas
        public int iIdRama { get; set; }
        public string cNombre { get; set; }
        public CentrosCostos ObjCentrosCostos { get; set; }
        public Usuarios ObjUsuarioGestion { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public Boolean bActivo { get; set; }

        // Constructor de la clase CatRamas
        public CatRamas() { }
    }
}
