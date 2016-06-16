﻿<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta al iniciarse la aplicación
        RegisterRoutes(RouteTable.Routes);
    }
    void Application_End(object sender, EventArgs e) 
    {
        //  Código que se ejecuta al cerrarse la aplicación
    }
    void Application_Error(object sender, EventArgs e) 
    { 
        // Código que se ejecuta cuando se produce un error sin procesar
    }
    void Session_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta al iniciarse una nueva sesión
    }
    void Session_End(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: el evento Session_End se produce solamente con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer
        // o SQLServer, el evento no se produce.
    }
    void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("LoginApp", "Login", "~/Acceso/Login.aspx");
        routes.MapPageRoute("LogoutApp", "logout", "~/Acceso/Logout.aspx");
        routes.MapPageRoute("IndexApp", "inicio", "~/Inicio.aspx");
        routes.MapPageRoute("CatalogosApp", "admin/catalogos", "~/Administracion/Catalogos.aspx");
        routes.MapPageRoute("UsuariosApp", "admin/usuarios", "~/Administracion/Usuarios.aspx");
        routes.MapPageRoute("BeneficiariosApp", "admin/beneficiarios", "~/Administracion/Beneficiarios.aspx");
        routes.MapPageRoute("SolicitudeslistApp", "solicitudes/list", "~/Solicitudes/Historial.aspx");
        routes.MapPageRoute("SolicitudesNuevoApp", "solicitudes/nuevo", "~/Solicitudes/NuevaSolicitud.aspx");
        routes.MapPageRoute("SolicitudesAltaBenefApp", "solicitudes/altabeneficiario", "~/Solicitudes/AltaBeneficiario.aspx");
        routes.MapPageRoute("PerfilesApp", "admin/perfiles", "~/Administracion/Perfiles.aspx");
        routes.MapPageRoute("VistaSesionApp", "minutas/detalles/{idsesion}", "~/Minutas/VistaSesion.aspx");
    }
</script>
