<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" MasterPageFile="~/Site.master" %>


<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contInicio">
 <!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
        Inicio
        </h1>
        <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-home"></i> Inicio</a></li>
        </ol>
    </section>
    <section class="content">

        <div class="col-md-12">
          <div class="box box-solid">
            <div class="box-header with-border">
              <i class="fa fa-home"></i>

              <h3 class="box-title">Introducción</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <dl>
              
             <dd>Bienvenido <strong><asp:Label runat="server" ID="nombrecompleto"> </asp:Label> </strong>  al Sistema de Gestión de Solicitudes, aquí podrá encontrar una variedad de herramientas que le ayudaran a realizar este proceso.</dd>
              
          
              </dl>
            </div>
              </div>
            </div>
            <!-- /.box-body -->
           
           <div class="col-md-12">
        <div class="callout callout-danger">
                <h4>Aviso</h4>

               <p>Usted es responsable de su usuario y contraseña, porfavor no comparta sus datos de acceso con otros usuarios.</p>
              </div>
          <!-- /.box -->
        
      </div>
        
     &nbsp;
 &nbsp;

       
    </section>
</div>
</asp:Content>