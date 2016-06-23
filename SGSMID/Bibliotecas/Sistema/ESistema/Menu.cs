using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema
{
    public class Menu
    {
        public int iIdMenu { get; set; }
        public string cNombreMenu { get; set; }
        public string cURLMenu { get; set; }
        public int iOrden { get; set; }
        public int iIdPadre { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public Boolean bActivo { get; set; }
        public string cIcono { get; set; }
        public Menu() { }
    }
}
