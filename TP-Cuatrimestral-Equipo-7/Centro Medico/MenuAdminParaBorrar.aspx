<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuAdminParaBorrar.aspx.cs" Inherits="Centro_Medico.MenuLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Código para la sección head de la página (si es necesario) -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Panel de Administración</h2>
        <div class="row">
            <div class="col-md-4">
                <a href="administrar_medicos.html" class="btn btn-primary btn-block">Administrar Médicos</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_especialidades.html" class="btn btn-primary btn-block">Administrar Especialidades</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Administrar Turnos</a>
            </div>
        </div>
    </div>
</asp:Content>