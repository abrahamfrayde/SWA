<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Historial.aspx.cs" Inherits="Solicitudes_Historial" %>

<asp:Content ContentPlaceHolderID="contentBody" runat="server" ID="contInicio">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Historial               
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
            </section>
        </div>
    </asp:Content>