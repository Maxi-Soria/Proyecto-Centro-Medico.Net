<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuRecepcionista.aspx.cs" Inherits="Centro_Medico.MenuRecepcionista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Panel de Recepcionista</h2>
        <div class="row">
            <div class="col-md-4">
                <a href="Turnos.aspx" class="btn btn-primary btn-block">Turnos</a>
            </div>
            <div class="col-md-4">
                <a href="Recepcionista-MenúMedicos.aspx" class="btn btn-primary btn-block">Médicos</a>
            </div>
            <div class="col-md-4">
                <a href="Recepcionista-MenúPacientes.aspx" class="btn btn-primary btn-block">Pacientes</a>
            </div>
        </div>
    </div>
</asp:Content>
