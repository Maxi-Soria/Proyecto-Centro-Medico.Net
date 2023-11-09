<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuMedico.aspx.cs" Inherits="Centro_Medico.MenuMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Panel de Médico</h2>
        <div class="row">
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Revisar turnos</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Colocar observación</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Solicitar estudios</a>
            </div>
        </div>
    </div>
</asp:Content>
