using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSistema;
using ESistema;

namespace NSistema.Catálogos
{
    public class CatPeriodosBL
    {
        public int insertarPeriodo(CatPeriodos _catperiodos)
        {
            try
            {
                CatPeriodosDAL _catperiodosDAL = new CatPeriodosDAL();
                return _catperiodosDAL.insertarPeriodo(_catperiodos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void modificarPeriodo(CatPeriodos _catperiodos)
        {
            try
            {
                CatPeriodosDAL _catperiodosDAL = new CatPeriodosDAL();
                _catperiodosDAL.modificarPeriodo(_catperiodos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatPeriodos> list()
        {
            try
            {
                CatPeriodosDAL _catPeriodosDAL = new CatPeriodosDAL();
                return _catPeriodosDAL.obtenerPeriodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
