<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PruebaGeo.aspx.cs" Inherits="Demos_PruebaGeo" Async="true" %>

<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contInicio">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>GeoReferenciación             
                <asp:UpdatePanel ID="ValoresPanel" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="Auhthorization" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </h1>
            <ol class="breadcrumb">
                <li><a href="../Inicio.aspx"><i class="fa fa-home"></i>Inicio</a></li>
            </ol>
        </section>
        <section class="content">
           <div class="row">
                  <div class="form-group">
            <div class="col-sm-12">
                     <asp:Button ID="btnIniciarSesion" text="Iniciar Sesion" CssClass="btn btn-primary" runat="server" OnClick="btnIniciarSesion_Click" />
                     <asp:Button ID="btnCerrarSesion" text="Cerrar Sesion" CssClass="btn btn-danger" runat="server" OnClick="btnCerrarSesion_Click" />
                      
                <br />
             <br />
             </div>
                      </div>
                     
                
                      <div class="form-group">
                          <div class="col-sm-6">
                      <asp:UpdatePanel ID="UpdateBrowser" UpdateMode="Always" runat="server">
                            <ContentTemplate>
                               
                              
                                      <label class="col-sm-12 control-label">Acción: </label>
                                        
                                       
                       <div class="col-sm-12">
                          <asp:DropDownList ID="comboBoxAccionInteraccionMapa" CssClass="form-control" runat="server">
                          <asp:ListItem>buscar-geometria</asp:ListItem>
                          <asp:ListItem>zoom-geometria</asp:ListItem>
                          <asp:ListItem>remover-geometria</asp:ListItem>
                          <asp:ListItem>reporte-ayuntatel</asp:ListItem>
                          <asp:ListItem>seleccionar-limpiar-geometria</asp:ListItem>
                      </asp:DropDownList>
                     </div>
                                     
                    <br />
                                       <label class="col-sm-12 control-label">Argumento: </label>
                                      <div class="col-sm-12">
                   <asp:TextBox ID="txtArgumento" CssClass="form-control" runat="server"></asp:TextBox>
                                          
                                      <br />
                                          </div>
                  
                                      <div class="col-sm-12">
                   <asp:Button ID="btnInteraccionMapa" CssClass="btn btn-primary" text="Interaccion Mapa" runat="server" OnClick="btnInteraccionMapa_Click"/>
                                          </div>
                   <br />
                    <br />
                               
                
                                   
                       </ContentTemplate>
                         
                   <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="btnInteraccionMapa" EventName="Click" />
                       </Triggers>
              
                          </asp:UpdatePanel>
                              
                     </div></div>
                 
                   <div class="form-group">
                        <div class="col-sm-6" style="height:400px">
                     <div style="padding-bottom:100%" class="embed-responsive embed-responsive-16by9">
           <iframe name="myIframe" class="embed-responsive-item" style="height:400px" id="myIframe" border="1px" runat="server"></iframe>
          </div>   
                               
                         </div> 
                      <div class="col-sm-6">
                          <asp:label class="col-sm-6 control-label" id="lblSesion" runat="server"></asp:label>
                      </div>
                        </div>
              
               </div>
                 
            </section>
        </div>
    </asp:Content>