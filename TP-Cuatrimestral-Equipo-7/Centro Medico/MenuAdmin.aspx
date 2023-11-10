<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="Centro_Medico.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<div class="container-fluid vh-100">
    <div class="row">
        <!-- Contenedor de 2 columnas -->
<div class="col-md-2 border vh-100 bg-dark">
    <div class="btn-group-vertical btn-group-lg w-100">
        <!-- Tus botones aquí -->
        <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-primary rounded custom-btn-size w-100 mt-3" NavigateUrl="CRUD_Especialidades.aspx" >Especialidades</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" class="btn btn-success mt-3 rounded custom-btn-size w-100">Usuarios</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" runat="server" class="btn btn-info mt-3 rounded custom-btn-size w-100">Turnos</asp:HyperLink>
        <asp:HyperLink ID="HyperLink4" runat="server" class="btn btn-warning mt-3 rounded custom-btn-size w-100">Medicos</asp:HyperLink>
        <asp:HyperLink ID="HyperLink5" runat="server" class="btn btn-danger mt-3 rounded custom-btn-size w-100">NO se</asp:HyperLink>
        <asp:HyperLink ID="HyperLink6" runat="server" class="btn btn-secondary mt-3 rounded custom-btn-size w-100">Tampoco se</asp:HyperLink>
    </div>
</div>

        
        <!-- Contenedor de 10 columnas -->
        <div class="col-md-10 border w-100">
            <!-- Contenido del segundo contenedor -->
            <h2 class="text-center">Vista de Administracion</h2>

        </div>
    </div>
</div>




</asp:Content>
