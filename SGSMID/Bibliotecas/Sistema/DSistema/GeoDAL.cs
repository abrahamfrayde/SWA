using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using ESistema.Geo;

namespace DSistema
{
    public class GeoDAL
    {
        string URL = "http://172.16.165.125:8080/webservices";
        string URLPortal = "http://172.16.165.125:8080/geoportal/control";
        public async Task<string> InicioSesion(string usuario, string clave, string aplicacion)
        {
            Uri requestUri = new Uri(URL + "/sesiones");
            dynamic dynamicJson = new ExpandoObject();
            dynamicJson.usuario = usuario;
            dynamicJson.clave = clave;
            dynamicJson.aplicacion = aplicacion;
            string json = "";
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicJson);
            var objClint = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage respon = await objClint.PostAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "Application/json")).ConfigureAwait(continueOnCapturedContext: false);
            //MessageBox.Show("Respuesta: " + respon.ReasonPhrase);
            string Authoraization = respon.Headers.GetValues("Authorization").First();
            return Authoraization;
        }
        public async void CierreSesion(string Authorization)
        {
            Uri requestUri = new Uri(URL + "/sesiones/" + Authorization);
            var objClint = new System.Net.Http.HttpClient();
            objClint.DefaultRequestHeaders.Add("Authorization", Authorization);
            System.Net.Http.HttpResponseMessage respon = await objClint.DeleteAsync(requestUri).ConfigureAwait(continueOnCapturedContext: false);
            string responJsonText = await respon.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
            //MessageBox.Show("Respuesta: " + respon.ReasonPhrase);
        }
        public async Task<ResponseJsonGeo> BusquedaInteraccion(string criterio, string Authorization)
        {
            Uri requestUri = new Uri(URL + "/buscar/geometria/" + criterio); //replace your Url  
            var objClint = new System.Net.Http.HttpClient();
            objClint.DefaultRequestHeaders.Add("Authorization", Authorization);
            System.Net.Http.HttpResponseMessage respon = await objClint.GetAsync(requestUri).ConfigureAwait(continueOnCapturedContext: false);
            string responJsonText = await respon.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
            //MessageBox.Show("Respuesta: " + respon.ReasonPhrase);
            //MessageBox.Show(responJsonText);
            ResponseJsonGeo objresponseJson = new ResponseJsonGeo();
            objresponseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseJsonGeo>(responJsonText.ToString());
            return objresponseJson;
        }
        public async Task<ResponseJsonGeo> Busqueda(string criterio, string Authorization)
        {
            Uri requestUri = new Uri(URL + "/buscar/detalles/" + criterio); //replace your Url  
            var objClint = new System.Net.Http.HttpClient();
            objClint.DefaultRequestHeaders.Add("Authorization", Authorization);
            System.Net.Http.HttpResponseMessage respon = await objClint.GetAsync(requestUri).ConfigureAwait(continueOnCapturedContext: false);
            string responJsonText = await respon.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
            //MessageBox.Show(respon.ReasonPhrase);
            //MessageBox.Show(responJsonText);
            ResponseJsonGeo objresponseJson = new ResponseJsonGeo();
            objresponseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseJsonGeo>(responJsonText.ToString());
            return objresponseJson;
        }
        public async void InteraccionesMapa(string accion, string argumento, string Authorization)
        {
            Uri requestUri = new Uri(URLPortal + "/" + Authorization);
            dynamic dynamicJson = new ExpandoObject();
            dynamicJson.accion = accion;
            dynamicJson.argumento = argumento;
            string json = "";
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicJson);
            var objClint = new System.Net.Http.HttpClient();
            objClint.DefaultRequestHeaders.Add("Authorization", Authorization);
            System.Net.Http.HttpResponseMessage respon = await objClint.PostAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "Application/json")).ConfigureAwait(continueOnCapturedContext: false);
            //MessageBox.Show(respon.ReasonPhrase);
        }
        public async void LimpiarUbicacion(string Authorization)
        {
            Uri requestUri = new Uri(URLPortal + "/" + Authorization);
            dynamic dynamicJson = new ExpandoObject();
            dynamicJson.accion = "limpiar-ubicacion";
            dynamicJson.argumento = "";
            string json = "";
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicJson);
            var objClint = new System.Net.Http.HttpClient();
            objClint.DefaultRequestHeaders.Add("Authorization", Authorization);
            System.Net.Http.HttpResponseMessage respon = await objClint.PostAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "Application/json")).ConfigureAwait(continueOnCapturedContext: false);
            //MessageBox.Show(respon.ReasonPhrase);
        }
        public async void ConsultaUbicacion(string clave, string folio, string Authorization)
        {
            Uri requestUri = new Uri(URL + "/integracion/" + clave + "/" + folio); //replace your Url  
            var objClint = new System.Net.Http.HttpClient();
            objClint.DefaultRequestHeaders.Add("Authorization", Authorization);
            System.Net.Http.HttpResponseMessage respon = await objClint.GetAsync(requestUri).ConfigureAwait(continueOnCapturedContext: false);
            string responJsonText = await respon.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
            //MessageBox.Show(respon.ReasonPhrase);
            //MessageBox.Show(responJsonText);
            Uri requestUri2 = new Uri("http://172.16.165.125:8080/geoportal" + "/integracion/" + clave + "/" + folio + "?authorization=" + Authorization); //replace your Url  
            //webBrowser1.Url = requestUri2;
        }
        public async void GuardarActualizarUbicacion(string clave, string folio, string Authorization, dynamic dynamicJson)
        {
            Uri requestUri = new Uri(URL + "/integracion/" + clave + "/" + folio);
            string json = "";
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicJson);
            var objClint = new System.Net.Http.HttpClient();
            objClint.DefaultRequestHeaders.Add("Authorization", Authorization);
            System.Net.Http.HttpResponseMessage respon = await objClint.PostAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "Application/json")).ConfigureAwait(continueOnCapturedContext: false);
            //MessageBox.Show(respon.ReasonPhrase);
        }
    }
}
