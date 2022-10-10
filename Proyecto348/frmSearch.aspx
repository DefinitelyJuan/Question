<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSearch.aspx.cs" Inherits="Proyecto348.frmSearc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Question</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="keywords" content="buscar, busqueda, informacion, question"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous"/>
    <link href="css\style.css" rel="stylesheet" />
    <script
  src="https://code.jquery.com/jquery-3.6.1.js"
  integrity="sha256-3zlB5s2uwoUzrXK3BT7AX3FyvojsraNFxCc2vC/7pNI="
  crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="overflow-hidden h-100 mainContainer d-flex justify-content-center">
            <div class="row h-90">
                <div class="my-auto">
                <div class="row h-50">
                    <img src="Images/Logo.png" class=" logoImg" />
                </div>

                <div class="textBox row h-25 my-4">
                    <asp:TextBox ID="txtSearchString" ClientIDMode="Static" runat="server" CssClass="txt form-control" data-toggle="popover" tabindex="-1" data-trigger="focus" data-placement="top" title="hol" data-content="hola"></asp:TextBox>
                </div>
                <div class="row h-25 d-flex justify-content-center mx-auto w-50">
                    
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" cssClass="btn btn-primary btn-lg btnBuscar" OnClick="btnBuscar_Click"/>
                                       
               </div>
                </div>
               
            </div>
            <footer class="d-flex flex-wrap justify-content-between align-items-center py-3 px-4 h-10">
                <p class="col-md-4 mb-0">© 2022 Grupo I</p>


                <ul class="nav col-md-4 justify-content-end">
                  <li class=""><a href="aboutus.html" class="px-2 text-decoration-none">Sobre Nosotros</a></li>
                </ul>
           </footer>
        </div>
    </form>
</body>
</html>
