using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSistema;
using ESistema;

public partial class Administracion_Catalogos : System.Web.UI.Page
{

    CatPuestosBL _catpuesneg = new CatPuestosBL();
    CatPuestos _catpuesto;

    CatPeriodosBL _catperneg = new CatPeriodosBL();
    CatPeriodos _catperiodo;

    CatRamasBL _catramneg = new CatRamasBL();
    CatRamas _catrama;

    UsuariosBL _catusuariosneg = new UsuariosBL();
    CentrosCostosBL _catcentroscostosneg = new CentrosCostosBL();

    CatProcesosBL _catproneg = new CatProcesosBL();
    CatProcesos _catproceso;

    CatStatusBL _catstaneg = new CatStatusBL();
    CatStatus _catstatu;

    CatTiposSolicitudBL _CatTiposSolicitudBL = new CatTiposSolicitudBL();
    CatTiposSolicitud _CatTiposSolicitud;

    CatStatusOrdenBL _catstaorneg = new CatStatusOrdenBL();
    CatStatusOrden _catstatuorden;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");
        //Departamentos
        if (!Page.IsPostBack)
        {

            GridViewPuestos.DataSource = _catpuesneg.list();
            GridViewPuestos.DataBind();
            txtDescripcionNuevo.Attributes.Add("placeholder", "Nombre");
            txtDescripcionEditar.Attributes.Add("placeholder", "Nombre");

            //tabla Periodos
            GridViewPeriodos.DataSource = _catperneg.list();
            GridViewPeriodos.DataBind();
            txtDescPeriodoNuevo.Attributes.Add("placeholder", "Periodo");
            txtFechaIniNuevo.Attributes.Add("placeholder", "Fecha Inicial");
            txtFechaFiNuevo.Attributes.Add("placeholder", "Fecha Fin");
            txtPresidenteNuevo.Attributes.Add("placeholder", "Presidente");

            txtDescPeriodoEdit.Attributes.Add("placeholder", "Periodo");
            txtFechaIniEdit.Attributes.Add("placeholder", "Periodo");
            txtFechaFiEdit.Attributes.Add("placeholder", "Periodo");
            txtPresidenteEdit.Attributes.Add("placeholder", "Periodo");

            //tabla Ramas
            GridViewRamas.DataSource = _catramneg.ObtenerRamas();
            GridViewRamas.DataBind();
            txtDescRamaNueva.Attributes.Add("placeholder", "Rama");
            txtDescRamasEdit.Attributes.Add("placeholder", "Rama");

            //tabla Procesos
            GridViewProcesos.DataSource = _catproneg.ObtenerProcesos();
            GridViewProcesos.DataBind();
            txtDescProcesoNuevo.Attributes.Add("placeholder", "Proceso");
            LoadComboPeriodo();
            LoadComboRama();
            LoadComboUsuario();

            txtDescPeriodoEdit.Attributes.Add("placeholder", "Proceso");
            LoadComboEdPeriodo();
            LoadComboEdRama();
            LoadComboEdUsuario();

            //tabla Status
            GridViewStatus.DataSource = _catstaneg.ObtenerStatus();
            GridViewStatus.DataBind();
            txtDescStatusNuevo.Attributes.Add("placeholder", "Status");
            txtDescOrdenNuevo.Attributes.Add("placeholder", "Orden");
            LoadComboProceso();

            txtDescStatusEdit.Attributes.Add("placeholder", "Orden");
            txtDescOrdenEdit.Attributes.Add("placeholder", "Orden");
            LoadComboEdProceso();
            LoadComboEdUsuario();

            //tabla status orden
            GridViewStatusOrden.DataSource = _catstaorneg.ObtenerStatusOrden();
            GridViewStatusOrden.DataBind();
            LoadComboStatus();
            LoadComboStatusOrden();

            //tabla TipoSolicitud
            txtNombreTipoSolicitud.Attributes.Add("placeholder", "Tipo de Solicitud");
            LoadComboRamas();
            LoadComboProcesos();
            GridViewTipoSolicitud.DataSource = _CatTiposSolicitudBL.ObtenerTiposSolicitud();
            GridViewTipoSolicitud.DataBind();
        }
    }

    public void LoadComboRamas(string oper = null, int ID = 0)
    {
        if (oper == "filtro")
        {
            dropFiltroRamas.DataSource = _catramneg.ObtenerRamas();
            dropFiltroRamas.DataValueField = "iIdRama";
            dropFiltroRamas.DataTextField = "cNombre";
            dropFiltroRamas.DataBind();
            dropFiltroRamas.Items.Insert(0, new ListItem("Todas las Ramas", "0"));
            dropFiltroRamas.Items.FindByValue(ID.ToString()).Selected = true;
        }
        else
        {
            dropTipoSolicitudRama.DataSource = _catramneg.ObtenerRamas();
            dropTipoSolicitudRama.DataValueField = "iIdRama";
            dropTipoSolicitudRama.DataTextField = "cNombre";
            dropTipoSolicitudRama.DataBind();
        }
    }

    public void LoadComboProcesos(string oper = null, int ID = 0)
    {
        if (oper == "filtro")
        {
            dropFiltroProcesos.DataSource = _catproneg.ObtenerProcesos();
            dropFiltroProcesos.DataValueField = "iIdProceso";
            dropFiltroProcesos.DataTextField = "cNombre";
            dropFiltroProcesos.DataBind();
            dropFiltroProcesos.Items.Insert(0, new ListItem("Todos los Procesos", "0"));
            dropFiltroProcesos.Items.FindByValue(ID.ToString()).Selected = true;
        }
        else
        {
            dropTipoSolicitudProceso.DataSource = _catproneg.ObtenerProcesos();
            dropTipoSolicitudProceso.DataValueField = "iIdProceso";
            dropTipoSolicitudProceso.DataTextField = "cNombre";
            dropTipoSolicitudProceso.DataBind();
        }
    }

    public void LoadComboStatus()
    {
        dropstatus.DataSource = _catstaneg.ObtenerStatus();
        dropstatus.DataValueField = "iIdStatus";
        dropstatus.DataTextField = "cNombre";
        dropstatus.DataBind();
    }
    public void LoadComboStatusOrden()
    {
        dropstatudeN.DataSource = _catstaneg.ObtenerStatus();
        dropstatudeN.DataValueField = "iIdStatus";
        dropstatudeN.DataTextField = "cNombre";
        dropstatudeN.DataBind();
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

    public void LoadComboPeriodo()
    {
        dropperiodo.DataSource = _catperneg.list();
        dropperiodo.DataValueField = "iIdPeriodo";
        dropperiodo.DataTextField = "cNombre";
        dropperiodo.DataBind();
    }
    public void LoadComboEdPeriodo()
    {
        dropperiodoEd.DataSource = _catperneg.list();
        dropperiodoEd.DataValueField = "iIdPeriodo";
        dropperiodoEd.DataTextField = "cNombre";
        dropperiodoEd.DataBind();

    }
    public void LoadComboRama()
    {
        dropRama.DataSource = _catramneg.ObtenerRamas();
        dropRama.DataValueField = "iIdRama";
        dropRama.DataTextField = "cNombre";
        dropRama.DataBind();
    }
    public void LoadComboEdRama()
    {
        dropRamaEd.DataSource = _catramneg.ObtenerRamas();
        dropRamaEd.DataValueField = "iIdRama";
        dropRamaEd.DataTextField = "cNombre";
        dropRamaEd.DataBind();

    }
    public void LoadComboUsuario()
    {
        dropUsuario.DataSource = _catusuariosneg.list();
        dropUsuario.DataValueField = "iIdUsuario";
        dropUsuario.DataTextField = "cNombre";
        dropUsuario.DataBind();
    }
    public void LoadComboEdUsuario()
    {
        dropUsuarioEd.DataSource = _catusuariosneg.list();
        dropUsuarioEd.DataValueField = "iIdUsuario";
        dropUsuarioEd.DataTextField = "cNombre";
        dropUsuarioEd.DataBind();

    }
    public void LoadComboProceso()
    {
        dropproceso.DataSource = _catproneg.ObtenerProcesos();
        dropproceso.DataValueField = "iIdProceso";
        dropproceso.DataTextField = "cNombre";
        dropproceso.DataBind();
    }

    public void LoadComboEdProceso()
    {
        dropprocesoEd.DataSource = _catproneg.ObtenerProcesos();
        dropprocesoEd.DataValueField = "iIdProceso";
        dropprocesoEd.DataTextField = "cNombre";
        dropprocesoEd.DataBind();
    }
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditarPuesto")
        {
            lblMensajeEditar.Visible = false;
            divpuestosE.Style.Add("display", "block");
            divperiodosE.Style.Add("display", "none");
            divramasE.Style.Add("display", "none");
            divprocesosE.Style.Add("display", "none");
            divuserEd.Style.Add("display", "none");
            divstatusE.Style.Add("display", "none");
            divtipoSolN.Style.Add("display", "none");
            txtDescPeriodoEdit.Visible = false;
            txtFechaIniEdit.Visible = false;
            txtFechaFiEdit.Visible = false;
            txtPresidenteEdit.Visible = false;
            lblRamaE.Visible = false;
            txtDescRamasEdit.Visible = false;
            lblDirEd.Visible = false;
            lblSubEd.Visible = false;
            lblDeEd.Visible = false;
            dropCambiarDireccion.Visible = false;
            dropCambiarSubdireccion.Visible = false;
            dropCambiarDepartamento.Visible = false;
            lblProE.Visible = false;
            txtDescProcesoEdit.Visible = false;
            lblPeriodoEd.Visible = false;
            lblRamasEd.Visible = false;
            lblUsuarioEd.Visible = false;
            dropperiodoEd.Visible = false;
            dropRamaEd.Visible = false;
            dropUsuarioEd.Visible = false;
            txtDescripcionEditar.Visible = true;
            lbltipRama.Visible = false;
            lbltipPro.Visible = false;
            lbltipNombre.Visible = false;
            txtTipoSolicitudNombre.Visible = false;
            dropTipoSolicitudRama.Visible = false;
            dropTipoSolicitudProceso.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleEditar.Text = "Editar Puesto";
            txtDescripcionEditar.Text = HttpUtility.HtmlDecode(this.GridViewPuestos.Rows[fila].Cells[0].Text);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
            upModalEditar.Update();
            ID.Value = this.GridViewPuestos.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Puestos";
        }
        if (e.CommandName == "EliminarPuesto")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewPuestos.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Puestos";
            lblModalTitleEliminar.Text = "Eliminar";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Registro : " + this.GridViewPuestos.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }

        if (e.CommandName == "EditarPeriodo")
        {
            lblMensajeNP.Visible = false;
            divpuestosE.Style.Add("display", "none");
            divperiodosE.Style.Add("display", "block");
            divramasE.Style.Add("display", "none");
            divprocesosE.Style.Add("display", "none");
            divuserEd.Style.Add("display", "none");
            divstatusE.Style.Add("display", "none");
            divtipoSolN.Style.Add("display", "none");
            txtDescripcionEditar.Visible = false;
            txtDescPeriodoEdit.Visible = true;
            txtFechaIniEdit.Visible = true;
            txtFechaFiEdit.Visible = true;
            txtPresidenteEdit.Visible = true;
            lblRamaE.Visible = false;
            txtDescRamasEdit.Visible = false;
            lblDirEd.Visible = false;
            lblSubEd.Visible = false;
            lblDeEd.Visible = false;
            dropCambiarDireccion.Visible = false;
            dropCambiarSubdireccion.Visible = false;
            dropCambiarDepartamento.Visible = false;
            lblProE.Visible = false;
            txtDescProcesoEdit.Visible = false;
            lblPeriodoEd.Visible = false;
            lblRamasEd.Visible = false;
            lblUsuarioEd.Visible = false;
            dropperiodoEd.Visible = false;
            dropRamaEd.Visible = false;
            dropUsuarioEd.Visible = false;
            lbltipRama.Visible = false;
            lbltipPro.Visible = false;
            lbltipNombre.Visible = false;
            txtTipoSolicitudNombre.Visible = false;
            dropTipoSolicitudRama.Visible = false;
            dropTipoSolicitudProceso.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleEditar.Text = "Editar Periodo";
            txtDescPeriodoEdit.Text = HttpUtility.HtmlDecode(this.GridViewPeriodos.Rows[fila].Cells[0].Text);
            txtFechaIniEdit.Text = (GridViewPeriodos.Rows[fila].FindControl("dtFechaInicial") as HiddenField).Value.ToString();
            txtFechaFiEdit.Text = (GridViewPeriodos.Rows[fila].FindControl("dtFechaFinal") as HiddenField).Value.ToString();
            //txtFechaIniEdit.Text = HttpUtility.HtmlDecode(this.GridViewPeriodos.Rows[fila].Cells[1].Text);
            //txtFechaFiEdit.Text = HttpUtility.HtmlDecode(this.GridViewPeriodos.Rows[fila].Cells[2].Text);
            txtPresidenteEdit.Text = HttpUtility.HtmlDecode(this.GridViewPeriodos.Rows[fila].Cells[3].Text);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
            upModalEditar.Update();
            ID.Value = this.GridViewPeriodos.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Periodos";
        }
        if (e.CommandName == "EliminarPeriodo")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewPeriodos.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Periodos";
            lblModalTitleEliminar.Text = "Eliminar";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Registro : " + this.GridViewPeriodos.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }

        if (e.CommandName == "EditarRama")
        {
            lblMensajeER.Visible = false;
            divpuestosE.Style.Add("display", "none");
            divperiodosE.Style.Add("display", "none");
            divramasE.Style.Add("display", "block");
            divprocesosE.Style.Add("display", "none");
            divuserEd.Style.Add("display", "none");
            divstatusE.Style.Add("display", "none");
            divtipoSolN.Style.Add("display", "none");
            txtDescripcionEditar.Visible = false;
            txtDescPeriodoEdit.Visible = false;
            txtFechaIniEdit.Visible = false;
            txtFechaFiEdit.Visible = false;
            txtPresidenteEdit.Visible = false;
            lblRamaE.Visible = true;
            txtDescRamasEdit.Visible = true;
            lblDirEd.Visible = true;
            lblSubEd.Visible = true;
            lblDeEd.Visible = true;
            dropCambiarDireccion.Visible = true;
            dropCambiarSubdireccion.Visible = true;
            dropCambiarDepartamento.Visible = true;
            lblProE.Visible = false;
            txtDescProcesoEdit.Visible = false;
            lblPeriodoEd.Visible = false;
            lblRamasEd.Visible = false;
            lblUsuarioEd.Visible = false;
            dropperiodoEd.Visible = false;
            dropRamaEd.Visible = false;
            dropUsuarioEd.Visible = false;
            lbltipRama.Visible = false;
            lbltipPro.Visible = false;
            lbltipNombre.Visible = false;
            txtTipoSolicitudNombre.Visible = false;
            dropTipoSolicitudRama.Visible = false;
            dropTipoSolicitudProceso.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleEditar.Text = "Editar Rama";
            txtDescRamasEdit.Text = HttpUtility.HtmlDecode(this.GridViewRamas.Rows[fila].Cells[0].Text);
            HiddenField tempcentrocosto = GridViewRamas.Rows[fila].FindControl("iIdCentroCosto") as HiddenField;
            string valorcentrocosto = tempcentrocosto.Value;
            LoadComboCambiarCentrosCostos("Cargar Guardado", Convert.ToInt32(valorcentrocosto));
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
            upModalEditar.Update();
            ID.Value = this.GridViewRamas.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Ramas";
        }
        if (e.CommandName == "EliminarRama")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewRamas.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Ramas";
            lblModalTitleEliminar.Text = "Eliminar";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Registro : " + this.GridViewRamas.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }

        if (e.CommandName == "EditarProceso")
        {
            LoadComboEdRama();
            LoadComboEdPeriodo();
            LoadComboEdUsuario();
            lblMensajeER.Visible = false;
            divpuestosE.Style.Add("display", "none");
            divperiodosE.Style.Add("display", "none");
            divramasE.Style.Add("display", "none");
            divprocesosE.Style.Add("display", "block");
            divuserEd.Style.Add("display", "inline");
            divstatusE.Style.Add("display", "none");
            divtipoSolN.Style.Add("display", "none");
            txtDescripcionEditar.Visible = false;
            txtDescPeriodoEdit.Visible = false;
            txtFechaIniEdit.Visible = false;
            txtFechaFiEdit.Visible = false;
            txtPresidenteEdit.Visible = false;
            lblRamaE.Visible = false;
            txtDescRamasEdit.Visible = false;
            lblDirEd.Visible = false;
            lblSubEd.Visible = false;
            lblDeEd.Visible = false;
            dropCambiarDireccion.Visible = false;
            dropCambiarSubdireccion.Visible = false;
            dropCambiarDepartamento.Visible = false;
            lblProE.Visible = true;
            txtDescProcesoEdit.Visible = true;
            lblPeriodoEd.Visible = true;
            lblRamasEd.Visible = true;
            lblUsuarioEd.Visible = true;
            dropperiodoEd.Visible = true;
            dropRamaEd.Visible = true;
            dropUsuarioEd.Visible = true;
            lbltipRama.Visible = false;
            lbltipPro.Visible = false;
            lbltipNombre.Visible = false;
            txtTipoSolicitudNombre.Visible = false;
            dropTipoSolicitudRama.Visible = false;
            dropTipoSolicitudProceso.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleEditar.Text = "Editar Proceso";
            txtDescProcesoEdit.Text = ((Label)this.GridViewProcesos.Rows[fila].FindControl("cNombre")).Text;
            HiddenField temprama = GridViewProcesos.Rows[fila].FindControl("iIdRama") as HiddenField;
            string valorrama = temprama.Value;
            dropRamaEd.Items.FindByValue(valorrama.ToString()).Selected = true;
            HiddenField tempperiodo = GridViewProcesos.Rows[fila].FindControl("iIdPeriodo") as HiddenField;
            string valorperiodo = tempperiodo.Value;
            dropperiodoEd.Items.FindByValue(valorperiodo.ToString()).Selected = true;
            HiddenField tempuser = GridViewProcesos.Rows[fila].FindControl("iIdUsuarioGestion") as HiddenField;
            string valoruser = tempuser.Value;
            dropUsuarioEd.Items.FindByValue(valoruser.ToString()).Selected = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
            upModalEditar.Update();
            ID.Value = this.GridViewProcesos.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Procesos";
        }
        if (e.CommandName == "EliminarProceso")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewProcesos.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Procesos";
            lblModalTitleEliminar.Text = "Eliminar";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Registro : " + this.GridViewProcesos.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }

        if (e.CommandName == "EditarStatus")
        {
            LoadComboEdProceso();
            LoadComboEdUsuario();
            lblMensajeSE.Visible = false;
            divpuestosE.Style.Add("display", "none");
            divperiodosE.Style.Add("display", "none");
            divramasE.Style.Add("display", "none");
            divprocesosE.Style.Add("display", "none");
            divuserEd.Style.Add("display", "inline");
            divstatusE.Style.Add("display", "block");
            divtipoSolN.Style.Add("display", "none");
            txtDescripcionEditar.Visible = false;
            txtDescPeriodoEdit.Visible = false;
            txtFechaIniEdit.Visible = false;
            txtFechaFiEdit.Visible = false;
            txtPresidenteEdit.Visible = false;
            lblRamaE.Visible = false;
            txtDescRamasEdit.Visible = false;
            lblDirEd.Visible = false;
            lblSubEd.Visible = false;
            lblDeEd.Visible = false;
            dropCambiarDireccion.Visible = false;
            dropCambiarSubdireccion.Visible = false;
            dropCambiarDepartamento.Visible = false;
            lblProE.Visible = false;
            txtDescProcesoEdit.Visible = false;
            lblPeriodoEd.Visible = false;
            lblRamasEd.Visible = false;
            lblUsuarioEd.Visible = true;
            dropperiodoEd.Visible = false;
            dropRamaEd.Visible = false;
            dropUsuarioEd.Visible = true;
            lblStadoEd.Visible = true;
            txtDescStatusEdit.Visible = true;
            lblOrdeEd.Visible = true;
            txtDescOrdenEdit.Visible = true;
            lblStProEd.Visible = true;
            dropprocesoEd.Visible = true;
            lbltipRama.Visible = false;
            lbltipPro.Visible = false;
            lbltipNombre.Visible = false;
            txtTipoSolicitudNombre.Visible = false;
            dropTipoSolicitudRama.Visible = false;
            dropTipoSolicitudProceso.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleEditar.Text = "Editar Status";
            txtDescStatusEdit.Text = ((Label)this.GridViewStatus.Rows[fila].FindControl("cNombre")).Text;
            HiddenField tempestado = GridViewStatus.Rows[fila].FindControl("iIdproceso") as HiddenField;
            string valorstado = tempestado.Value;
            dropprocesoEd.Items.FindByValue(valorstado.ToString()).Selected = true;
            txtDescOrdenEdit.Text = ((Label)this.GridViewStatus.Rows[fila].FindControl("iOrden")).Text;
            HiddenField tempuser = GridViewStatus.Rows[fila].FindControl("iIdUsuarioGestion") as HiddenField;
            string valoruser = tempuser.Value;
            dropUsuarioEd.Items.FindByValue(valoruser.ToString()).Selected = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
            upModalEditar.Update();
            ID.Value = this.GridViewStatus.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Status";
        }
        if (e.CommandName == "EliminarStatus")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewStatus.DataKeys[fila].Value.ToString();
            Catalogo.Value = "Status";
            lblModalTitleEliminar.Text = "Eliminar";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Registro : " + this.GridViewStatus.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }

        if (e.CommandName == "EditarTipoSolicitud")
        {
            LoadComboRamas();
            LoadComboProcesos();
            lblMensajeNuevo.Visible = false;
            lblMensajeNP.Visible = false;
            lblMensajeNR.Visible = false;
            lblMensajeNPRST.Visible = false;
            divpuestosN.Style.Add("display", "none");
            divperiodosN.Style.Add("display", "none");
            divramasN.Style.Add("display", "none");
            divprocesoN.Style.Add("display", "none");
            divuserN.Style.Add("display", "none");
            divstatusN.Style.Add("display", "none");
            divtipoSolN.Style.Add("display", "block");
            txtDescripcionNuevo.Visible = false;
            txtDescPeriodoNuevo.Visible = false;
            txtFechaIniNuevo.Visible = false;
            txtFechaFiNuevo.Visible = false;
            txtPresidenteNuevo.Visible = false;
            lblRamaN.Visible = false;
            txtDescRamaNueva.Visible = false;
            lblDireccion.Visible = false;
            lblDepto.Visible = false;
            lblSub.Visible = false;
            dropUserDireccion.Visible = false;
            dropUserSubdireccion.Visible = false;
            dropUserDepartamento.Visible = false;
            lblProceN.Visible = false;
            txtDescProcesoNuevo.Visible = false;
            lblRamasN.Visible = false;
            lblUsuarioN.Visible = false;
            dropperiodo.Visible = false;
            dropRama.Visible = false;
            dropUsuario.Visible = false;
            lblStadoN.Visible = false;
            txtDescStatusNuevo.Visible = false;
            lblStProN.Visible = false;
            dropproceso.Visible = false;
            lblOrdeN.Visible = false;
            txtDescOrdenNuevo.Visible = false;
            lbltipRama.Visible = true;
            lbltipPro.Visible = true;
            lbltipNombre.Visible = true;
            txtTipoSolicitudNombre.Visible = true;
            dropTipoSolicitudProceso.Visible = true;
            dropTipoSolicitudRama.Visible = true;
            int fila = Convert.ToInt32(e.CommandArgument);
            lblModalTitleNuevo.Text = "Editar Tipo de Solicitud";
            txtTipoSolicitudNombre.Text = ((Label)this.GridViewTipoSolicitud.Rows[fila].FindControl("cNombreTipoSolicitud")).Text;
            HiddenField temprama = GridViewTipoSolicitud.Rows[fila].FindControl("iIdRama") as HiddenField;
            string valorrama = temprama.Value;
            dropTipoSolicitudRama.Items.FindByValue(valorrama.ToString()).Selected = true;
            HiddenField tempproceso = GridViewTipoSolicitud.Rows[fila].FindControl("iIdProceso") as HiddenField;
            string valorproceso = tempproceso.Value;
            dropTipoSolicitudProceso.Items.FindByValue(valorproceso.ToString()).Selected = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
            upModalNuevo.Update();
            ID.Value = this.GridViewTipoSolicitud.DataKeys[fila].Value.ToString();
            Catalogo.Value = "tipossolicitud";
        }
        if (e.CommandName == "EliminarTipoSolicitud")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewTipoSolicitud.DataKeys[fila].Value.ToString();
            lblModalTitleEliminar.Text = "Eliminar";
            Label labeltemp = GridViewTipoSolicitud.Rows[fila].FindControl("cNombreTipoSolicitud") as Label;
            string valor = labeltemp.Text;
            lblModalBodyEliminar.Text = "¿Esta seguro que desea eliminar el Tipo de Solicitud: " + valor + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }
        /*
                if (e.CommandName == "EditarStatusOrden")
                {
                    LoadComboEdProceso();
                    LoadComboEdUsuario();
                    lblMensajeSE.Visible = false;
                    divpuestosE.Style.Add("display", "none");
                    divperiodosE.Style.Add("display", "none");
                    divramasE.Style.Add("display", "none");
                    divprocesosE.Style.Add("display", "none");
                    divuserEd.Style.Add("display", "inline");
                    divstatusE.Style.Add("display", "block");
                    divtipoSolN.Style.Add("display", "none");
                    txtDescripcionEditar.Visible = false;
                    txtDescPeriodoEdit.Visible = false;
                    txtFechaIniEdit.Visible = false;
                    txtFechaFiEdit.Visible = false;
                    txtPresidenteEdit.Visible = false;
                    lblRamaE.Visible = false;
                    txtDescRamasEdit.Visible = false;
                    lblDirEd.Visible = false;
                    lblSubEd.Visible = false;
                    lblDeEd.Visible = false;
                    dropCambiarDireccion.Visible = false;
                    dropCambiarSubdireccion.Visible = false;
                    dropCambiarDepartamento.Visible = false;
                    lblProE.Visible = false;
                    txtDescProcesoEdit.Visible = false;
                    lblPeriodoEd.Visible = false;
                    lblRamasEd.Visible = false;
                    lblUsuarioEd.Visible = true;
                    dropperiodoEd.Visible = false;
                    dropRamaEd.Visible = false;
                    dropUsuarioEd.Visible = true;
                    lblStadoEd.Visible = true;
                    txtDescStatusEdit.Visible = true;
                    lblOrdeEd.Visible = true;
                    txtDescOrdenEdit.Visible = true;
                    lblStProEd.Visible = true;
                    dropprocesoEd.Visible = true;
                    lbltipRama.Visible = false;
                    lbltipPro.Visible = false;
                    lbltipNombre.Visible = false;
                    txtTipoSolicitudNombre.Visible = false;
                    dropTipoSolicitudRama.Visible = false;
                    dropTipoSolicitudProceso.Visible = false;
                    int fila = Convert.ToInt32(e.CommandArgument);
                    lblModalTitleEditar.Text = "Editar Status Orden";
                    txtDescStatusEdit.Text = ((Label)this.GridViewStatus.Rows[fila].FindControl("cNombre")).Text;
                    txtDescOrdenEdit.Text = ((Label)this.GridViewStatus.Rows[fila].FindControl("iOrden")).Text;
                    HiddenField tempestado = GridViewStatus.Rows[fila].FindControl("iIdproceso") as HiddenField;
                    string valorstado = tempestado.Value;
                    dropprocesoEd.Items.FindByValue(valorstado.ToString()).Selected = true;
                    HiddenField tempuser = GridViewStatus.Rows[fila].FindControl("iIdUsuarioGestion") as HiddenField;
                    string valoruser = tempuser.Value;
                    dropUsuarioEd.Items.FindByValue(valoruser.ToString()).Selected = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal();", true);
                    upModalEditar.Update();
                    ID.Value = this.GridViewStatus.DataKeys[fila].Value.ToString();
                    Catalogo.Value = "statusorden";
                }*/
        if (e.CommandName == "EliminarStatusOrden")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            ID.Value = this.GridViewStatusOrden.DataKeys[fila].Value.ToString();
            Catalogo.Value = "statusorden";
            lblModalTitleEliminar.Text = "Eliminar";
            lblModalBodyEliminar.Text = "¿ Esta seguro que desea eliminar el Registro : " + this.GridViewStatusOrden.Rows[fila].Cells[0].Text + " ?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModalEliminar.Update();
        }

    }

    protected void Nuevo_Click(object sender, EventArgs e)
    {
        /*if (txtTipoSolicitudNombre.Text != string.Empty || Catalogo.Value == "Editar" || Catalogo.Value == "tipossolicitud")
        {
            lblMensajeNuevo.Visible = false;
            lblMensajeNP.Visible = false;
            lblMensajeNR.Visible = false;
            lblMensajeNPRST.Visible = false;
            upModalNuevo.Update();
            if (Catalogo.Value == "Nuevo")
            {
                _CatTiposSolicitud = new CatTiposSolicitud();
                _CatTiposSolicitud.cNombre = txtTipoSolicitudNombre.Text;
                _CatTiposSolicitud.ObjRamas = new CatRamas();
                _CatTiposSolicitud.ObjRamas.iIdRama = Convert.ToInt32(dropTipoSolicitudRama.SelectedValue.ToString());
                _CatTiposSolicitud.ObjProcesos = new CatProcesos();
                _CatTiposSolicitud.ObjProcesos.iIdProceso = Convert.ToInt32(dropTipoSolicitudProceso.SelectedValue.ToString());
                _CatTiposSolicitud.ObjUsuarioGestion = new Usuarios();
                _CatTiposSolicitud.ObjUsuarioGestion.iIdUsuario = Convert.ToInt32(Session["IdUser"]);

                _CatTiposSolicitudBL.InsertarTiposSolicitud(_CatTiposSolicitud);

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewTipoSolicitud.DataSource = _CatTiposSolicitudBL.ObtenerTiposSolicitud();
                GridViewTipoSolicitud.DataBind();

            }
            if (Catalogo.Value == "Editar")
            {

                _CatTiposSolicitud = new CatTiposSolicitud();
                _CatTiposSolicitud.ObjRamas = new CatRamas();
                _CatTiposSolicitud.ObjProcesos = new CatProcesos();
                _CatTiposSolicitud.ObjUsuarioGestion = new Usuarios();
                _CatTiposSolicitud.iIdTipoSolicitud = Convert.ToInt32(ID.Value);
                _CatTiposSolicitud.cNombre = txtTipoSolicitudNombre.Text;
                _CatTiposSolicitud.ObjRamas.iIdRama = Convert.ToInt32(dropTipoSolicitudRama.SelectedValue.ToString());
                _CatTiposSolicitud.ObjProcesos.iIdProceso = Convert.ToInt32(dropTipoSolicitudProceso.SelectedValue.ToString());
                _CatTiposSolicitud.ObjUsuarioGestion.iIdUsuario = Convert.ToInt32(Session["IdUser"]);
                _CatTiposSolicitudBL.ModificarTiposSolicitud(_CatTiposSolicitud);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewTipoSolicitud.DataSource = _CatTiposSolicitudBL.ObtenerTiposSolicitud();
                GridViewTipoSolicitud.DataBind();

            }

        }
        */

        if (Catalogo.Value == "Puestos")
        {
            if (txtDescripcionNuevo.Text == string.Empty)
            {
                lblMensajeNuevo.Visible = true;
                lblMensajeNP.Visible = false;
                lblMensajeNR.Visible = false;
                lblMensajeNPRST.Visible = false;
                upModalNuevo.Update();
            }
            else
            {
                _catpuesto = new CatPuestos();
                _catpuesto.cNombre = txtDescripcionNuevo.Text;
                _catpuesto.iIdUsuarioGestion = (int)Session["IdUser"];
                _catpuesneg.insertarPuesto(_catpuesto);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewPuestos.DataSource = _catpuesneg.list();
                GridViewPuestos.DataBind();
            }
        }

        if (Catalogo.Value == "Periodos")
        {
            if (txtDescPeriodoNuevo.Text == string.Empty)
            {
                lblMensajeNuevo.Visible = false;
                lblMensajeNP.Visible = true;
                lblMensajeNR.Visible = false;
                lblMensajeNPRST.Visible = false;
                upModalNuevo.Update();
            }
            else
            {
                _catperiodo = new CatPeriodos();
                _catperiodo.cNombre = txtDescPeriodoNuevo.Text;
                _catperiodo.dtFechaInicial = Convert.ToDateTime(txtFechaIniNuevo.Text);
                _catperiodo.dtFechaFinal = Convert.ToDateTime(txtFechaFiNuevo.Text);
                _catperiodo.cPresidenteMunicipal = txtPresidenteNuevo.Text;
                _catperiodo.iIdUsuario = (int)Session["IdUser"];
                _catperneg.insertarPeriodo(_catperiodo);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewPeriodos.DataSource = _catperneg.list();
                GridViewPeriodos.DataBind();
            }
        }

        if (Catalogo.Value == "Ramas")
        {
            if (txtDescRamaNueva.Text == string.Empty)
            {
                lblMensajeNuevo.Visible = false;
                lblMensajeNP.Visible = false;
                lblMensajeNR.Visible = true;
                lblMensajeNPRST.Visible = false;
                upModalNuevo.Update();
            }
            else
            {
                _catrama = new CatRamas();
                _catrama.ObjCentrosCostos = new CentrosCostos();
                _catrama.ObjUsuarioGestion = new Usuarios();
                _catrama.cNombre = txtDescRamaNueva.Text;
                _catrama.ObjCentrosCostos.iIdCentroCosto = Convert.ToInt32(dropUserDepartamento.SelectedValue.ToString());
                _catrama.ObjUsuarioGestion.iIdUsuarioGestion = (int)Session["IdUser"];
                _catramneg.InsertarRamas(_catrama);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewRamas.DataSource = _catramneg.ObtenerRamas();
                GridViewRamas.DataBind();
            }
        }

        if (Catalogo.Value == "Procesos")
        {
            if (txtDescProcesoNuevo.Text == string.Empty)
            {
                lblMensajeNuevo.Visible = false;
                lblMensajeNP.Visible = false;
                lblMensajeNR.Visible = false;
                lblMensajeNPRST.Visible = true;
                upModalNuevo.Update();
            }
            else
            {
                _catproceso = new CatProcesos();
                _catproceso.objPeriodos = new CatPeriodos();
                _catproceso.objRamas = new CatRamas();
                _catproceso.ObjUsuarioGestion = new Usuarios();
                _catproceso.cNombre = txtDescProcesoNuevo.Text;
                _catproceso.objRamas.iIdRama = Convert.ToInt32(dropRama.SelectedValue.ToString());
                _catproceso.objPeriodos.iIdPeriodo = Convert.ToInt32(dropperiodo.SelectedValue.ToString());
                _catproceso.ObjUsuarioGestion.iIdUsuario = Convert.ToInt32(dropUsuario.SelectedValue.ToString());
                _catproneg.InsertarProcesos(_catproceso);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewProcesos.DataSource = _catproneg.ObtenerProcesos();
                GridViewProcesos.DataBind();
            }
        }

        if (Catalogo.Value == "Status")
        {
            if (txtDescStatusNuevo.Text == string.Empty || txtDescOrdenNuevo.Text == string.Empty)
            {
                lblMensajeNuevo.Visible = false;
                lblMensajeNP.Visible = false;
                lblMensajeNR.Visible = false;
                lblMensajeNPRST.Visible = true;
                upModalNuevo.Update();
            }
            else
            {
                _catstatu = new CatStatus();
                _catstatu.objProcesos = new CatProcesos();
                _catstatu.ObjUsuarioGestion = new Usuarios();
                _catstatu.cNombre = txtDescStatusNuevo.Text;
                _catstatu.objProcesos.iIdProceso = Convert.ToInt32(dropproceso.SelectedValue.ToString());
                _catstatu.iOrden = Convert.ToInt32(txtDescOrdenNuevo.Text);
                _catstatu.ObjUsuarioGestion.iIdUsuario = Convert.ToInt32(dropUsuario.SelectedValue.ToString());
                _catstaneg.InsertarStatus(_catstatu);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewStatus.DataSource = _catstaneg.ObtenerStatus();
                GridViewStatus.DataBind();
            }
        }

        if (Catalogo.Value == "StatusOrden")
        {
            lblMensajeNuevo.Visible = false;
            lblMensajeNP.Visible = false;
            lblMensajeNR.Visible = false;
            lblMensajeNPRST.Visible = true;
            upModalNuevo.Update();

            _catstatuorden = new CatStatusOrden();
            _catstatuorden.objProcesos = new CatProcesos();
            _catstatuorden.objStatus = new CatStatus();
            _catstatuorden.objStatusDestino = new CatStatus();
            _catstatuorden.ObjUsuarioGestion = new Usuarios();
            _catstatuorden.objProcesos.iIdProceso = Convert.ToInt32(dropproceso.SelectedValue.ToString());
            _catstatuorden.objStatus.iIdStatus = Convert.ToInt32(dropstatus.SelectedValue.ToString());
            _catstatuorden.objStatusDestino.iIdStatus = Convert.ToInt32(dropstatudeN.SelectedValue.ToString());
            _catstatuorden.ObjUsuarioGestion.iIdUsuario = Convert.ToInt32(dropUsuario.SelectedValue.ToString());
            _catstaorneg.InsertarStatus(_catstatuorden);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
            upModalNuevo.Update();
            GridViewStatusOrden.DataSource = _catstaorneg.ObtenerStatusOrden();
            GridViewStatusOrden.DataBind();

        }

        if (Catalogo.Value == "tipossolicitud" || Catalogo.Value == "Nuevo")
        {
            if (txtTipoSolicitudNombre.Text == string.Empty)
            {
                lblMensajeNuevo.Visible = false;
                lblMensajeNP.Visible = false;
                lblMensajeNR.Visible = false;
                lblMensajeNPRST.Visible = false;
                upModalNuevo.Update();
            }
            else
            {
                _CatTiposSolicitud = new CatTiposSolicitud();
                _CatTiposSolicitud.cNombre = txtTipoSolicitudNombre.Text;
                _CatTiposSolicitud.ObjRamas = new CatRamas();
                _CatTiposSolicitud.ObjRamas.iIdRama = Convert.ToInt32(dropTipoSolicitudRama.SelectedValue.ToString());
                _CatTiposSolicitud.ObjProcesos = new CatProcesos();
                _CatTiposSolicitud.ObjProcesos.iIdProceso = Convert.ToInt32(dropTipoSolicitudProceso.SelectedValue.ToString());
                _CatTiposSolicitud.ObjUsuarioGestion = new Usuarios();
                _CatTiposSolicitud.ObjUsuarioGestion.iIdUsuario = Convert.ToInt32(Session["IdUser"]);

                _CatTiposSolicitudBL.InsertarTiposSolicitud(_CatTiposSolicitud);

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewTipoSolicitud.DataSource = _CatTiposSolicitudBL.ObtenerTiposSolicitud();
                GridViewTipoSolicitud.DataBind();

            }
        }

        else if (Catalogo.Value == "tipossolicitud" || Catalogo.Value == "Editar")
        {
            if (txtTipoSolicitudNombre.Text != string.Empty)
            {
                lblMensajeNuevo.Visible = false;
                lblMensajeNP.Visible = false;
                lblMensajeNR.Visible = false;
                lblMensajeNPRST.Visible = false;
                upModalNuevo.Update();
            }
            else
            {

                _CatTiposSolicitud = new CatTiposSolicitud();
                _CatTiposSolicitud.ObjRamas = new CatRamas();
                _CatTiposSolicitud.ObjProcesos = new CatProcesos();
                _CatTiposSolicitud.ObjUsuarioGestion = new Usuarios();
                _CatTiposSolicitud.iIdTipoSolicitud = Convert.ToInt32(ID.Value);
                _CatTiposSolicitud.cNombre = txtTipoSolicitudNombre.Text;
                _CatTiposSolicitud.ObjRamas.iIdRama = Convert.ToInt32(dropTipoSolicitudRama.SelectedValue.ToString());
                _CatTiposSolicitud.ObjProcesos.iIdProceso = Convert.ToInt32(dropTipoSolicitudProceso.SelectedValue.ToString());
                _CatTiposSolicitud.ObjUsuarioGestion.iIdUsuario = Convert.ToInt32(Session["IdUser"]);
                _CatTiposSolicitudBL.ModificarTiposSolicitud(_CatTiposSolicitud);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewTipoSolicitud.DataSource = _CatTiposSolicitudBL.ObtenerTiposSolicitud();
                GridViewTipoSolicitud.DataBind();

            }
        }


    }

    protected void BuscarPuesto_Click(object sender, EventArgs e)
    {
        GridViewPuestos.DataSource = _catpuesneg.list(txtBuscarPuesto.Text);
        GridViewPuestos.DataBind();
    }

    protected void BuscarPeriodo_Click(object sender, EventArgs e)
    {
        GridViewPeriodos.DataSource = _catperneg.list(0, txtBuscarPeriodo.Text);
        GridViewPeriodos.DataBind();
    }

    protected void BuscarRama_Click(object sender, EventArgs e)
    {
        GridViewRamas.DataSource = _catramneg.ObtenerRamas(0, txtBuscarRama.Text);
        GridViewRamas.DataBind();
    }

    protected void BuscarProceso_Click(object sender, EventArgs e)
    {
        GridViewProcesos.DataSource = _catproneg.ObtenerProcesos(0, txtBuscarProceso.Text);
        GridViewProcesos.DataBind();
    }

    protected void BuscarStatus_Click(object sender, EventArgs e)
    {
        GridViewStatus.DataSource = _catstaneg.ObtenerStatus(0, txtBuscarStatus.Text);
        GridViewStatus.DataBind();
    }

    protected void BuscarStatusOrden_Click(object sender, EventArgs e)
    {
        GridViewStatusOrden.DataSource = _catstaorneg.ObtenerStatusOrden(0, txtBuscarStatusOrden.Text);
        GridViewStatusOrden.DataBind();
    }

    protected void BuscarTipoSolicitud_Click(object sender, EventArgs e)
    {
        GridViewTipoSolicitud.DataSource = _CatTiposSolicitudBL.ObtenerTiposSolicitud(0, txtNombreTipoSolicitud.Text.ToString());
        GridViewTipoSolicitud.DataBind();
    }
    protected void NuevoPuesto_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblMensajeNP.Visible = false;
        lblMensajeNR.Visible = false;
        lblMensajeNPRST.Visible = false;
        divpuestosN.Style.Add("display", "block");
        divperiodosN.Style.Add("display", "none");
        divramasN.Style.Add("display", "none");
        divprocesoN.Style.Add("display", "none");
        divuserN.Style.Add("display", "none");
        divstatusN.Style.Add("display", "none");
        divprocN.Style.Add("display", "none");
        divstatusOrN.Style.Add("display", "none");
        divtipoSolN.Style.Add("display", "none");
        txtDescPeriodoNuevo.Visible = false;
        txtFechaIniNuevo.Visible = false;
        txtFechaFiNuevo.Visible = false;
        txtPresidenteNuevo.Visible = false;
        txtDescRamaNueva.Visible = false;
        lblRamaN.Visible = false;
        lblDireccion.Visible = false;
        lblDepto.Visible = false;
        lblSub.Visible = false;
        dropUserDireccion.Visible = false;
        dropUserSubdireccion.Visible = false;
        dropUserDepartamento.Visible = false;
        txtDescripcionNuevo.Visible = true;
        lblProceN.Visible = false;
        txtDescProcesoNuevo.Visible = false;
        lblRamasN.Visible = false;
        lblUsuarioN.Visible = false;
        dropperiodo.Visible = false;
        dropRama.Visible = false;
        dropUsuario.Visible = false;
        lblStadoN.Visible = false;
        txtDescStatusNuevo.Visible = false;
        lblStProN.Visible = false;
        dropproceso.Visible = false;
        lblOrdeN.Visible = false;
        txtDescOrdenNuevo.Visible = false;
        lbltipRama.Visible = false;
        lbltipPro.Visible = false;
        lbltipNombre.Visible = false;
        txtTipoSolicitudNombre.Visible = false;
        dropTipoSolicitudProceso.Visible = false;
        dropTipoSolicitudRama.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Puesto";
        txtDescripcionNuevo.Text = string.Empty;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "Puestos";
    }

    protected void NuevoPeriodo_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblMensajeNP.Visible = false;
        lblMensajeNR.Visible = false;
        lblMensajeNPRST.Visible = false;
        divpuestosN.Style.Add("display", "none");
        divperiodosN.Style.Add("display", "block");
        divramasN.Style.Add("display", "none");
        divprocesoN.Style.Add("display", "none");
        divuserN.Style.Add("display", "none");
        divstatusN.Style.Add("display", "none");
        divtipoSolN.Style.Add("display", "none");
        divprocN.Style.Add("display", "none");
        divstatusOrN.Style.Add("display", "none");
        txtDescripcionNuevo.Visible = false;
        txtDescPeriodoNuevo.Visible = true;
        txtFechaIniNuevo.Visible = true;
        txtFechaFiNuevo.Visible = true;
        txtPresidenteNuevo.Visible = true;
        txtDescRamaNueva.Visible = false;
        lblRamaN.Visible = false;
        lblDireccion.Visible = false;
        lblDepto.Visible = false;
        lblSub.Visible = false;
        dropUserDireccion.Visible = false;
        dropUserSubdireccion.Visible = false;
        dropUserDepartamento.Visible = false;
        lblProceN.Visible = false;
        txtDescProcesoNuevo.Visible = false;
        lblRamasN.Visible = false;
        lblUsuarioN.Visible = false;
        dropperiodo.Visible = false;
        dropRama.Visible = false;
        dropUsuario.Visible = false;
        lblStadoN.Visible = false;
        txtDescStatusNuevo.Visible = false;
        lblStProN.Visible = false;
        dropproceso.Visible = false;
        lblOrdeN.Visible = false;
        txtDescOrdenNuevo.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Periodo";
        txtDescPeriodoNuevo.Text = string.Empty;
        txtFechaIniNuevo.Text = string.Empty;
        txtFechaFiNuevo.Text = string.Empty;
        txtPresidenteNuevo.Text = string.Empty;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "Periodos";
    }

    protected void NuevaRama_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblMensajeNP.Visible = false;
        lblMensajeNR.Visible = false;
        lblMensajeNPRST.Visible = false;
        divpuestosN.Style.Add("display", "none");
        divperiodosN.Style.Add("display", "none");
        divramasN.Style.Add("display", "block");
        divprocesoN.Style.Add("display", "none");
        divuserN.Style.Add("display", "none");
        divstatusN.Style.Add("display", "none");
        divtipoSolN.Style.Add("display", "none");
        divprocN.Style.Add("display", "none");
        divstatusOrN.Style.Add("display", "none");
        txtDescripcionNuevo.Visible = false;
        txtDescPeriodoNuevo.Visible = false;
        txtFechaIniNuevo.Visible = false;
        txtFechaFiNuevo.Visible = false;
        txtPresidenteNuevo.Visible = false;
        lblRamaN.Visible = true;
        txtDescRamaNueva.Visible = true;
        lblDireccion.Visible = true;
        lblDepto.Visible = true;
        lblSub.Visible = true;
        dropUserDireccion.Visible = true;
        dropUserSubdireccion.Visible = true;
        dropUserDepartamento.Visible = true;
        lblProceN.Visible = false;
        txtDescProcesoNuevo.Visible = false;
        lblRamasN.Visible = false;
        lblUsuarioN.Visible = false;
        dropperiodo.Visible = false;
        dropRama.Visible = false;
        dropUsuario.Visible = false;
        lblStadoN.Visible = false;
        txtDescStatusNuevo.Visible = false;
        lblStProN.Visible = false;
        dropproceso.Visible = false;
        lblOrdeN.Visible = false;
        txtDescOrdenNuevo.Visible = false;
        lbltipRama.Visible = false;
        lbltipPro.Visible = false;
        lbltipNombre.Visible = false;
        txtTipoSolicitudNombre.Visible = false;
        dropTipoSolicitudProceso.Visible = false;
        dropTipoSolicitudRama.Visible = false;
        lblModalTitleNuevo.Text = "Nueva Rama";
        txtDescRamaNueva.Text = string.Empty;
        LoadComboCentrosCostos();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "Ramas";
    }

    protected void NuevoProceso_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblMensajeNP.Visible = false;
        lblMensajeNR.Visible = false;
        lblMensajeNPRST.Visible = false;
        divpuestosN.Style.Add("display", "none");
        divperiodosN.Style.Add("display", "none");
        divramasN.Style.Add("display", "none");
        divuserN.Style.Add("display", "inline");
        divprocesoN.Style.Add("display", "block");
        divstatusN.Style.Add("display", "none");
        divtipoSolN.Style.Add("display", "none");
        divprocN.Style.Add("display", "none");
        divstatusOrN.Style.Add("display", "none");
        txtDescripcionNuevo.Visible = false;
        txtDescPeriodoNuevo.Visible = false;
        txtFechaIniNuevo.Visible = false;
        txtFechaFiNuevo.Visible = false;
        txtPresidenteNuevo.Visible = false;
        lblRamaN.Visible = false;
        txtDescRamaNueva.Visible = false;
        lblDireccion.Visible = false;
        lblDepto.Visible = false;
        lblSub.Visible = false;
        dropUserDireccion.Visible = false;
        dropUserSubdireccion.Visible = false;
        dropUserDepartamento.Visible = false;
        lblProceN.Visible = true;
        txtDescProcesoNuevo.Visible = true;
        lblRamasN.Visible = true;
        lblUsuarioN.Visible = true;
        dropperiodo.Visible = true;
        dropRama.Visible = true;
        dropUsuario.Visible = true;
        lblStadoN.Visible = false;
        txtDescStatusNuevo.Visible = false;
        lblStProN.Visible = false;
        dropproceso.Visible = false;
        lblOrdeN.Visible = false;
        txtDescOrdenNuevo.Visible = false;
        lbltipRama.Visible = false;
        lbltipPro.Visible = false;
        lbltipNombre.Visible = false;
        txtTipoSolicitudNombre.Visible = false;
        dropTipoSolicitudProceso.Visible = false;
        dropTipoSolicitudRama.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Proceso";
        txtDescProcesoNuevo.Text = string.Empty;
        LoadComboRama();
        LoadComboPeriodo();
        LoadComboUsuario();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "Procesos";
    }

    protected void NuevoStatus_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblMensajeNP.Visible = false;
        lblMensajeNR.Visible = false;
        lblMensajeNPRST.Visible = false;
        divpuestosN.Style.Add("display", "none");
        divperiodosN.Style.Add("display", "none");
        divramasN.Style.Add("display", "none");
        divprocesoN.Style.Add("display", "none");
        divuserN.Style.Add("display", "inline");
        divstatusN.Style.Add("display", "block");
        divtipoSolN.Style.Add("display", "none");
        divprocN.Style.Add("display", "block");
        divstatusOrN.Style.Add("display", "none");
        txtDescripcionNuevo.Visible = false;
        txtDescPeriodoNuevo.Visible = false;
        txtFechaIniNuevo.Visible = false;
        txtFechaFiNuevo.Visible = false;
        txtPresidenteNuevo.Visible = false;
        lblRamaN.Visible = false;
        txtDescRamaNueva.Visible = false;
        lblDireccion.Visible = false;
        lblDepto.Visible = false;
        lblSub.Visible = false;
        dropUserDireccion.Visible = false;
        dropUserSubdireccion.Visible = false;
        dropUserDepartamento.Visible = false;
        lblProceN.Visible = false;
        txtDescProcesoNuevo.Visible = false;
        lblRamasN.Visible = false;
        lblUsuarioN.Visible = true;
        dropperiodo.Visible = false;
        dropRama.Visible = false;
        dropUsuario.Visible = true;
        lblStadoN.Visible = true;
        txtDescStatusNuevo.Visible = true;
        lblStProN.Visible = true;
        dropproceso.Visible = true;
        lblOrdeN.Visible = true;
        txtDescOrdenNuevo.Visible = true;
        lbltipRama.Visible = false;
        lbltipPro.Visible = false;
        lbltipNombre.Visible = false;
        txtTipoSolicitudNombre.Visible = false;
        dropTipoSolicitudProceso.Visible = false;
        dropTipoSolicitudRama.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Status";
        txtDescStatusNuevo.Text = string.Empty;
        txtDescOrdenNuevo.Text = string.Empty;
        LoadComboProceso();
        LoadComboUsuario();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "Status";
    }

    protected void NuevoStatusOrden_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblMensajeNP.Visible = false;
        lblMensajeNR.Visible = false;
        lblMensajeNPRST.Visible = false;
        divpuestosN.Style.Add("display", "none");
        divperiodosN.Style.Add("display", "none");
        divramasN.Style.Add("display", "none");
        divprocesoN.Style.Add("display", "none");
        divuserN.Style.Add("display", "inline");
        divstatusN.Style.Add("display", "block");
        divtipoSolN.Style.Add("display", "none");
        divprocN.Style.Add("display", "block");
        divstatusOrN.Style.Add("display", "block");
        txtDescripcionNuevo.Visible = false;
        txtDescPeriodoNuevo.Visible = false;
        txtFechaIniNuevo.Visible = false;
        txtFechaFiNuevo.Visible = false;
        txtPresidenteNuevo.Visible = false;
        lblRamaN.Visible = false;
        txtDescRamaNueva.Visible = false;
        lblDireccion.Visible = false;
        lblDepto.Visible = false;
        lblSub.Visible = false;
        dropUserDireccion.Visible = false;
        dropUserSubdireccion.Visible = false;
        dropUserDepartamento.Visible = false;
        lblProceN.Visible = false;
        txtDescProcesoNuevo.Visible = false;
        lblRamasN.Visible = false;
        lblUsuarioN.Visible = true;
        dropperiodo.Visible = false;
        dropRama.Visible = false;
        dropUsuario.Visible = true;
        lblStadoN.Visible = false;
        txtDescStatusNuevo.Visible = false;
        lblStProN.Visible = true;
        dropproceso.Visible = true;
        lblOrdeN.Visible = false;
        txtDescOrdenNuevo.Visible = false;
        lbltipRama.Visible = false;
        lbltipPro.Visible = false;
        lbltipNombre.Visible = false;
        txtTipoSolicitudNombre.Visible = false;
        dropTipoSolicitudProceso.Visible = false;
        dropTipoSolicitudRama.Visible = false;
        lblStOrdN.Visible = true;
        dropstatus.Visible = true;
        lblStorddesN.Visible = true;
        dropstatudeN.Visible = true;
        lblModalTitleNuevo.Text = "Nuevo Status Orden";
        LoadComboProceso();
        LoadComboUsuario();
        LoadComboStatus();
        LoadComboStatusOrden();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "StatusOrden";
    }

    protected void NuevoTipoSolictud_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblMensajeNP.Visible = false;
        lblMensajeNR.Visible = false;
        lblMensajeNPRST.Visible = false;
        divpuestosN.Style.Add("display", "none");
        divperiodosN.Style.Add("display", "none");
        divramasN.Style.Add("display", "none");
        divprocesoN.Style.Add("display", "none");
        divuserN.Style.Add("display", "none");
        divstatusN.Style.Add("display", "none");
        divprocN.Style.Add("display", "none");
        divstatusOrN.Style.Add("display", "none");
        divtipoSolN.Style.Add("display", "block");
        txtDescripcionNuevo.Visible = false;
        txtDescPeriodoNuevo.Visible = false;
        txtFechaIniNuevo.Visible = false;
        txtFechaFiNuevo.Visible = false;
        txtPresidenteNuevo.Visible = false;
        lblRamaN.Visible = false;
        txtDescRamaNueva.Visible = false;
        lblDireccion.Visible = false;
        lblDepto.Visible = false;
        lblSub.Visible = false;
        dropUserDireccion.Visible = false;
        dropUserSubdireccion.Visible = false;
        dropUserDepartamento.Visible = false;
        lblProceN.Visible = false;
        txtDescProcesoNuevo.Visible = false;
        lblRamasN.Visible = false;
        lblUsuarioN.Visible = false;
        dropperiodo.Visible = false;
        dropRama.Visible = false;
        dropUsuario.Visible = false;
        lblStadoN.Visible = false;
        txtDescStatusNuevo.Visible = false;
        lblStProN.Visible = false;
        dropproceso.Visible = false;
        lblOrdeN.Visible = false;
        txtDescOrdenNuevo.Visible = false;
        lbltipRama.Visible = true;
        lbltipPro.Visible = true;
        lbltipNombre.Visible = true;
        txtTipoSolicitudNombre.Visible = true;
        dropTipoSolicitudProceso.Visible = true;
        dropTipoSolicitudRama.Visible = true;
        lblModalTitleNuevo.Text = "Nuevo Tipo Solicitud";
        txtTipoSolicitudNombre.Text = string.Empty;
        LoadComboRamas();
        LoadComboProcesos();
        lblStOrdN.Visible = false;
        lblStorddesN.Visible = false;
        dropstatus.Visible = false;
        dropstatudeN.Visible = false;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "tipossolicitud";
    }


    protected void Eliminar_Click(object sender, EventArgs e)
    {

        if (Catalogo.Value == "Puestos")
        {
            _catpuesto = new CatPuestos();
            _catpuesto.iIdPuesto = Convert.ToInt32(ID.Value.ToString());
            _catpuesneg.eliminarPuesto(_catpuesto);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewPuestos.DataSource = _catpuesneg.list();
            GridViewPuestos.DataBind();
        }

        if (Catalogo.Value == "Periodos")
        {
            _catperiodo = new CatPeriodos();
            _catperiodo.iIdPeriodo = Convert.ToInt32(ID.Value.ToString());
            _catperneg.eliminarPeriodo(_catperiodo);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewPeriodos.DataSource = _catperneg.list();
            GridViewPeriodos.DataBind();
        }

        if (Catalogo.Value == "Ramas")
        {
            _catrama = new CatRamas();
            _catrama.iIdRama = Convert.ToInt32(ID.Value.ToString());
            _catramneg.EliminarRamas(_catrama);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewRamas.DataSource = _catramneg.ObtenerRamas();
            GridViewRamas.DataBind();
        }

        if (Catalogo.Value == "Procesos")
        {
            _catproceso = new CatProcesos();
            _catproceso.iIdProceso = Convert.ToInt32(ID.Value.ToString());
            _catproneg.EliminarProcesos(_catproceso);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewProcesos.DataSource = _catproneg.ObtenerProcesos();
            GridViewProcesos.DataBind();
        }

        if (Catalogo.Value == "Status")
        {
            _catstatu = new CatStatus();
            _catstatu.iIdStatus = Convert.ToInt32(ID.Value.ToString());
            _catstaneg.EliminarStatus(_catstatu);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewStatus.DataSource = _catstaneg.ObtenerStatus();
            GridViewStatus.DataBind();
        }

        if (Catalogo.Value == "StatusOrden")
        {
            _catstatuorden = new CatStatusOrden();
            _catstatuorden.iIdStatusOrden = Convert.ToInt32(ID.Value.ToString());
            _catstaorneg.EliminarStatus(_catstatuorden);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewStatusOrden.DataSource = _catstaorneg.ObtenerStatusOrden();
            GridViewStatusOrden.DataBind();
        }

        if (Catalogo.Value == "tipossolicitud")
        {
            _CatTiposSolicitud = new CatTiposSolicitud();
            _CatTiposSolicitud.iIdTipoSolicitud = Convert.ToInt32(ID.Value.ToString());
            _CatTiposSolicitudBL.EliminarTiposSolicitud(_CatTiposSolicitud);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewTipoSolicitud.DataSource = _CatTiposSolicitudBL.ObtenerTiposSolicitud();
            GridViewTipoSolicitud.DataBind();
        }

    }
    protected void Editar_Click(object sender, EventArgs e)
    {
        if (Catalogo.Value == "Puestos")
        {
            if (txtDescripcionEditar.Text == string.Empty)
            {
                lblMensajeEditar.Visible = true;
                lblMensajeEP.Visible = false;
                lblMensajeER.Visible = false;
                lblMensajeEPR.Visible = false;
                lblMensajeSE.Visible = false;
                upModalEditar.Update();
            }
            else
            {
                _catpuesto = new CatPuestos();
                _catpuesto.iIdPuesto = Convert.ToInt32(ID.Value.ToString());
                _catpuesto.cNombre = txtDescripcionEditar.Text;
                _catpuesneg.modificarPuesto(_catpuesto);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal('hide');", true);
                upModalEditar.Update();
                GridViewPuestos.DataSource = _catpuesneg.list();
                GridViewPuestos.DataBind();
            }
        }

        if (Catalogo.Value == "Periodos")
        {
            if (txtDescPeriodoEdit.Text == string.Empty)
            {
                lblMensajeEditar.Visible = false;
                lblMensajeEP.Visible = true;
                lblMensajeER.Visible = false;
                lblMensajeEPR.Visible = false;
                lblMensajeSE.Visible = false;
                upModalEditar.Update();
            }
            else
            {
                _catperiodo = new CatPeriodos();
                _catperiodo.iIdPeriodo = Convert.ToInt32(ID.Value.ToString());
                _catperiodo.cNombre = txtDescPeriodoEdit.Text;
                _catperiodo.dtFechaInicial = Convert.ToDateTime(txtFechaIniEdit.Text.ToString());
                _catperiodo.dtFechaFinal = Convert.ToDateTime(txtFechaFiEdit.Text.ToString());
                _catperiodo.cPresidenteMunicipal = txtPresidenteEdit.Text;
                _catperneg.modificarPeriodo(_catperiodo);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal('hide');", true);
                upModalEditar.Update();
                GridViewPeriodos.DataSource = _catperneg.list();
                GridViewPeriodos.DataBind();
            }
        }

        if (Catalogo.Value == "Ramas")
        {
            if (txtDescRamasEdit.Text == string.Empty)
            {
                lblMensajeEditar.Visible = false;
                lblMensajeEP.Visible = false;
                lblMensajeER.Visible = true;
                lblMensajeEPR.Visible = false;
                lblMensajeSE.Visible = false;
                upModalEditar.Update();
            }
            else
            {
                _catrama = new CatRamas();
                _catrama.ObjCentrosCostos = new CentrosCostos();
                _catrama.ObjUsuarioGestion = new Usuarios();
                _catrama.iIdRama = Convert.ToInt32(ID.Value.ToString());
                _catrama.cNombre = txtDescRamasEdit.Text;
                _catrama.ObjCentrosCostos.iIdCentroCosto = Convert.ToInt32(dropCambiarDepartamento.SelectedValue.ToString());
                _catrama.ObjUsuarioGestion.iIdUsuarioGestion = (int)Session["IdUser"];
                _catramneg.ModificarRamas(_catrama);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal('hide');", true);
                upModalEditar.Update();
                GridViewRamas.DataSource = _catramneg.ObtenerRamas();
                GridViewRamas.DataBind();
            }
        }

        if (Catalogo.Value == "Procesos")
        {
            if (txtDescProcesoEdit.Text == string.Empty)
            {
                lblMensajeEditar.Visible = false;
                lblMensajeEP.Visible = false;
                lblMensajeER.Visible = false;
                lblMensajeEPR.Visible = true;
                lblMensajeSE.Visible = false;
                upModalEditar.Update();
            }
            else
            {
                _catproceso = new CatProcesos();
                _catproceso.objRamas = new CatRamas();
                _catproceso.objPeriodos = new CatPeriodos();
                _catproceso.ObjUsuarioGestion = new Usuarios();
                _catproceso.iIdProceso = Convert.ToInt32(ID.Value.ToString());
                _catproceso.cNombre = txtDescProcesoEdit.Text;
                _catproceso.objRamas.iIdRama = Convert.ToInt32(dropRamaEd.SelectedValue.ToString());
                _catproceso.objPeriodos.iIdPeriodo = Convert.ToInt32(dropperiodoEd.SelectedValue.ToString());
                _catproceso.ObjUsuarioGestion.iIdUsuario = Convert.ToInt32(dropUsuarioEd.SelectedValue.ToString());
                _catproneg.ModificarProcesos(_catproceso);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal('hide');", true);
                upModalEditar.Update();
                GridViewProcesos.DataSource = _catproneg.ObtenerProcesos();
                GridViewProcesos.DataBind();
            }
        }

        if (Catalogo.Value == "Status")
        {
            if (txtDescStatusEdit.Text == string.Empty)
            {
                lblMensajeEditar.Visible = false;
                lblMensajeEP.Visible = false;
                lblMensajeER.Visible = false;
                lblMensajeEPR.Visible = false;
                lblMensajeSE.Visible = true;
                upModalEditar.Update();
            }
            else
            {
                _catstatu = new CatStatus();
                _catstatu.objProcesos = new CatProcesos();
                _catstatu.ObjUsuarioGestion = new Usuarios();
                _catstatu.iIdStatus = Convert.ToInt32(ID.Value.ToString());
                _catstatu.cNombre = txtDescStatusEdit.Text;
                _catstatu.iOrden = Convert.ToInt32(txtDescOrdenEdit.Text);
                _catstatu.objProcesos.iIdProceso = Convert.ToInt32(dropprocesoEd.SelectedValue.ToString());
                _catstatu.ObjUsuarioGestion.iIdUsuario = Convert.ToInt32(dropUsuarioEd.SelectedValue.ToString());
                _catstaneg.ModificarStatus(_catstatu);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal('hide');", true);
                upModalEditar.Update();
                GridViewStatus.DataSource = _catstaneg.ObtenerStatus();
                GridViewStatus.DataBind();
            }
        }

        /*if (Catalogo.Value == "tipossolicitud")
        {
            if (txtTipoSolicitudNombre.Text == string.Empty)
            {
                lblMensajeNuevo.Visible = false;
                lblMensajeNP.Visible = false;
                lblMensajeNR.Visible = false;
                lblMensajeNPRST.Visible = false;
                upModalNuevo.Update();
            }
            else
            {
                _CatTiposSolicitud = new CatTiposSolicitud();
                _CatTiposSolicitud.ObjRamas = new CatRamas();
                _CatTiposSolicitud.ObjProcesos = new CatProcesos();
                _CatTiposSolicitud.ObjUsuarioGestion = new Usuarios();
                _CatTiposSolicitud.iIdTipoSolicitud = Convert.ToInt32(ID.Value);
                _CatTiposSolicitud.cNombre = txtTipoSolicitudNombre.Text;
                _CatTiposSolicitud.ObjRamas.iIdRama = Convert.ToInt32(dropTipoSolicitudRama.SelectedValue.ToString());
                _CatTiposSolicitud.ObjProcesos.iIdProceso = Convert.ToInt32(dropTipoSolicitudProceso.SelectedValue.ToString());
                _CatTiposSolicitud.ObjUsuarioGestion.iIdUsuario = Convert.ToInt32(Session["IdUser"]);
                _CatTiposSolicitudBL.ModificarTiposSolicitud(_CatTiposSolicitud);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewTipoSolicitud.DataSource = _CatTiposSolicitudBL.ObtenerTiposSolicitud();
                GridViewTipoSolicitud.DataBind();
                }
            }
            */
    }

    protected void dropUserDireccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadComboCentrosCostos("Direccion");
        upModalNuevo.Update();
    }
    protected void dropUserSubdireccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadComboCentrosCostos("Seleccion");
        upModalNuevo.Update();
    }
    protected void dropCambiarDireccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadComboCambiarCentrosCostos("Direccion");
        upModalEditar.Update();
    }
    protected void dropCambiarSubdireccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadComboCambiarCentrosCostos("Seleccion");
        upModalEditar.Update();
    }
}