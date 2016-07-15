﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Administracion_Usuarios" MasterPageFile="~/Site.master" %>

<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contInicio">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Usuarios               
                <asp:UpdatePanel ID="ValoresPanel" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="ID" runat="server" />
                        <asp:HiddenField ID="Operacion" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </h1>
            <ol class="breadcrumb">
                <li><a href="../Inicio.aspx"><i class="fa fa-home"></i>Inicio</a></li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">&nbsp;</h3>
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtNombreCompletoEmail" CssClass="form-control pull-right" Width="200px" />
                                    <div class="input-group-btn">
                                        <asp:DropDownList runat="server" ID="dropFiltroPerfil" CssClass="btn btn-default dropdown-toggle"></asp:DropDownList>
                                        <asp:DropDownList runat="server" ID="dropFiltroPuesto" CssClass="btn btn-default dropdown-toggle"></asp:DropDownList>
                                        <asp:LinkButton ID="BuscarUsuario"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarUsuario_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoUsuario"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoUsuario_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridUsuarios" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewUsuarios" CssClass="table table-bordered" runat="server" DataKeyNames="iIdUsuario" AutoGenerateColumns="false" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Usuario">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="idoculto" runat="server" Value='<%# Bind("objUsuario.iIdUsuario") %>' />
                                                    <asp:Label ID="cNombreUsuario" runat="server" Text='<%# Bind("objUsuario.cNombreUsuario") %>'><%# Eval("objUsuario.cNombreUsuario") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="cNombre" runat="server" Value='<%# Bind("cNombre") %>' />
                                                    <asp:HiddenField ID="cApellidoPaterno" runat="server" Value='<%# Bind("cApellidoPaterno") %>' />
                                                    <asp:HiddenField ID="cApellidoMaterno" runat="server" Value='<%# Bind("cApellidoMaterno") %>' />
                                                    <asp:Label ID="cNombreCompleto" runat="server"><%# Eval("cNombreCompleto") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Perfil">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdPerfil" runat="server" Value='<%# Bind("objUsuario.objPerfil.iIdPerfil") %>' />
                                                    <asp:Label runat="server"><%# Eval("objUsuario.objPerfil.cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Puesto">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdPuesto" runat="server" Value='<%# Bind("objPuesto.iIdPuesto") %>' />
                                                    <asp:HiddenField ID="iIdCentroCosto" runat="server" Value='<%# Bind("iIdCentroCosto") %>' />
                                                       <asp:HiddenField ID="iNumeroEmpleado" runat="server" Value='<%# Bind("iNumeroEmpleado") %>' />
                                                    <asp:Label runat="server"><%# Eval("objPuesto.cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Alta">
                                                <ItemTemplate>
                                                    <asp:Label runat="server"><%# Eval("objUsuario.dtFechaAlta") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="150px">
                                                <ItemTemplate>

                                                    <asp:LinkButton ID="btnEditarUsuario"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarUsuario"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
  &nbsp; <span aria-hidden="true" class="fa fa-pencil"></span> &nbsp;  
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnCambiarPassword"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="CambiarPassword"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
  &nbsp;  <span aria-hidden="true" class="fa fa-lock"></span>  &nbsp;
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarUsuario"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarUsuario"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
  &nbsp;  <span aria-hidden="true" class="fa fa-trash"></span> &nbsp;
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarUsuario" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarPassword" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoUsuario" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarUsuario" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <!-- Bootstrap Modal Dialog Password -->
                <div class="modal fade" id="ModalPassword" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModalPassword" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitlePassword" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtUserPasswordCambio" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>

                                            <div class="has-error">
                                                <asp:Label CssClass="control-label" TextMode="Password" ID="lblUserPasswordCambio" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Campo Obligatorio
                                                </asp:Label>
                                            </div>
                                            <br />
                                            <asp:TextBox ID="txtUserPasswordCambioConfirma" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                            <div class="has-error">
                                                <asp:Label CssClass="control-label" ID="lblUserPasswordCambioConfirma" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Las Contraseñas no coinciden</asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button CssClass="btn btn-primary" ID="GuardarPassword" runat="server" Text="Aceptar" OnClick="Password_Click" />
                                        <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- Bootstrap Modal Dialog Delete -->
                <div class="modal fade" id="ModalEliminar" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModalEliminar" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitleEliminar" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label ID="lblModalBodyEliminar" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button CssClass="btn btn-primary" ID="GuardarEliminacion" runat="server" Text="Aceptar" OnClick="Eliminar_Click" />
                                        <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- Bootstrap Modal Dialog OperUsuario -->
                <div class="modal fade" id="ModalOperUsuario" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModalOperUsuario" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitleNuevo" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-horizontal">
                                            
                                           
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">Nombre:</label><div class="col-sm-10">
                                                    <asp:TextBox ID="txtUserNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <div class="has-error">
                                                        <asp:Label CssClass="control-label" ID="lblMensajeUserNombre" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Campo Obligatorio
                                                        </asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">Apellidos:</label><div class="col-sm-5">
                                                    <asp:TextBox ID="txtUserApellidoPaterno" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <div class="has-error">
                                                        <asp:Label CssClass="control-label" ID="lblMensajeUserApellidoPaterno" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Campo Obligatorio
                                                        </asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-sm-5">
                                                    <asp:TextBox ID="txtUserApellidoMaterno" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <div class="has-error">
                                                        <asp:Label CssClass="control-label" ID="lblMensajeUserApellidoMaterno" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Campo Obligatorio
                                                        </asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="form-group">

                                                <label class="col-sm-2 control-label">Perfil: </label>
                                                  <div class="col-sm-5">
                                                    <asp:DropDownList runat="server" ID="dropUserPerfil" CssClass="form-control"></asp:DropDownList></div>
                                             <div class="col-sm-3">
                                                   <label class="control-label">Nro. de Empleado: </label>
                                                 </div>

                                            <div class="col-sm-2">
                                                    <asp:TextBox ID="txtNroEmpleado" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <div class="has-error">
                                                        <asp:Label CssClass="control-label" ID="lblMensajeNroEmpleado" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Campo Obligatorio
                                                        </asp:Label>
                                                    </div>
                                                </div>
                                              
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">Dirección: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropUserDireccion" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropUserDireccion_SelectedIndexChanged"></asp:DropDownList></div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">Subd: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropUserSubdireccion"  AutoPostBack="True" OnSelectedIndexChanged="dropUserSubdireccion_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList></div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">Depto: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropUserDepartamento" CssClass="form-control"></asp:DropDownList></div>
                                            </div>
                                             <div class="form-group">
                                                <label class="col-sm-2 control-label">Puesto: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropUserPuesto" CssClass="form-control"></asp:DropDownList></div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">Email: </label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <div class="has-error">
                                                        <asp:Label CssClass="control-label" ID="lblMensajeUserName" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Campo Obligatorio
                                                        </asp:Label>
                                                        <asp:Label CssClass="control-label" ID="lblMensajeUserNameCorreo" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Debe ingresar un correo electronico valido 
                                                        </asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label CssClass="col-sm-2 control-label" ID="lblpasswordtitle" runat="server">Contraseña: </asp:Label>
                                                <div class="col-sm-5">
                                                    <asp:TextBox ID="txtUserPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <div class="has-error">
                                                        <asp:Label CssClass="control-label" TextMode="Password" ID="lblMensajeUserPass" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Campo Obligatorio
                                                        </asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-sm-5">
                                                    <asp:TextBox ID="txtUserPasswordConfirma" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <div class="has-error">
                                                        <asp:Label CssClass="control-label" ID="lblMensajeUserPassConfirma" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Las Contraseñas no coinciden</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                          </div>
                                        </div>
                                            <div class="modal-footer">
                                                <asp:Button CssClass="btn btn-primary" ID="GuardarUsuario" runat="server" Text="Guardar" OnClick="Nuevo_Click" />
                                                <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                                            </div>
                                        </div>
                                        
                            </ContentTemplate>
                             <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropUserDireccion" EventName="selectedindexchanged" />
                                    <asp:AsyncPostBackTrigger ControlID="dropUserSubdireccion" EventName="selectedindexchanged" />
                             </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
