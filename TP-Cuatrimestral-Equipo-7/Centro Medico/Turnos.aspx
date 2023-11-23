<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Centro_Medico.WebForm1" %>

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
                <h1>Recepcionista - Turnos</h1>
            </div>
        </div>
    </div>




    <div class="row justify-content-center">
        <div class="col-8 table-responsive" style="max-height: 400px; max-width: 800px; overflow-x: auto;">
            <h4>Paciente</h4>
            <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPacientes_RowCommand" DataKeyNames="ID" CssClass="table table-striped table-dark">
                <HeaderStyle CssClass="sticky-top" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ItemStyle-CssClass="table-cell" HeaderStyle-CssClass="table-cell" />
                    <asp:BoundField DataField="DNI" HeaderText="DNI" SortExpression="DNI" ItemStyle-CssClass="table-cell" HeaderStyle-CssClass="table-cell" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" ItemStyle-CssClass="table-cell" HeaderStyle-CssClass="table-cell" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" ItemStyle-CssClass="table-cell" HeaderStyle-CssClass="table-cell" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Seleccionar" CommandName="Seleccionar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

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

            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn btn-primary mt-2" />
        </div>
    </div>



</asp:Content>
