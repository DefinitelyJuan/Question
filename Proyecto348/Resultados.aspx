﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="Proyecto348.Resultados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous"/>
    <link href="css\styleResult.css" rel="stylesheet" />
    <script
  src="https://code.jquery.com/jquery-3.6.1.js"
  integrity="sha256-3zlB5s2uwoUzrXK3BT7AX3FyvojsraNFxCc2vC/7pNI="
  crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark searchBar" runat="server" id="searchNav">
            <asp:LinkButton ID="lbAll" runat="server" CssClass="activeSO" OnClick="lbAll_Click">Todos</asp:LinkButton>
            <asp:LinkButton ID="lbImage" runat="server" CssClass="inactiveSO" OnClick="lbImage_Click">Imagenes</asp:LinkButton>
         <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <div class="row my-2 my-lg-0">
                <div class="col-md-4">
                <asp:TextBox ID="txtSearch" runat="server" cssClass="form-control mr-sm-2" placeholder="Buscar" aria-label="Buscar"></asp:TextBox>

                </div>
                <div class="col-md-4">
                     <asp:Button ID="btnBuscar" runat="server" Text="Buscar" cssClass="btn btn-outline-primary btnBuscar" OnClick="btnBuscar_Click"/>

                </div>

            </div>
          </div>
        </nav>
        <div class="" runat="server" id="main">
        </div>
    </form>
</body>
</html>
