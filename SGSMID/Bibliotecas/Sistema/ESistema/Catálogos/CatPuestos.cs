using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema
{
    /// <summary>
    /// Clase de la Entidad Puestos
    /// </summary>
    public class CatPuestos
    {

        public int iIdPuesto { get; set; }
        public string cNombre { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public Boolean bActivo { get; set; }
        public int iIdUsuarioGestion { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public CatPuestos() { }
    }
}
