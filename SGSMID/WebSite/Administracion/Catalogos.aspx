<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Catalogos.aspx.cs" Inherits="Administracion_Catalogos" MasterPageFile="~/Site.master" %>

<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contInicio">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Catálogos               
                <asp:UpdatePanel ID="ValoresPanel" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="ID" runat="server" />
                        <asp:HiddenField ID="Catalogo" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </h1>
            <ol class="breadcrumb">
                <li><a href="../Inicio.aspx"><i class="fa fa-home"></i>Inicio</a></li>
            </ol>
        </section>
        <section class="content">
               
                <div class="col-md-12">
                    <!-- Custom Tabs -->
          <div class="nav-tabs-custom">
            <ul class="nav nav-pills nav-justified">
              <li class="active"><a href="#tab_1" data-toggle="tab"><span class="glyphicon glyphicon-asterisk"></span>Puestos</a></li>
              <li><a class="icon" href="#tab_2" data-toggle="tab">Periodos</a></li>
              <li><a class="icon" href="#tab_3" data-toggle="tab">Ramas</a></li>
              <li><a class="icon" href="#tab_4" data-toggle="tab">Procesos</a></li>
              <li><a class="icon" href="#tab_5" data-toggle="tab">Status</a></li>
              <li><a class="icon" href="#tab_6" data-toggle="tab">Status Orden</a></li>
              <li><a class="icon" href="#tab_7" data-toggle="tab">Tipo Solicitud</a></li>
            </ul>
            <div class="tab-content">
                <!-- tab CATALOGO DE PUESTOS -->
                <div class="tab-pane active" id="tab_1">
                  <!--agregando formulario-->
                    <div class="table-responsive">
                     <div class="form-group">
                        <div class="box-header with-border">
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtBuscarPuesto" CssClass="form-control pull-right" placeholder="Buscar" />
                                          <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarPuesto"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarPuesto_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoPuesto"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoPuesto_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                      </div>
                       
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridPuestos" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewPuestos" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="iIdpuesto" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="cNombre" HeaderText="Nombre" Visible="true" />
                                            <asp:TemplateField HeaderText="Fecha Alta">
                                                <ItemTemplate>
                                                    <asp:Label ID="dtFechaRegistro" runat="server"><%# Eval("dtFechaRegistro", "{0:dd/MM/yyyy}") %></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>   
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarPuesto"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarPuesto"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-pencil"></span> Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarPuesto"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarPuesto"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-trash"></span> Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEdicion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoPuesto" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarPuesto" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                <!--final formulario-->
                </div>
               <!-- /.tab-pane FIN CATALOGO PUESTOS -->

                <!-- tab CATALOGO DE PERIODOS -->
                <div class="tab-pane" id="tab_2">
                    <!--agregando formulario-->
                    <div class="table-responsive">
                        <div class="form-group">
                        <div class="box-header with-border">
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtBuscarPeriodo" CssClass="form-control pull-right" placeholder="Buscar" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarPeriodo"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarPeriodo_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoPeriodo"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoPeriodo_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                       </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridPeriodos" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewPeriodos" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="iIdperiodo" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="cNombre" HeaderText="Nombre" Visible="true" />
                                            <asp:TemplateField HeaderText="Fecha Inicial">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="dtFechaInicial" runat="server" Value='<%# Bind("dtFechaInicial") %>' />
                                                    <asp:Label runat="server"><%# Eval("dtFechaInicial", "{0:dd/MM/yyyy}") %></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>   
                                            <asp:TemplateField HeaderText="Fecha Final">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="dtFechaFinal" runat="server" Value='<%# Bind("dtFechaFinal") %>' />
                                                    <asp:Label runat="server"><%# Eval("dtFechaFinal", "{0:dd/MM/yyyy}") %></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>   
                                            <asp:BoundField DataField="cPresidenteMunicipal" HeaderText="Presidente" Visible="true" />
                                            <asp:TemplateField HeaderText="Fecha Alta">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdUsarioGestion" runat="server" Value='<%# Bind("iIdUsuario") %>' />
                                                    <asp:Label ID="dtFechaRegistro" runat="server"><%# Eval("dtFechaRegistro", "{0:dd/MM/yyyy}") %></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                      
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarPeriodo"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarPeriodo"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-pencil"></span> Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarPeriodo"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarPeriodo"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-trash"></span> Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEdicion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoPeriodo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarPeriodo" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                <!--final formulario-->
                    </div>
                <!-- /.tab-pane FIN CATALOGO PERIODOS -->

                <!-- tab CATALOGO DE RAMAS -->
                <div class="tab-pane" id="tab_3">
                     <!--agregando formulario-->
                    <div class="table-responsive">
                        <div class="form-group">
                        <div class="box-header with-border">
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtBuscarRama" CssClass="form-control pull-right" placeholder="Buscar" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarRama"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarRama_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevaRama"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevaRama_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                     </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridRamas" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewRamas" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="iIdRama" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="cNombre" HeaderText="Nombre" Visible="true" />
                                            <asp:TemplateField HeaderText="Fecha Alta">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdCentroCosto" runat="server" Value='<%# Bind("ObjCentrosCostos.iIdCentroCosto") %>' /> 
                                                    <asp:HiddenField ID="iIdUsuarioGestion" runat="server" Value='<%# Bind("ObjUsuarioGestion.iIdUsuarioGestion") %>' />
                                                    <asp:Label ID="dtFechaRegistro" runat="server"><%# Eval("dtFechaRegistro", "{0:dd/MM/yyyy}") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                      
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarRama"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarRama"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-pencil"></span> Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarRama"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarRama"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-trash"></span> Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEdicion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevaRama" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarRama" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                <!--final formulario-->
                    </div>
                <!-- /.tab-pane FIN CATALOGO RAMAS -->

                <!-- tab CATALOGO DE PROCESOS -->
                <div class="tab-pane" id="tab_4">
                     <!--agregando formulario-->
                    <div class="table-responsive">
                        <div class="form-group">
                        <div class="box-header with-border">
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtBuscarProceso" CssClass="form-control pull-right" placeholder="Buscar" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarProceso"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarProceso_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoProceso"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoProceso_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridProcesos" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewProcesos" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="iIdProceso" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                             <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                       <asp:Label ID="cNombre" runat="server" Text='<%# Bind("cNombre") %>'><%# Eval("cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Periodo">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdPeriodo" runat="server" Value='<%# Bind("objPeriodos.iIdPeriodo") %>' />
                                                    <asp:Label runat="server"><%# Eval("objPeriodos.cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Rama">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdRama" runat="server" Value='<%# Bind("objRamas.iIdRama") %>' />
                                                    <asp:Label runat="server"><%# Eval("objRamas.cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Usuario">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdUsuarioGestion" runat="server" Value='<%# Bind("ObjUsuarioGestion.iIdUsuario") %>' />
                                                    <asp:Label runat="server"><%# Eval("ObjUsuarioGestion.cNombreUsuario") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Fecha Alta">
                                                <ItemTemplate>
                                                    <asp:Label ID="dtFechaRegistro" runat="server" Text='<%# Eval("dtFechaRegistro", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarProceso"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarProceso"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-pencil"></span> Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarProceso"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarProceso"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-trash"></span> Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEdicion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoProceso" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarProceso" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                <!--final formulario-->
                    </div>
                <!-- /.tab-pane FIN CATALOGO PROCESOS -->

                <!-- tab CATALOGO DE STATUS -->
                <div class="tab-pane" id="tab_5">
                                         <!--agregando formulario-->
                    <div class="table-responsive">
                        <div class="form-group">
                        <div class="box-header with-border">
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtBuscarStatus" CssClass="form-control pull-right" placeholder="Buscar" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarStatus"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarStatus_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoStatus"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoStatus_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridStatus" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewStatus" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="iIdStatus" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                             <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                       <asp:Label ID="cNombre" runat="server" Text='<%# Bind("cNombre") %>'><%# Eval("cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Proceso">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdProceso" runat="server" Value='<%# Bind("ObjProcesos.iIdProceso") %>' />
                                                    <asp:Label runat="server"><%# Eval("ObjProcesos.cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               
                                            <asp:TemplateField HeaderText="Orden">
                                                <ItemTemplate>
                                                       <asp:Label ID="iOrden" runat="server" Text='<%# Bind("iOrden") %>'><%# Eval("iOrden") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Usuario">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdUsuarioGestion" runat="server" Value='<%# Bind("ObjUsuarioGestion.iIdUsuario") %>' />
                                                    <asp:Label runat="server"><%# Eval("ObjUsuarioGestion.cNombreUsuario") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Fecha Alta">
                                                <ItemTemplate>
                                                    <asp:Label ID="dtFechaRegistro" runat="server" Text='<%# Eval("dtFechaRegistro", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarStatus"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarStatus"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-pencil"></span> Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarStatus"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarStatus"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-trash"></span> Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEdicion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoStatus" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarStatus" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                <!--final formulario-->
                    </div>
                <!-- /.tab-pane FIN CATALOGO STATUS -->
                    
                <!-- tab CATALOGO DE STATUS ORDEN -->
                <div class="tab-pane" id="tab_6">
                   <!--agregando formulario-->
                    <div class="table-responsive">
                        <div class="form-group">
                        <div class="box-header with-border">
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtBuscarStatusOrden" CssClass="form-control pull-right" placeholder="Buscar" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton ID="BuscarStatusOrden"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarStatusOrden_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoStatusOrden"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoStatusOrden_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                      </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridStatusOrden" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewStatusOrden" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="iIdStatusOrden" OnRowCommand="GridView_RowCommand">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Proceso">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdProceso" runat="server" Value='<%# Bind("objProcesos.iIdProceso") %>' />
                                                    <asp:Label runat="server"><%# Eval("objProcesos.cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               
                                            <asp:TemplateField HeaderText="Estatus">
                                                <ItemTemplate>
                                                       <asp:HiddenField ID="iIdStatus" runat="server" Value='<%# Bind("objStatus.iIdStatus") %>' />
                                                       <asp:Label runat="server"><%# Eval("objStatus.cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                           <asp:TemplateField HeaderText="Estatus Destino">
                                                <ItemTemplate>
                                                       <asp:HiddenField ID="iIdStatusDestino" runat="server" Value='<%# Bind("objStatusDestino.iIdStatus") %>' />
                                                       <asp:Label runat="server"><%# Eval("objStatusDestino.cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField> 

                                            <asp:TemplateField HeaderText="Usuario">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdUsuarioGestion" runat="server" Value='<%# Bind("ObjUsuarioGestion.iIdUsuario") %>' />
                                                    <asp:Label runat="server"><%# Eval("ObjUsuarioGestion.cNombreUsuario") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Fecha Alta">
                                                <ItemTemplate>
                                                    <asp:Label ID="dtFechaRegistro" runat="server" Text='<%# Eval("dtFechaRegistro", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarStatusOrden"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarStatusOrden"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-pencil"></span> Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarStatusOrden"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarStatusOrden"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
    <span aria-hidden="true" class="fa fa-trash"></span> Eliminar
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEdicion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoStatusOrden" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarStatusOrden" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                <!--final formulario-->
                      </div>
                <!-- /.tab-pane FIN CATALOGO STATUS ORDEN -->

                <!-- tab CATALOGO DE TIPO SOLICITUD -->
                <div class="tab-pane" id="tab_7">
                   <!--agregando formulario-->
                    <div class="table-responsive">
                        <div class="form-group">
                        <div class="box-header with-border">
                            <div class="box-tools">
                                <div class="input-group input-group-sm" style="width: 300px;">
                                    <asp:TextBox runat="server" ID="txtNombreTipoSolicitud" CssClass="form-control pull-right" placeholder="Buscar" />
                                    <div class="input-group-btn">
                                        <!--<asp:DropDownList runat="server" ID="dropFiltroRamas" CssClass="btn btn-default dropdown-toggle"></asp:DropDownList>
                                        <asp:DropDownList runat="server" ID="dropFiltroProcesos" CssClass="btn btn-default dropdown-toggle"></asp:DropDownList> -->
                                        <asp:LinkButton ID="BuscarTipoSolicitud"
                                            runat="server"
                                            CssClass="btn btn-default"
                                            OnClick="BuscarTipoSolicitud_Click">
    <span aria-hidden="true" class="fa fa-search"></span> Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnNuevoTipoSolicitud"
                                            runat="server"
                                            CssClass="btn btn-success btn-sm"
                                            OnClick="NuevoTipoSolictud_Click">
    <span aria-hidden="true" class="fa fa-plus"></span> Nuevo
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                      </div>
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanelGridTipoSolicitud" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewTipoSolicitud" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="iIdTipoSolicitud" OnRowCommand="GridView_RowCommand">
                                        <Columns>
                                             <asp:TemplateField HeaderText="Tipo de Solicitud">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="idoculto" runat="server" Value='<%# Bind("iIdTipoSolicitud") %>' />
                                                    <asp:Label ID="cNombreTipoSolicitud" runat="server" Text='<%# Bind("cNombre") %>'><%# Eval("cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Rama">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdRama" runat="server" Value='<%# Bind("ObjRamas.iIdRama") %>' />
                                                    <asp:Label runat="server"><%# Eval("ObjRamas.cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              
                                             <asp:TemplateField HeaderText="Proceso">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="iIdProceso" runat="server" Value='<%# Bind("ObjProcesos.iIdProceso") %>' />
                                                    <asp:Label runat="server"><%# Eval("ObjProcesos.cNombre") %> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>      

                                            
                                            <asp:TemplateField HeaderText="Opciones" ItemStyle-Width="161px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditarTipoSolicitud"
                                                        runat="server"
                                                        CssClass="btn btn-primary btn-sm"
                                                        CommandName="EditarTipoSolicitud"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                                        &nbsp; <span aria-hidden="true" class="fa fa-pencil"></span> &nbsp;  
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminarTipoSolicitud"
                                                        runat="server"
                                                        CssClass="btn btn-danger btn-sm"
                                                        CommandName="EliminarTipoSolicitud"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                                        &nbsp;  <span aria-hidden="true" class="fa fa-trash"></span> &nbsp;
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GuardarNuevo" EventName="Click" />
                                    
                                    <asp:AsyncPostBackTrigger ControlID="GuardarEliminacion" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNuevoTipoSolicitud" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BuscarTipoSolicitud" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                <!--final formulario-->
                    </div>
                <!-- /.tab-pane FIN CATALOGO TIPO SOLICITUD -->
     
                
            </div><!-- /.tab-content -->
          </div><!-- nav-tabs-custom -->
        </div><!-- /.col -->

                <!-- INICIO ROW MODALES -->
                <div class="row"><!-- Inicio Row-->

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
                <!-- Bootstrap Modal Dialog Edit -->
                <div class="modal fade" id="ModalEditar" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModalEditar" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>

                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitleEditar" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <!-- inicio puestos -->
                                    <div class="form-group" id="divpuestosE" runat="server">
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescripcionEditar" CssClass="form-control" runat="server"></asp:TextBox>
                                        <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeEditar" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> El Campo No debe estar vacio
                                            </asp:Label>
                                        </div>
                                    </div>
                                        </div>
                                    </div>
                                        </div>
                                    <!--fin puestos -->
                                    <!-- inicio periodos-->
                                    <div class="form-group" id="divperiodosE" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">
                                      
                                            <div class="form-group">
                                            <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescPeriodoEdit" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            </div>
                                        <div class="form-group">
                                                <div class="col-sm-10">
                                        <asp:TextBox ID="txtFechaIniEdit" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div></div>
                                        <div class="form-group">
                                                <div class="col-sm-10">
                                        <asp:TextBox ID="txtFechaFiEdit" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div></div>

                                        <div class="form-group">
                                                <div class="col-sm-10">
                                        <asp:TextBox ID="txtPresidenteEdit" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div></div>
                                        <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeEP" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i>No debe haber Campos vacios
                                            </asp:Label>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                        <!-- fin periodo-->
                                    <!-- inicio ramas -->
                                    <div class="form-group" id="divramasE" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" id="lblRamaE" runat="server">Nombre: </label>
                                            <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescRamasEdit" CssClass="form-control" runat="server"></asp:TextBox>
                                           </div></div>

                                           <div class="form-group">
                                                <label class="col-sm-2 control-label" runat="server" id="lblDirEd">Dirección: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropCambiarDireccion" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropCambiarDireccion_SelectedIndexChanged"></asp:DropDownList></div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label" runat="server" id="lblSubEd">Subd: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropCambiarSubdireccion"  AutoPostBack="True" OnSelectedIndexChanged="dropCambiarSubdireccion_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList></div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label" runat="server" id="lblDeEd">Depto: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropCambiarDepartamento" CssClass="form-control"></asp:DropDownList></div>
                                            </div>

                                        <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeER" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> No debe haber Campos vacios
                                            </asp:Label>
                                        </div>

                                    </div>
                                   </div>
                                  </div>      
                                    <!--fin ramas -->

                                    <!-- inicio procesos -->
                                    <div class="form-group" id="divprocesosE" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">

                                          <div class="form-group">
                                            <label class="col-sm-2 control-label" id="lblProE" runat="server">Nombre:</label>
                                                <div class="col-sm-10">
                                            <asp:TextBox ID="txtDescProcesoEdit" CssClass="form-control" runat="server"></asp:TextBox>
                                                     </div>
                                            </div>

                                        <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblPeriodoEd" runat="server">Periodo: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropperiodoEd" CssClass="form-control">
                                                    <asp:ListItem Text="*Selecciona una opción" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </div>
                                            </div>
                                        <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblRamasEd" runat="server">Rama: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropRamaEd" CssClass="form-control">
                                                    <asp:ListItem Text="*Selecciona una opción" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </div>
                                            </div>
                                           </div>
                                   </div>
                                  </div>      
                                    <!--fin procesos -->
                                    <!-- inicio status -->
                                    <div class="form-group" id="divstatusE" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">

                                          <div class="form-group">
                                            <label class="col-sm-2 control-label" id="lblStadoEd" runat="server">Nombre: </label>
                                                <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescStatusEdit" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div></div>

                                        <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblStProEd" runat="server">Proceso: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropprocesoEd" CssClass="form-control">
                                                    <asp:ListItem Text="*Selecciona una opción" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </div>
                                            </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" id="lblOrdeEd" runat="server">Orden: </label>
                                                <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescOrdenEdit" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div></div>
                                          </div>
                                        </div>
                                    </div>
                                    <!-- fin status -->
                                    <div class="form-group" id="divuserEd" runat="server">
                                                <label class="col-sm-2 control-label" id="lblUsuarioEd" runat="server">Usuario: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropUsuarioEd" CssClass="form-control">
                                                    <asp:ListItem Text="*Selecciona una opción" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </div>
                                            </div>

                                    <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeEPR" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> No debe haber Campos vacios
                                            </asp:Label>
                                        </div>

                                     <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeSE" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> No debe haber Campos vacios
                                            </asp:Label>
                                        </div>

                                    <div class="modal-footer">
                                        <asp:Button CssClass="btn btn-primary" ID="GuardarEdicion" runat="server" Text="Guardar" OnClick="Editar_Click" />
                                        <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropCambiarDireccion" EventName="selectedindexchanged" />
                                    <asp:AsyncPostBackTrigger ControlID="dropCambiarSubdireccion" EventName="selectedindexchanged" />
                             </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- Bootstrap Modal Dialog New -->
                <div class="modal fade" id="ModalNuevo" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModalNuevo" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitleNuevo" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <!-- inicio puestos -->
                                    <div class="form-group" id="divpuestosN" runat="server">
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescripcionNuevo" CssClass="form-control" runat="server"></asp:TextBox>
                                        <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeNuevo" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> El Campo No debe estar vacio
                                            </asp:Label>
                                        </div>
                                      </div>
                                    </div>
                                   </div>
                                  </div>
                                    <!-- fin puestos -->

                                    <!-- inicio periodos-->
                                    <div class="form-group" id="divperiodosN" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">
                                      
                                         <div class="form-group">
                                             <div class="col-sm-10">
                                           <asp:TextBox ID="txtDescPeriodoNuevo" CssClass="form-control" runat="server"></asp:TextBox>
                                         </div>
                                       </div>
                                        <div class="form-group">
                                         <div class="col-sm-10">
                                          <asp:TextBox ID="txtFechaIniNuevo" CssClass="form-control" runat="server"></asp:TextBox>
                                         </div></div>
                                        <div class="form-group">
                                          <div class="col-sm-10">
                                            <asp:TextBox ID="txtFechaFiNuevo" CssClass="form-control" runat="server"></asp:TextBox>
                                          </div></div>
                                        <div class="form-group">
                                         <div class="col-sm-10">
                                           <asp:TextBox ID="txtPresidenteNuevo" CssClass="form-control" runat="server"></asp:TextBox>
                                           </div></div>
                                          
                                          <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeNP" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i>No debe haber Campos vacios
                                            </asp:Label>
                                        </div>
                                    </div>
                                </div>
                              </div>
                                    <!-- fin periodo-->

                                    <!-- inicio ramas -->
                                    <div class="form-group" id="divramasN" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" id="lblRamaN" runat="server">Nombre: </label>
                                            <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescRamaNueva" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div></div>

                                          <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblDireccion" runat="server">Dirección: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropUserDireccion" CssClass="form-control"   AutoPostBack="True" OnSelectedIndexChanged="dropUserDireccion_SelectedIndexChanged"></asp:DropDownList></div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblSub" runat="server">Subd: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropUserSubdireccion"   OnSelectedIndexChanged="dropUserSubdireccion_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control"></asp:DropDownList></div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblDepto" runat="server">Depto: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropUserDepartamento" CssClass="form-control"></asp:DropDownList></div>
                                            </div>

                                        <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeNR" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> No debe haber Campos vacios
                                            </asp:Label>
                                        </div>
                                      </div>
                                    </div>
                                   </div>
                                    <!-- fin ramas -->

                                    <!-- inicio procesos -->
                                    <div class="form-group" id="divprocesoN" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">

                                          <div class="form-group">
                                            <label class="col-sm-2 control-label" id="lblProceN" runat="server">Nombre: </label>
                                                <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescProcesoNuevo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div></div>

                                        <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblPeriodoN" runat="server">Periodo: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropperiodo" CssClass="form-control">
                                                    <asp:ListItem Text="*Selecciona una opción" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </div>
                                            </div>

                                        <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblRamasN" runat="server">Rama: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropRama" CssClass="form-control">
                                                    <asp:ListItem Text="*Selecciona una opción" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </div>
                                            </div>

                                          </div>
                                        </div>
                                    </div>
                                    <!-- fin procesos -->

                                    <!-- inicio status -->
                                    <div class="form-group" id="divstatusN" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">

                                          <div class="form-group">
                                            <label class="col-sm-2 control-label" id="lblStadoN" runat="server">Nombre: </label>
                                                <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescStatusNuevo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div></div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" id="lblOrdeN" runat="server">Orden: </label>
                                                <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescOrdenNuevo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div></div>

                                          </div>
                                        </div>
                                    </div>
                                    <!-- fin status -->
                                    <div class="form-group" id="divprocN" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">

                                    <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblStProN" runat="server">Proceso: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropproceso" CssClass="form-control">
                                                    <asp:ListItem Text="*Selecciona una opción" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </div>
                                            </div>
                                          </div>
                                        </div>
                                       </div>
                                  
                                    <!-- inicio status orden-->
                                    <div class="form-group" id="divstatusOrN" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">

                                        <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblStOrdN" runat="server">Status: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropstatus" CssClass="form-control">
                                                    <asp:ListItem Text="*Selecciona una opción" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </div>
                                            </div>

                                          <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblStorddesN" runat="server">Status Orden: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropstatudeN" CssClass="form-control">
                                                    <asp:ListItem Text="*Selecciona una opción" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </div>
                                            </div>
                                        
                                          </div>
                                        </div>
                                    </div>
                                    <!-- fin status orden -->

                                    <div class="form-group" id="divuserN" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">

                                          <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lblUsuarioN" runat="server">Usuario: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropUsuario" CssClass="form-control">
                                                    <asp:ListItem Text="*Selecciona una opción" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </div>
                                            </div>
                                          </div>
                                        </div>
                                       </div>



                                    <div class="has-error">
                                            <asp:Label CssClass="control-label" ID="lblMensajeNPRST" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> No debe haber Campos vacios
                                            </asp:Label>
                                        </div>

                                    <!-- inicio tipo solicitud -->
                                    <div class="form-group" id="divtipoSolN" runat="server">
                                    <div class="modal-body">
                                      <div class="form-horizontal">

                                          <div class="form-group">
                                            <label class="col-sm-2 control-label" id="lbltipNombre" runat="server">Nombre: </label>
                                                <div class="col-sm-10">
                                        <asp:TextBox ID="txtTipoSolicitudNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div></div>

                    
                                           <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lbltipRama" runat="server">Rama: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropTipoSolicitudRama" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-2 control-label" id="lbltipPro" runat="server">Proceso: </label>
                                                <div class="col-sm-10">
                                                    <asp:DropDownList runat="server" ID="dropTipoSolicitudProceso"  AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>

                                          </div>
                                        </div>
                                    </div>

                                        <div class="has-error">
                                                        <asp:Label CssClass="control-label" ID="lblMensajeTipoSolicitudNombre" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Campo Obligatorio
                                                        </asp:Label>
                                                    </div>
                                    <!-- fin tipo solicitud -->

                                    <div class="modal-footer">
                                        <asp:Button CssClass="btn btn-primary" ID="GuardarNuevo" runat="server" Text="Guardar" OnClick="Nuevo_Click" />
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
            </div><!-- Fin Row-->
            <!-- FIN ROW MODALES -->
    </section>
    </div>
</asp:Content>




