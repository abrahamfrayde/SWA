using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema
{
    /// <summary>
    /// Clase Beneficiarios que hace referencia a la tabla tbl_beneficiarios de la base de datos BD_SGS
    /// </summary>
    public class Beneficiarios
    {
        // Propiedades de la clase Beneficiarios
        public int iIdBeneficiario { get; set; }
        public string cNombre { get; set; }
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }
        public string cNombreCompleto { get; set; }
        public int iNumeroInterior { get; set; }
        public string cLetraInterior { get; set; }
        public int iNumeroExterior { get; set; }
        public string cLetraExterior { get; set; }
        public int iCallePrincipal { get; set; }
        public string cLetraPrincipal { get; set; }
        public int iCalleA { get; set; }
        public string cLetraA { get; set; }
        public int iCalleB { get; set; }
        public string cLetraB { get; set; }
        public string cNombreLocalidad { get; set; }
        public int iIdLocalidad { get; set; }
        public string cAliasLocalidad { get; set; }
        public int iIdColonia { get; set; }
        public string cNombreColonia { get; set; }
        public string cRFC { get; set; }
        public string cCURP { get; set; }
        public DateTime dtFechaNacimiento { get; set; }
        public int iTelefono { get; set; }
        public string cEmail { get; set; }
        public Usuarios ObjUsuarioGestion { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public Boolean bActivo { get; set; }

        // Constructor de la clase Beneficiarios
        public Beneficiarios() { }
    }
}
