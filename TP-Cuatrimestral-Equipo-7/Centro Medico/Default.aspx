<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Centro_Medico.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center mt-4" style="height: 100vh";>
        <div class="mb-3">
            <a href="RolAdministrador.aspx" class="btn btn-primary">Administrador</a>
        </div>
        <div class="mb-3">
            <a href="RolRecepcionista.aspx" class="btn btn-primary">Recepcionista</a>
        </div>
        <div class="mb-3">
            <a href="RolMedico.aspx" class="btn btn-primary">Medico</a>
        </div>
    </div>

</asp:Content>
