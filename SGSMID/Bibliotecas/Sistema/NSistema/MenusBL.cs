using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSistema;
using ESistema;

namespace NSistema
{
    public class MenusBL
    {
        private MenuDAL dal;

        public MenusBL()
        {
            dal = new MenuDAL();
        }

        public List<Menu> GetMenus(int idperfil)
        {
            try
            {
                return dal.GetMenus(idperfil);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
