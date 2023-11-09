<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuRecepcionista.aspx.cs" Inherits="Centro_Medico.MenuRecepcionista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Panel de Recepcionista</h2>
        <div class="row">
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Insertar Turno</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Modificar Turno</a>
            </div>
            <div class="col-md-4">
                <a href="administrar_turnos.html" class="btn btn-primary btn-block">Eliminar Turno</a>
            </div>
        </div>
    </div>
</asp:Content>
