using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema
{
    public class MenuPerfil
    {
        public int iIdMenuPerfil { get; set; }
        public Menu objMenu { get; set; }
        public Perfiles objPerfil { get; set; }
        public int iIdUsuarioGestion { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public MenuPerfil() { }
    }
}
