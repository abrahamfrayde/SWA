using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESistema;
using NSistema;

public partial class Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");
        MenusBL bl = new MenusBL();
        UsuariosBL userbl = new UsuariosBL();
        if (!IsPostBack)
        {

            List<UsuariosDatos> _lstusuariodatos = new List<UsuariosDatos>();
            _lstusuariodatos = userbl.list(0, 0, (int)Session["IdUser"]);
            if (_lstusuariodatos.Count == 0)
            {
                nombrecompleto.Text = "Soporte";
               
            }
            else
            {
                nombrecompleto.Text = _lstusuariodatos[0].cNombreCompleto;
            
            }


        }

    }
}