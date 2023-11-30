<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Paciente-TurnoPersonal.aspx.cs" Inherits="Centro_Medico.Paciente_TurnoPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #txtFechaSeleccionada {
            display: none;
        }

        .calendario {
            width: 300px;
            margin: auto;
        }

            .calendario table {
                width: 100%;
            }

            .calendario th {
                background-color: #007bff;
                color: white;
            }

            .calendario td {
                text-align: center;
            }

            .calendario a {
                text-decoration: none;
                display: block;
                padding: 5px;
                color: black;
            }

                .calendario a:hover {
                    background-color: #f2f2f2;
                }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row justify-content-center">
            <div class="col justify-content-center">
                <h1>Reserve su turno</h1>
            </div>
        </div>
    </div>

        <div class="row justify-content-center mt-4">
        <div class="col-4 border border-3">
            <h4>Especialidad</h4>
            <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-select"
                AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                <asp:ListItem Text="" Value="" />
            </asp:DropDownList>

            <h4>Médico</h4>
            <asp:DropDownList ID="ddlMedicos" runat="server" CssClass="form-select"
                AutoPostBack="true" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged">
                <asp:ListItem Text="" Value="" />
            </asp:DropDownList>

            <h4>Día</h4>
            <asp:Calendar ID="calendario" runat="server" OnSelectionChanged="calendario_SelectionChanged" CssClass="calendario"></asp:Calendar>
            <asp:TextBox ID="txtFechaSeleccionada" runat="server" ReadOnly="true" Style="display: none;"></asp:TextBox>

            <h4>Horario</h4>
            <asp:DropDownList ID="ddlHorarios" runat="server" CssClass="form-select">
                <asp:ListItem Text="" Value="" />
            </asp:DropDownList>

            <h4>Observación</h4>
            <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" CssClass="btn btn-primary mt-2" />

            <asp:HyperLink ID="linkPacientes" runat="server" class="btn btn-primary btn-sm bg-dark" NavigateUrl="MenuPaciente.aspx">Volver</asp:HyperLink>
        </div>
    </div>


</asp:Content>

