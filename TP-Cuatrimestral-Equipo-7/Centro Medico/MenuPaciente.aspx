<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuPaciente.aspx.cs" Inherits="Centro_Medico.MenuPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Panel de Paciente</h2>
        <div class="row">
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Solicitar un turno</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Mi perfil</a>
            </div>
           
    </div>
</asp:Content>
