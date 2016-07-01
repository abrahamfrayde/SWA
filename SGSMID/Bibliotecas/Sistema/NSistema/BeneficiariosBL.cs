using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSistema;
using ESistema;

namespace NSistema
{
    public class BeneficiariosBL
    {

        // Método para insertar BeneficiariosBL
        public int InsertarBeneficiarios(Beneficiarios _Beneficiarios)
        {
            // Bloque para manejos de errores 
            try
            {
                // Definición y creación de la instancia DAL del tipo BeneficiariosDAL
                BeneficiariosDAL DAL = new BeneficiariosDAL();
                return DAL.InsertarBeneficiarios(_Beneficiarios);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para modificar BeneficiariosBL
        public int ModificarBeneficiarios(Beneficiarios _Beneficiarios)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo BeneficiariosDAL
                BeneficiariosDAL DAL = new BeneficiariosDAL();
                return DAL.ModificarBeneficiarios(_Beneficiarios);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para eliminar BenefciariosBL
        public int EliminarBeneficiarios(Beneficiarios _Beneficiarios)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo BeneficiariosDAL
                BeneficiariosDAL DAL = new BeneficiariosDAL();
                return DAL.EliminarBeneficiarios(_Beneficiarios);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para obtener BeneficiariosBL
        public List<Beneficiarios> ObtenerBeneficiarios(int _id = 0, string _filtro = null)
        {
            // Bloque para manejos de errores
            try
            {
                // Definición y creación de la instancia DAL del tipo CatRamasDAL
                BeneficiariosDAL DAL = new BeneficiariosDAL();
                return DAL.ObtenerBeneficiarios(_id, _filtro);
            }
            // Manejo de las excepciones de bloque try
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
