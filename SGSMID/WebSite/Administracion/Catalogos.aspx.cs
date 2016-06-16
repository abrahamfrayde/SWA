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
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ValidarSesion.sesionactiva())
            Response.Redirect("~/Default.aspx");
        //Departamentos
        if(!Page.IsPostBack)
        {
            
            GridViewPuestos.DataSource = _catpuesneg.list();
            GridViewPuestos.DataBind();
            txtDescripcionNuevo.Attributes.Add("placeholder", "Nombre");
            txtDescripcionEditar.Attributes.Add("placeholder", "Nombre");

        }
     }
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
        if (e.CommandName == "EditarPuesto")
        {
            lblMensajeEditar.Visible = false;
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
       
    }

    protected void Nuevo_Click(object sender, EventArgs e)
    {
        if (txtDescripcionNuevo.Text == String.Empty)
        {
            lblMensajeNuevo.Visible = true;
            upModalNuevo.Update();
        }
        else
        {
           
            if (Catalogo.Value == "Puestos")
            {
                _catpuesto = new CatPuestos();
                _catpuesto.descripcion = txtDescripcionNuevo.Text;
                _catpuesneg.insertarPuesto(_catpuesto);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal('hide');", true);
                upModalNuevo.Update();
                GridViewPuestos.DataSource = _catpuesneg.list();
                GridViewPuestos.DataBind();
            }
           
        }
    }
   
    protected void BuscarPuesto_Click(object sender, EventArgs e)
    {
        GridViewPuestos.DataSource = _catpuesneg.list(txtBuscarPuesto.Text);
        GridViewPuestos.DataBind();
    }
    
    protected void NuevoPuesto_Click(object sender, EventArgs e)
    {
        lblMensajeNuevo.Visible = false;
        lblModalTitleNuevo.Text = "Nuevo Puesto";
        txtDescripcionNuevo.Text = string.Empty;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalNuevo", "$('#ModalNuevo').modal();", true);
        upModalNuevo.Update();
        Catalogo.Value = "Puestos";
    }
   
    protected void Eliminar_Click(object sender,EventArgs e)
    {
       
        if (Catalogo.Value == "Puestos")
        {
            _catpuesto = new CatPuestos();
            _catpuesto.idpuesto = Convert.ToInt32(ID.Value.ToString());
            _catpuesneg.eliminarPuesto(_catpuesto);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal('hide');", true);
            upModalEliminar.Update();
            GridViewPuestos.DataSource = _catpuesneg.list();
            GridViewPuestos.DataBind();
        }
     
    }
    protected void Editar_Click(object sender, EventArgs e)
    {
        if (txtDescripcionEditar.Text == String.Empty)
        {
            lblMensajeEditar.Visible = true;
            upModalEditar.Update();
        }
        else
        {
            
            if (Catalogo.Value == "Puestos")
            {
                _catpuesto = new CatPuestos();
                _catpuesto.idpuesto = Convert.ToInt32(ID.Value.ToString());
                _catpuesto.descripcion = txtDescripcionEditar.Text;
                _catpuesneg.modificarPuesto(_catpuesto);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEditar", "$('#ModalEditar').modal('hide');", true);
                upModalEditar.Update();
                GridViewPuestos.DataSource = _catpuesneg.list();
                GridViewPuestos.DataBind();
            }
        
        }
    }
}