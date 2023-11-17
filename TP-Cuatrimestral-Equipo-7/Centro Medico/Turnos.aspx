<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Centro_Medico.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #txtFechaSeleccionada {
            display: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-6">
            <h1>Reserve su turno</h1>
        </div>
    </div>
    </div>

    <h4>Especialidad</h4>
    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-select" 
        AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
        <asp:ListItem Text="" Value="" />
    </asp:DropDownList>

    <h4>Médico</h4>
        <asp:DropDownList ID="ddlMedicos" runat="server" CssClass="form-select">
            <asp:ListItem Text="" Value="" />
            </asp:DropDownList>
        <asp:ScriptManager runat="server"></asp:ScriptManager>

    <h4>Día</h4>
        <asp:Calendar ID="calendario" runat="server" OnSelectionChanged="calendario_SelectionChanged"></asp:Calendar>
        <asp:TextBox ID="txtFechaSeleccionada" runat="server" ReadOnly="true" style="display: none;"></asp:TextBox>

    <h4>Horario</h4>
        <asp:DropDownList ID="ddlHorarios" runat="server" CssClass="form-select">
        <asp:ListItem Text="" Value="" />
    </asp:DropDownList>

    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" CssClass="btn btn-primary" />

</asp:Content>
