<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RolAdministrador.aspx.cs" Inherits="Centro_Medico.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-3">
    <div class="row justify-content-center align-items-center">
        <div class="col-md-2">
            <div class="btn-group-vertical btn-group-lg">
                <asp:HyperLink ID="btnEspecialidades" runat="server" class="btn btn-primary rounded custom-btn-size">Especialidades</asp:HyperLink>
                <asp:HyperLink ID="btnUsuarios" runat="server" class="btn btn-success mt-3 rounded custom-btn-size">Usuarios</asp:HyperLink>
                <asp:HyperLink ID="btnTurnos" runat="server" class="btn btn-info mt-3 rounded custom-btn-size">Turnos</asp:HyperLink>
                <asp:HyperLink ID="btnMedicos" runat="server" class="btn btn-warning mt-3 rounded custom-btn-size">Medicos</asp:HyperLink>
                <asp:HyperLink ID="btnNose" runat="server" class="btn btn-danger mt-3 rounded custom-btn-size">NO se</asp:HyperLink>
                <asp:HyperLink ID="btntampocoSe" runat="server" class="btn btn-secondary mt-3 rounded custom-btn-size">Tampoco se</asp:HyperLink>
            </div>
        </div>
    </div>
    <!--<asp:GridView runat="server" ID="dgvEspecialidades"></asp:GridView>-->
</div>






</asp:Content>
