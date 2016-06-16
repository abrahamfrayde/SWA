﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Acceso_Login" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Acceso al Sistema</title>
    <link rel="stylesheet" href="~/assets/bootstrap/css/bootstrap.min.css" runat="server" />
      <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
      <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
      <!-- Theme style -->
    <link rel="stylesheet" href="~/assets/dist/css/AdminLTE.min.css" runat="server" />
     <!-- iCheck -->
    <link rel="stylesheet" href="~/assets/plugins/iCheck/square/blue.css" runat="server" />
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <div class="login-logo">
    <a href="~/index"><b>SGS</b>MID</a>
  </div>
  <!-- /.login-logo -->
  <div class="login-box-body">
    <p class="login-box-msg">Ingrese sus credenciales</p>

    <form runat="server">
      <div class="form-group has-feedback">
          <asp:TextBox ID="txtmail" type="email" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
          <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <asp:TextBox ID="txtpass" TextMode="Password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
      </div>
      <div class="row">
        <!-- /.col -->
        <div class="col-xs-4">
            <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-block btn-flat" OnClick="btnLogin_Click" runat="server" Text="Ingresar" />
        </div>

          
        <!-- /.col -->
      </div>
      <div class="row">
          <div class="col-xs-12">
              <br />
              <div class="has-error">
                <asp:Label CssClass="control-label" ID="lblMensaje" runat="server" Visible="false" Text="">
                    <i class="fa fa-times-circle-o"></i> Credenciales incorrectas
                </asp:Label>
              </div>
          </div>
      </div>
      
        <asp:ScriptManager ID="ScriptManager1" AsyncPostBackTimeout="360000" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
                <Scripts>
                    <asp:ScriptReference Path="~/assets/plugins/jQuery/jQuery-2.2.0.min.js" />
                    <asp:ScriptReference Path="~/assets/bootstrap/js/bootstrap.min.js" />
                    
                </Scripts>
           
           </asp:ScriptManager>
    </form>
  </div>
  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->


    
</body>
</html>
