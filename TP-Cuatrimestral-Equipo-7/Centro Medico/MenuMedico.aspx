<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuMedico.aspx.cs" Inherits="Centro_Medico.MenuMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <a href="AgendaMedico.aspx" class="btn btn-primary btn-block">Agenda</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Pacientes</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Horarios</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Informes</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Perfil</a>
            </div>
        </div>
    </div>
</asp:Content>
