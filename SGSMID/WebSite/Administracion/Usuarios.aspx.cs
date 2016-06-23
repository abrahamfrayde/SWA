using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSistema;
using ESistema;

public partial class Administracion_Usuarios : System.Web.UI.Page
{
    CatPuestosBL _catpuestosneg = new CatPuestosBL();
    UsuariosBL _catusuariosneg = new UsuariosBL();
    PerfilesBL _catperfilneg = new PerfilesBL();
    CentrosCostosBL _catcentroscostosneg = new CentrosCostosBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");
        if (!Page.IsPostBack)
        {
            txtUserName.Attributes.Add("placeholder", "Correo Electronico");
            txtUserPassword.Attributes.Add("placeholder", "Contraseña");
            txtUserPasswordConfirma.Attributes.Add("placeholder", "Confirmar Contraseña");
            txtUserNombre.Attributes.Add("placeholder", "Nombre");
            txtNroEmpleado.Attributes.Add("placeholder", "Nro.");
            txtUserApellidoPaterno.Attributes.Add("placeholder", "Apellido Paterno");
            txtUserApellidoMaterno.Attributes.Add("placeholder", "Apellido Materno");
            txtUserPasswordCambio.Attributes.Add("placeholder", "Contraseña Nueva");
            txtUserPasswordCambioConfirma.Attributes.Add("placeholder", "Confirmar Contraseña");
            LoadComboPuesto("filtro");
            LoadComboPerfil("filtro");
            txtNombreCompletoEmail.Attributes.Add("placeholder", "Nombre o Correo Electronico");
            GridViewUsuarios.DataSource = _catusuariosneg.list();
            GridViewUsuarios.DataBind();
        }
    }
    public void LoadComboPuesto(string oper = null, int ID = 0)
    {
        if (oper == "filtro")
        {
            dropFiltroPuesto.DataSource = _catpuestosneg.list();
            dropFiltroPuesto.DataValueField = "iIdPuesto";
            dropFiltroPuesto.DataTextField = "cNombre";
            dropFiltroPuesto.DataBind();
            dropFiltroPuesto.Items.Insert(0, new ListItem("Todos los Puestos", "0"));
            dropFiltroPuesto.Items.FindByValue(ID.ToString()).Selected = true;
        }
        else
        {
            dropUserPuesto.DataSource = _catpuestosneg.list();
            dropUserPuesto.DataValueField = "iIdPuesto";
            dropUserPuesto.DataTextField = "cNombre";
            dropUserPuesto.DataBind();
        }
    }
    public void LoadComboPerfil(string oper = null, int ID = 0)
    {
        if (oper == "filtro")
        {
            dropFiltroPerfil.DataSource = _catperfilneg.list();
            dropFiltroPerfil.DataValueField = "iIdPerfil";
            dropFiltroPerfil.DataTextField = "cNombre";
            dropFiltroPerfil.DataBind();
            dropFiltroPerfil.Items.Insert(0, new ListItem("Todos los Perfiles", "0"));
            dropFiltroPerfil.Items.FindByValue(ID.ToString()).Selected = true;
        }
        else
        {
            dropUserPerfil.DataSource = _catperfilneg.list();
            dropUserPerfil.DataValueField = "iIdPerfil";
            dropUserPerfil.DataTextField = "cNombre";    
            dropUserPerfil.DataBind();
        }
    }
    public void LoadComboCentrosCostos(string oper = null, int ID = 0)
    {
        if(oper == null)
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
        if(oper == "Seleccion")
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
        if (e.CommandName == "EliminarUsuario")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewUsuarios.DataKeys[fila].Value.ToString();
            lblModalTitleEliminar.Text = "Eliminar";
            Label labeltemp = GridViewUsuarios.Rows[fila].FindControl("cNombreUsuario") as Label;
            string valor = labeltemp.Text;
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Usuario : " + valor + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }
        if (e.CommandName == "CambiarPassword")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewUsuarios.DataKeys[fila].Value.ToString();
            lblModalTitlePassword.Text = "Cambio de Contraseña";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalPassword", "$('#ModalPassword').modal();", true);
            upModalPassword.Update();
        }
        if (e.CommandName == "EditarUsuario")
        {
            LoadComboPerfil();
            LoadComboPuesto();
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewUsuarios.DataKeys[fila].Value.ToString();
            txtUserPassword.Visible = false;
            txtUserPasswordConfirma.Visible = false;
            lblpasswordtitle.Visible = false;
            lblMensajeUserPass.Visible = false;
            lblMensajeUserPassConfirma.Visible = false;
            HiddenField tempperfil = GridViewUsuarios.Rows[fila].FindControl("iIdPerfil") as HiddenField;
            string valorperfil = tempperfil.Value;
            dropUserPerfil.Items.FindByValue(valorperfil.ToString()).Selected = true;      
            HiddenField temppuesto = GridViewUsuarios.Rows[fila].FindControl("iIdPuesto") as HiddenField;
            string valorpuesto = temppuesto.Value;
            dropUserPuesto.Items.FindByValue(valorpuesto.ToString()).Selected = true;
            HiddenField tempcentrocosto = GridViewUsuarios.Rows[fila].FindControl("iIdCentroCosto") as HiddenField;
            string valorcentrocosto = tempcentrocosto.Value;
            LoadComboCentrosCostos("Cargar Guardado", Convert.ToInt32(valorcentrocosto));
            lblModalTitleNuevo.Text = "Editar Usuario";
            Operacion.Value = "Editar";
            txtUserName.Text = (GridViewUsuarios.Rows[fila].FindControl("cNombreUsuario") as Label).Text;
            txtUserNombre.Text = (GridViewUsuarios.Rows[fila].FindControl("cNombre") as HiddenField).Value.ToString();
            txtUserApellidoPaterno.Text = (GridViewUsuarios.Rows[fila].FindControl("cApellidoPaterno") as HiddenField).Value.ToString();
            txtUserApellidoMaterno.Text = (GridViewUsuarios.Rows[fila].FindControl("cApellidoMaterno") as HiddenField).Value.ToString();
            txtNroEmpleado.Text = (GridViewUsuarios.Rows[fila].FindControl("iNumeroEmpleado") as HiddenField).Value.ToString();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperUsuario", "$('#ModalOperUsuario').modal();", true);
            upModalOperUsuario.Update();
        }
    }
    protected void BuscarUsuario_Click(object sender, EventArgs e)
    {
        GridViewUsuarios.DataSource = _catusuariosneg.list(Convert.ToInt32(dropFiltroPuesto.SelectedValue.ToString()), Convert.ToInt32(dropFiltroPerfil.SelectedValue.ToString()),0, txtNombreCompletoEmail.Text.ToString());
        GridViewUsuarios.DataBind();
    }
    protected void Nuevo_Click(object sender, EventArgs e)
    {
        lblMensajeUserName.Visible = false;
        lblMensajeUserNameCorreo.Visible = false;
        lblMensajeUserNombre.Visible = false;
        lblMensajeUserApellidoPaterno.Visible = false;
        lblMensajeUserApellidoMaterno.Visible = false;
        lblMensajeNroEmpleado.Visible = false;
        lblMensajeUserPass.Visible = false;
        lblMensajeUserPassConfirma.Visible = false;
        upModalOperUsuario.Update();
        if (txtUserName.Text != string.Empty)
        { 
            if (txtUserNombre.Text != string.Empty)
            {
                if (txtNroEmpleado.Text != string.Empty)
                {

                    if (txtUserApellidoPaterno.Text != string.Empty || txtUserApellidoMaterno.Text != string.Empty)
                    {
                        if ((txtUserPassword.Text != string.Empty & txtUserPasswordConfirma.Text != string.Empty) || Operacion.Value == "Editar")
                        {
                            if (txtUserPassword.Text == txtUserPasswordConfirma.Text || Operacion.Value == "Editar")
                            {
                                if (Operacion.Value == "Nuevo")
                                {
                                    UsuariosDatos catusuario = new UsuariosDatos();
                                    catusuario.objUsuario = new Usuarios();
                                    catusuario.objUsuario.iIdUsuarioGestion = Convert.ToInt32(Session["IdUser"]);
                                    catusuario.objUsuario.cNombreUsuario = txtUserName.Text;
                                    catusuario.objUsuario.cPassword = txtUserPassword.Text;
                                    catusuario.objUsuario.objPerfil = new Perfiles();
                                    catusuario.objUsuario.objPerfil.iIdPerfil = Convert.ToInt32(dropUserPerfil.SelectedValue.ToString());
                                    catusuario.cNombre = txtUserNombre.Text;
                                    catusuario.cApellidoPaterno = txtUserApellidoPaterno.Text;
                                    catusuario.cApellidoMaterno = txtUserApellidoMaterno.Text;
                                    catusuario.iNumeroEmpleado = Convert.ToInt32(txtNroEmpleado.Text);
                                    catusuario.iIdCentroCosto = Convert.ToInt32(dropUserDepartamento.SelectedValue.ToString());
                                    catusuario.objPuesto = new CatPuestos();
                                    catusuario.objPuesto.iIdPuesto = Convert.ToInt32(dropUserPuesto.SelectedValue.ToString());
                                    _catusuariosneg.insertUsuario(catusuario);
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperUsuario", "$('#ModalOperUsuario').modal('hide');", true);
                                    upModalOperUsuario.Update();
                                    GridViewUsuarios.DataSource = _catusuariosneg.list();
                                    GridViewUsuarios.DataBind();
                                }
                                if (Operacion.Value == "Editar")
                                {
                                    UsuariosDatos catusuario = new UsuariosDatos();
                                    catusuario.objUsuario = new Usuarios();
                                    catusuario.objUsuario.iIdUsuario = Convert.ToInt32(ID.Value);
                                    catusuario.objUsuario.cNombreUsuario = txtUserName.Text;
                                    catusuario.objUsuario.objPerfil = new Perfiles();
                                    catusuario.objUsuario.objPerfil.iIdPerfil = Convert.ToInt32(dropUserPerfil.SelectedValue.ToString());
                                    catusuario.cNombre = txtUserNombre.Text;
                                    catusuario.cApellidoPaterno = txtUserApellidoPaterno.Text;
                                    catusuario.cApellidoMaterno = txtUserApellidoMaterno.Text;
                                    catusuario.objPuesto = new CatPuestos();
                                    catusuario.iNumeroEmpleado = Convert.ToInt32(txtNroEmpleado.Text);
                                    catusuario.iIdCentroCosto = Convert.ToInt32(dropUserDepartamento.SelectedValue.ToString());
                                    catusuario.objPuesto.iIdPuesto = Convert.ToInt32(dropUserPuesto.SelectedValue.ToString());
                                    _catusuariosneg.modificarUsuario(catusuario);
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperUsuario", "$('#ModalOperUsuario').modal('hide');", true);
                                    upModalOperUsuario.Update();
                                    GridViewUsuarios.DataSource = _catusuariosneg.list();
                                    GridViewUsuarios.DataBind();
                                }
                            }
                            else
                            {
                                lblMensajeUserPassConfirma.Visible = true;
                            }

                        }
                        else
                        {
                            lblMensajeUserPass.Visible = true;
                        }
                    }
                    else
                    {
                        lblMensajeUserApellidoPaterno.Visible = true;
                        lblMensajeUserApellidoMaterno.Visible = true;
                    }
                }
                else
                {
                    lblMensajeNroEmpleado.Visible = true;
                }
            }
            else
            {
                lblMensajeUserNombre.Visible = true;
            }
        }
        else
        {
            lblMensajeUserName.Visible = true;
        }
    
   }
    protected void NuevoUsuario_Click(object sender, EventArgs e)
    {
        txtUserPassword.Visible = true;
        txtUserPasswordConfirma.Visible = true;
        lblpasswordtitle.Visible = true;
        lblMensajeUserName.Visible = false;
        lblMensajeUserNameCorreo.Visible = false;
        lblMensajeUserPass.Visible = false;
        lblMensajeUserPassConfirma.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Usuario";
        Operacion.Value = "Nuevo";
        txtUserName.Text = string.Empty;
        txtUserNombre.Text = string.Empty;
        txtUserPassword.Text = string.Empty;
        txtUserPasswordConfirma.Text = string.Empty;
        txtNroEmpleado.Text = string.Empty;
        txtUserNombre.Text = string.Empty;
        txtUserApellidoPaterno.Text = string.Empty;
        txtUserApellidoMaterno.Text = string.Empty;
        LoadComboPerfil();   
        LoadComboPuesto();
        LoadComboCentrosCostos();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalOperUsuario", "$('#ModalOperUsuario').modal();", true);
        upModalOperUsuario.Update();
    }
    protected void Eliminar_Click(object sender, EventArgs e)
    {
        UsuariosDatos _catusuario = new UsuariosDatos();
        _catusuario.objUsuario = new Usuarios();
        _catusuario.objUsuario.iIdUsuario = Convert.ToInt32(ID.Value.ToString());
        _catusuariosneg.eliminarUsuario(_catusuario);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
        upModalEliminar.Update();
        GridViewUsuarios.DataSource = _catusuariosneg.list();
        GridViewUsuarios.DataBind();
    }
    protected void Password_Click(object sender, EventArgs e)
    {
        if (txtUserPasswordCambio.Text != string.Empty & txtUserPasswordCambioConfirma.Text != string.Empty)
        {
            lblUserPasswordCambio.Visible = false;
            lblUserPasswordCambioConfirma.Visible = false;
            upModalPassword.Update();
            if (txtUserPasswordCambio.Text == txtUserPasswordCambioConfirma.Text)
            {
                UsuariosDatos _catusuario = new UsuariosDatos();
                _catusuario.objUsuario = new Usuarios();
                _catusuario.objUsuario.iIdUsuario = Convert.ToInt32(ID.Value.ToString());
                _catusuario.objUsuario.cPassword = txtUserPasswordCambio.Text;
                _catusuariosneg.cambiarPassword(_catusuario);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalPassword", "$('#ModalPassword').modal('hide');", true);
                upModalPassword.Update();
            }
            else
            {
                lblUserPasswordCambioConfirma.Visible = true;
            }
        }else
        {
            lblUserPasswordCambio.Visible = true;
        }
    }
    protected void dropUserDireccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadComboCentrosCostos("Direccion");
        upModalOperUsuario.Update();
    }
    protected void dropUserSubdireccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadComboCentrosCostos("Seleccion");
        upModalOperUsuario.Update();
    }
}