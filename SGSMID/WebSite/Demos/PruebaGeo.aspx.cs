using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSistema;
using ESistema.Geo;
using System.Dynamic;

public partial class Demos_PruebaGeo : System.Web.UI.Page
{
    string Sesion;
    GeoBL _geobl = new GeoBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnCerrarSesion.Enabled = false;
            comboBoxAccionInteraccionMapa.Enabled = false;
            txtArgumento.Enabled = false;
            btnInteraccionMapa.Enabled = false;
        }
    }
    protected void btnIniciarSesion_Click(object sender, EventArgs e)
    {
        var response = _geobl.InicioSesion("geodesarrollo@merida.gob.mx", "desarrollo", "a24d7ad9028ec23449f87dc44985c35f");
        Auhthorization.Value = response.Result;
        this.myIframe.Attributes.Add("src", "http://172.16.165.125:8080/geoportal/integracion?authorization=" + Auhthorization.Value);
       
        lblSesion.Text = "Sesion: " + Auhthorization.Value;
        btnIniciarSesion.Enabled = false;
        btnCerrarSesion.Enabled = true;
        //webBrowser1.Visible = true;
        //btnLimpiarUbicacion.Enabled = true;
        //btnBusquedaInteraccion.Enabled = true;
        //btnBusqueda.Enabled = true;
        btnInteraccionMapa.Enabled = true;
        //btnConsultaUbicacion.Enabled = true;
        //btnGuardarActualizarUbicacion.Enabled = true;
        //txtBusquedaInteraccion.Enabled = true;
        //txtBusqueda.Enabled = true;
        comboBoxAccionInteraccionMapa.Enabled = true;
        txtArgumento.Enabled = true;
        //txtClave.Enabled = true;
        //txtFolio.Enabled = true;
        //txtValor1.Enabled = true;
        //txtValor2.Enabled = true;
    }
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        _geobl.CierreSesion(Auhthorization.Value);
        btnIniciarSesion.Enabled = true;
        this.myIframe.Attributes.Add("src", "");
        lblSesion.Text = "";
        btnCerrarSesion.Enabled = false;
        //btnLimpiarUbicacion.Enabled = false;
        //btnBusquedaInteraccion.Enabled = false;
        //btnBusqueda.Enabled = false;
         btnInteraccionMapa.Enabled = false;
        //btnConsultaUbicacion.Enabled = false;
        //btnGuardarActualizarUbicacion.Enabled = false;
        //txtBusquedaInteraccion.Enabled = false;
        //txtBusqueda.Enabled = false;
         comboBoxAccionInteraccionMapa.Enabled = false;
        //txtArgumento.Enabled = false;
        //txtClave.Enabled = false;
        //txtFolio.Enabled = false;
        //txtValor1.Enabled = false;
        //txtValor2.Enabled = false;
        //comboBoxAccionInteraccionMapa.SelectedIndex = 0;
    }
    private void Principal_Load(object sender, EventArgs e)
    {
       
       
        //btnLimpiarUbicacion.Enabled = false;
        //btnBusquedaInteraccion.Enabled = false;
        //btnBusqueda.Enabled = false;
        
        //btnConsultaUbicacion.Enabled = false;
        //btnGuardarActualizarUbicacion.Enabled = false;
        //txtBusquedaInteraccion.Enabled = false;
        //txtBusqueda.Enabled = false;
      
       
        //txtClave.Enabled = false;
        //txtFolio.Enabled = false;
        //txtValor1.Enabled = false;
        //txtValor2.Enabled = false;
        //comboBoxAccionInteraccionMapa.SelectedIndex = 0;
    }

    private void btnBusquedaInteraccion_Click(object sender, EventArgs e)
    {
        ResponseJsonGeo objresponseJson = new ResponseJsonGeo();
        var responseJson = _geobl.BusquedaInteraccion("", Auhthorization.Value);
        objresponseJson = responseJson.Result;
        foreach (Feature f in objresponseJson.features)
        {
            Console.WriteLine("Nombre: " + f.properties.nombre);
        }
    }
    private void btnLimpiarUbicacion_Click(object sender, EventArgs e)
    {
        _geobl.LimpiarUbicacion(Auhthorization.Value);
    }
    protected void btnInteraccionMapa_Click(object sender, EventArgs e)
    {

        _geobl.InteraccionesMapa(comboBoxAccionInteraccionMapa.Text, txtArgumento.Text, Auhthorization.Value);
    }
    private void btnConsultaUbicacion_Click(object sender, EventArgs e)
    {
        //_geobl.ConsultaUbicacion(txtClave.Text, txtFolio.Text, Sesion);
    }
    private void btnBusqueda_Click(object sender, EventArgs e)
    {
        ResponseJsonGeo objresponseJson = new ResponseJsonGeo();
        //var responseJson = _geobl.Busqueda(txtBusqueda.Text, Sesion);
        //objresponseJson = responseJson.Result;
    }
    private void btnGuardarActualizarUbicacion_Click(object sender, EventArgs e)
    {
        dynamic dynamicJson = new ExpandoObject();
        //dynamicJson.nombre = txtValor1.Text;
        //dynamicJson.valor = txtValor2.Text;
        //GuardarActualizarUbicacion(txtClave.Text, txtFolio.Text, Sesion, dynamicJson);
    }
}