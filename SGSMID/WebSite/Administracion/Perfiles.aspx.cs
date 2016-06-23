using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSistema;
using ESistema;

public partial class Administracion_Perfiles : System.Web.UI.Page
{
    PerfilesBL _catperfilneg = new PerfilesBL();
    MenuPerfilBL _catmenuperfilneg = new MenuPerfilBL();
    ESistema.Perfiles _objperfil;
    CentrosCostosBL _catcentroscostosneg = new CentrosCostosBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");

        if (!Page.IsPostBack)
        {
            GridViewPerfiles.DataSource = _catperfilneg.list();
            GridViewPerfiles.DataBind();
            txtCambiarNombrePerfil.Attributes.Add("placeholder", "Nombre");
            txtBusquedaNombrePerfil.Attributes.Add("placeholder", "Perfil");
            txtNombrePerfil.Attributes.Add("placeholder", "Nombre");
            txtDescripcionPerfil.Attributes.Add("placeholder", "Descripción");
            txtCambiarDescripcionPerfil.Attributes.Add("placeholder", "Descripción");
        }
    }

    public void LoadComboCambiarCentrosCostos(string oper = null, int ID = 0)
    {
        if (oper == null)
        {
            dropCambiarDireccion.DataSource = _catcentroscostosneg.list(0, 0, 1);
            dropCambiarDireccion.DataValueField = "iIdCentroCosto";
            dropCambiarDireccion.DataTextField = "cNombre";
            dropCambiarDireccion.DataBind();
            dropCambiarSubdireccion.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropCambiarDireccion.SelectedValue.ToString()), 2);
            dropCambiarSubdireccion.DataValueField = "iIdCentroCosto";
            dropCambiarSubdireccion.DataTextField = "cNombre";
            dropCambiarSubdireccion.DataBind();
            dropCambiarDepartamento.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropCambiarSubdireccion.SelectedValue.ToString()), 3);
            dropCambiarDepartamento.DataValueField = "iIdCentroCosto";
            dropCambiarDepartamento.DataTextField = "cNombre";
            dropCambiarDepartamento.DataBind();
        }
        if (oper == "Seleccion")
        {
            dropCambiarDepartamento.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropCambiarSubdireccion.SelectedValue.ToString()), 3);
            dropCambiarDepartamento.DataValueField = "iIdCentroCosto";
            dropCambiarDepartamento.DataTextField = "cNombre";
            dropCambiarDepartamento.DataBind();
        }
        if (oper == "Direccion")
        {
            dropCambiarSubdireccion.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropCambiarDireccion.SelectedValue.ToString()), 2);
            dropCambiarSubdireccion.DataValueField = "iIdCentroCosto";
            dropCambiarSubdireccion.DataTextField = "cNombre";
            dropCambiarSubdireccion.DataBind();
            dropCambiarDepartamento.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropCambiarSubdireccion.SelectedValue.ToString()), 3);
            dropCambiarDepartamento.DataValueField = "iIdCentroCosto";
            dropCambiarDepartamento.DataTextField = "cNombre";
            dropCambiarDepartamento.DataBind();
        }
        if (oper == "Cargar Guardado")
        {
            List<CentrosCostos> _lstdepartamento = new List<CentrosCostos>();
            _lstdepartamento = _catcentroscostosneg.list(ID, 0, 3);
            List<CentrosCostos> _lstsubdireccion = new List<CentrosCostos>();
            _lstsubdireccion = _catcentroscostosneg.list(_lstdepartamento[0].iIdParent, 0, 2);
            List<CentrosCostos> _lstdireccion = new List<CentrosCostos>();
            _lstdireccion = _catcentroscostosneg.list(_lstsubdireccion[0].iIdParent, 0, 1);

            dropCambiarDireccion.DataSource = _catcentroscostosneg.list(0, 0, 1);
            dropCambiarDireccion.DataValueField = "iIdCentroCosto";
            dropCambiarDireccion.DataTextField = "cNombre";
            dropCambiarDireccion.DataBind();
            dropCambiarDireccion.Items.FindByValue(_lstdireccion[0].iIdCentroCosto.ToString()).Selected = true;
            dropCambiarSubdireccion.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropCambiarDireccion.SelectedValue.ToString()), 2);
            dropCambiarSubdireccion.DataValueField = "iIdCentroCosto";
            dropCambiarSubdireccion.DataTextField = "cNombre";
            dropCambiarSubdireccion.DataBind();
            dropCambiarSubdireccion.Items.FindByValue(_lstsubdireccion[0].iIdCentroCosto.ToString()).Selected = true;
            dropCambiarDepartamento.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropCambiarSubdireccion.SelectedValue.ToString()), 3);
            dropCambiarDepartamento.DataValueField = "iIdCentroCosto";
            dropCambiarDepartamento.DataTextField = "cNombre";
            dropCambiarDepartamento.DataBind();
            dropCambiarDepartamento.Items.FindByValue(ID.ToString()).Selected = true;
        }
    }
    public void LoadComboCentrosCostos(string oper = null, int ID = 0)
    {
        if (oper == null)
        {
            dropUserDireccion.DataSource = _catcentroscostosneg.list(0, 0, 1);
            dropUserDireccion.DataValueField = "iIdCentroCosto";
            dropUserDireccion.DataTextField = "cNombre";
            dropUserDireccion.DataBind();
            dropUserSubdireccion.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropUserDireccion.SelectedValue.ToString()), 2);
            dropUserSubdireccion.DataValueField = "iIdCentroCosto";
            dropUserSubdireccion.DataTextField = "cNombre";
            dropUserSubdireccion.DataBind();
            dropUserDepartamento.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropUserSubdireccion.SelectedValue.ToString()), 3);
            dropUserDepartamento.DataValueField = "iIdCentroCosto";
            dropUserDepartamento.DataTextField = "cNombre";
            dropUserDepartamento.DataBind();
        }
        if (oper == "Seleccion")
        {
            dropUserDepartamento.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropUserSubdireccion.SelectedValue.ToString()), 3);
            dropUserDepartamento.DataValueField = "iIdCentroCosto";
            dropUserDepartamento.DataTextField = "cNombre";
            dropUserDepartamento.DataBind();
        }
        if (oper == "Direccion")
        {
            dropUserSubdireccion.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropUserDireccion.SelectedValue.ToString()), 2);
            dropUserSubdireccion.DataValueField = "iIdCentroCosto";
            dropUserSubdireccion.DataTextField = "cNombre";
            dropUserSubdireccion.DataBind();
            dropUserDepartamento.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropUserSubdireccion.SelectedValue.ToString()), 3);
            dropUserDepartamento.DataValueField = "iIdCentroCosto";
            dropUserDepartamento.DataTextField = "cNombre";
            dropUserDepartamento.DataBind();
        }
        if (oper == "Cargar Guardado")
        {
            List<CentrosCostos> _lstdepartamento = new List<CentrosCostos>();
            _lstdepartamento = _catcentroscostosneg.list(ID, 0, 3);
            List<CentrosCostos> _lstsubdireccion = new List<CentrosCostos>();
            _lstsubdireccion = _catcentroscostosneg.list(_lstdepartamento[0].iIdParent, 0, 2);
            List<CentrosCostos> _lstdireccion = new List<CentrosCostos>();
            _lstdireccion = _catcentroscostosneg.list(_lstsubdireccion[0].iIdParent, 0, 1);

            dropUserDireccion.DataSource = _catcentroscostosneg.list(0, 0, 1);
            dropUserDireccion.DataValueField = "iIdCentroCosto";
            dropUserDireccion.DataTextField = "cNombre";
            dropUserDireccion.DataBind();
            dropUserDireccion.Items.FindByValue(_lstdireccion[0].iIdCentroCosto.ToString()).Selected = true;
            dropUserSubdireccion.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropUserDireccion.SelectedValue.ToString()), 2);
            dropUserSubdireccion.DataValueField = "iIdCentroCosto";
            dropUserSubdireccion.DataTextField = "cNombre";
            dropUserSubdireccion.DataBind();
            dropUserSubdireccion.Items.FindByValue(_lstsubdireccion[0].iIdCentroCosto.ToString()).Selected = true;
            dropUserDepartamento.DataSource = _catcentroscostosneg.list(0, Convert.ToInt32(dropUserSubdireccion.SelectedValue.ToString()), 3);
            dropUserDepartamento.DataValueField = "iIdCentroCosto";
            dropUserDepartamento.DataTextField = "cNombre";
            dropUserDepartamento.DataBind();
            dropUserDepartamento.Items.FindByValue(ID.ToString()).Selected = true;
        }
    }
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EliminarPerfil")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewPerfiles.DataKeys[fila].Value.ToString();
            lblModalTitleEliminar.Text = "Eliminar";
            Label labeltemp = GridViewPerfiles.Rows[fila].FindControl("NomPerfil") as Label;
            string valor = labeltemp.Text;
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Perfil : " + valor + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }

        if (e.CommandName == "CambiarNombrePerfil")
        {
            lblMensajeNombrePerfil.Visible = false;
            lblMensajeDescripcionPerfil.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleEditar.Text = "Editar Perfil";
            txtCambiarDescripcionPerfil.Text = (GridViewPerfiles.Rows[fila].FindControl("cDescripcion") as HiddenField).Value.ToString();
            txtCambiarNombrePerfil.Text =((Label)this.GridViewPerfiles.Rows[fila].FindControl("NomPerfil")).Text;
            HiddenField tempcentrocosto = GridViewPerfiles.Rows[fila].FindControl("iIdCentroCosto") as HiddenField;
            string valorcentrocosto = tempcentrocosto.Value;
            LoadComboCambiarCentrosCostos("Cargar Guardado", Convert.ToInt32(valorcentrocosto));
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalCambiarNombrePerfil", "$('#ModalCambiarNombrePerfil').modal();", true);
            upModalCambiarNombrePerfil.Update();
            ID.Value = this.GridViewPerfiles.DataKeys[fila].Value.ToString();
        }

        if (e.CommandName == "EditarPermisos")
        {

            
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewPerfiles.DataKeys[fila].Value.ToString();
            Label labeltemp = GridViewPerfiles.Rows[fila].FindControl("NomPerfil") as Label;
            string valor = labeltemp.Text;
            
            camponombre.Style.Add("display", "none");
            campodescripcion.Style.Add("display", "none");
            campodireccion.Style.Add("display", "none");
            camposubdireccion.Style.Add("display", "none");
            campodepartamento.Style.Add("display", "none");

            lblDepartamento.Visible = false;
            lblDireccion.Visible = false;
            lblSubdireccion.Visible = false;
            lblNombrePerfil.Visible = false;
            lblDescripcion.Visible = false;
            txtNombrePerfil.Visible = false;
            txtDescripcionPerfil.Visible = false;
            dropUserDepartamento.Visible = false;
            dropUserDireccion.Visible = false;
            dropUserSubdireccion.Visible = false;
            EtiquetaNombrePerfil.Visible = false;
            lblMensajeDescripcionNuevoPerfil.Visible = false;
            lblModalTitleNuevo.Text = "Editar Permisos de " + valor ;
            Operacion.Value = "Editar";
            chckboxlist.DataSource = _catperfilneg.listmenus();
            chckboxlist.DataValueField = "iIdMenu";
            chckboxlist.DataTextField = "cNombreMenu";
            chckboxlist.DataBind();
            MenusBL _menuneg = new MenusBL();
           
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperPerfil", "$('#ModalOperPerfil').modal();", true);
            
            upModalOperPerfil.Update();
            foreach (ESistema.Menu obj in _menuneg.GetMenus(Convert.ToInt32(ID.Value)))
            {
                foreach (ListItem itemActual in chckboxlist.Items)
                {
                    if (itemActual.Value == obj.iIdMenu.ToString())
                    {
                        itemActual.Selected = true;

                    }
                }
             
            }
        }



    }
    protected void BuscarPefil_Click(object sender, EventArgs e)
    {
        GridViewPerfiles.DataSource = _catperfilneg.list(0,txtBusquedaNombrePerfil.Text);
        GridViewPerfiles.DataBind();
    }
    protected void Guardar_Click(object sender, EventArgs e)
    {
        if (Operacion.Value == "Nuevo")
        {
            if(txtNombrePerfil.Text == string.Empty)
            {
                lblNombrePerfil.Visible = true;
                upModalOperPerfil.Update();
              
            }
            else
            {
                _objperfil = new ESistema.Perfiles();
                _objperfil.cNombre = txtNombrePerfil.Text;
                _objperfil.iIdUsuarioGestion = Convert.ToInt32(Session["IdUser"]);
                _objperfil.cDescripcion = txtDescripcionPerfil.Text;
                _objperfil.iIdCentroCosto = Convert.ToInt32(dropUserDepartamento.SelectedValue.ToString());
                List<ESistema.Menu> lstmenus = new List<ESistema.Menu>();
                ESistema.Menu _objmenu;
                foreach (ListItem itemActual in chckboxlist.Items)
                {
                    if (itemActual.Selected == true)
                    {
                        _objmenu = new ESistema.Menu();
                        _objmenu.iIdMenu = Convert.ToInt32(itemActual.Value);
                        lstmenus.Add(_objmenu);
                        _objmenu = new ESistema.Menu();
                        _objmenu.iIdMenu = _catperfilneg.listmenus(Convert.ToInt32(itemActual.Value))[0].iIdPadre;
                        lstmenus.Add(_objmenu);
                    }

                }
                _catperfilneg.insertarPerfil(_objperfil, lstmenus);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperPerfil", "$('#ModalOperPerfil').modal('hide');", true);
                upModalOperPerfil.Update();
                GridViewPerfiles.DataSource = _catperfilneg.list();
                GridViewPerfiles.DataBind();

            }
           
        }
        if (Operacion.Value == "Editar")
        {
           
                _objperfil = new ESistema.Perfiles();
                _objperfil.iIdPerfil = Convert.ToInt32(ID.Value);
                _objperfil.iIdUsuarioGestion = Convert.ToInt32(Session["IdUser"]);
             
                List<ESistema.Menu> lstmenus = new List<ESistema.Menu>();
                ESistema.Menu _objmenu;
                foreach (ListItem itemActual in chckboxlist.Items)
                {
                    if (itemActual.Selected == true)
                    {
                        _objmenu = new ESistema.Menu();
                        _objmenu.iIdMenu = Convert.ToInt32(itemActual.Value);
                        lstmenus.Add(_objmenu);
                        _objmenu = new ESistema.Menu();
                        _objmenu.iIdMenu = _catperfilneg.listmenus(Convert.ToInt32(itemActual.Value))[0].iIdPadre;
                        lstmenus.Add(_objmenu);
                    }

                }
                _catmenuperfilneg.actualizarMenuPerfiles(_objperfil, lstmenus);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperPerfil", "$('#ModalOperPerfil').modal('hide');", true);
                upModalOperPerfil.Update();
                GridViewPerfiles.DataSource = _catperfilneg.list();
                GridViewPerfiles.DataBind();
            
        }
           


    }
    protected void NuevoPerfil_Click(object sender, EventArgs e)
    {
        txtNombrePerfil.Text = string.Empty;
        txtNombrePerfil.Visible = true;
        EtiquetaNombrePerfil.Visible = true;
        lblNombrePerfil.Visible = false;
        txtDescripcionPerfil.Visible = true;
        dropUserDepartamento.Visible = true;
        dropUserDireccion.Visible = true;
        dropUserSubdireccion.Visible = true;
        lblDepartamento.Visible = true;
        lblDireccion.Visible = true;
        lblSubdireccion.Visible = true;
        lblDescripcion.Visible = true;
        camponombre.Style.Add("display", "block");
        campodescripcion.Style.Add("display", "block");
        campodireccion.Style.Add("display", "block");
        camposubdireccion.Style.Add("display", "block");
        campodepartamento.Style.Add("display", "block");
        lblModalTitleNuevo.Text = "Nuevo Perfil";
        Operacion.Value = "Nuevo";
        LoadComboCentrosCostos();
        chckboxlist.DataSource = _catperfilneg.listmenus();
        chckboxlist.DataValueField = "iIdMenu";
        chckboxlist.DataTextField = "cNombreMenu";
        chckboxlist.DataBind();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperPerfil", "$('#ModalOperPerfil').modal();", true);
        upModalOperPerfil.Update();
    }



    protected void Eliminar_Click(object sender, EventArgs e)
    {

        _objperfil = new Perfiles();
        _objperfil.iIdPerfil = Convert.ToInt32(ID.Value.ToString());
        _objperfil.cNombre = txtCambiarNombrePerfil.Text;
        _catperfilneg.eliminarPerfil(_objperfil);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
        upModalEliminar.Update();
        GridViewPerfiles.DataSource = _catperfilneg.list();
        GridViewPerfiles.DataBind();

    }
    protected void NombrePerfil_Click(object sender,EventArgs e)
    {
        if (txtCambiarNombrePerfil.Text == string.Empty)
        {
           lblMensajeNombrePerfil.Visible = true;
            upModalCambiarNombrePerfil.Update();

        }else
        {
            _objperfil = new Perfiles();
            _objperfil.iIdPerfil = Convert.ToInt32(ID.Value.ToString());
            _objperfil.cNombre = txtCambiarNombrePerfil.Text;
            _objperfil.cDescripcion = txtCambiarDescripcionPerfil.Text;
            _objperfil.iIdCentroCosto = Convert.ToInt32(dropCambiarDepartamento.SelectedValue.ToString());
            _catperfilneg.modificarPerfil(_objperfil);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalCambiarNombrePerfil", "$('#ModalCambiarNombrePerfil').modal('hide');", true);
            upModalCambiarNombrePerfil.Update();
            GridViewPerfiles.DataSource = _catperfilneg.list();
            GridViewPerfiles.DataBind();
        }
       
    }
    protected void Edicion_Click(object sender, EventArgs e)
    {

    }
    protected void dropCambiarDireccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadComboCambiarCentrosCostos("Direccion");
        upModalCambiarNombrePerfil.Update();
    }
    protected void dropCambiarSubdireccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadComboCambiarCentrosCostos("Seleccion");
        upModalCambiarNombrePerfil.Update();
    }
    protected void dropUserDireccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadComboCentrosCostos("Direccion");
        upModalOperPerfil.Update();
    }
    protected void dropUserSubdireccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadComboCentrosCostos("Seleccion");
        upModalOperPerfil.Update();
    }

}