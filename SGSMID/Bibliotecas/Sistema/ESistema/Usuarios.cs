using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema
{
    public class Usuarios
    {
        public int iIdUsuario { get; set; }
        public string cNombreUsuario { get; set; }
        public bool bActivo { get; set; }
        public string cPassword { get; set; }
        public bool bVisible { get; set; }
        public Perfiles objPerfil { get; set; }
        public String dtFechaAlta { get; set; }
        public int iIdUsuarioGestion { get; set; }
       
    }

    public class UsuariosDatos
    {
        
        public Usuarios objUsuario { get; set; }
        public int iIdUsuario { get { return objUsuario.iIdUsuario; } }
        public int iIdUsuarioDatos { get; set; }
        public int IdUserMostrar { get; set; }
        public int IdUserSesion { get; set; }
        public string cNombre { get; set; }
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }
       
        public CatPuestos objPuesto { get; set; }
    
        public string cNombreCompleto { get; set; }
        public string cNombreCentroCosto { get; set; }
        public int iNumeroEmpleado { get; set; }
        public int iIdCentroCosto { get; set; }

    }
}
