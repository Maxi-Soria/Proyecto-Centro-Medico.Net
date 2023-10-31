<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RolAdministrador.aspx.cs" Inherits="Centro_Medico.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container d-flex  align-items-center" style="height: 100vh; flex-direction: column;">
    <h2>ACA VAMOS A TRABAJAR EL ROL ADMIN</h2>
    <asp:GridView runat="server" ID="dgvEspecialidades"></asp:GridView>
</div>

</asp:Content>
