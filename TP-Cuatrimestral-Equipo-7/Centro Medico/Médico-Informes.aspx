<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Medico-Informes.aspx.cs" Inherits="Centro_Medico.Médico_Informes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            border: 1px solid #ddd;
            padding: 10px;
            margin: 10px;
            border-radius: 5px;
        }

        .past-turno {
            background-color: #f8d7da; 
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:GridView ID="GridViewTurnos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="GridViewTurnos_RowCommand">
            <Columns>
                <asp:BoundField DataField="IDTurno" HeaderText="IDTurno" SortExpression="IDTurno" />
                <asp:BoundField DataField="Día" HeaderText="Día" SortExpression="Día" />
                <asp:BoundField DataField="Mes" HeaderText="Mes" SortExpression="Mes" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Horario" HeaderText="Horario" SortExpression="Horario" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Agregar Observación" CommandName="AgregarObservacion" CommandArgument='<%# Eval("IDTurno") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Panel ID="ObservacionPanel" runat="server" CssClass="modal">
            <div class="modal-content">
                <span class="close" onclick="CerrarObservacionPopup()">&times;</span>
                <h3>Agregar Observación</h3>
                <asp:TextBox ID="ObservacionTextBox" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="GuardarObservacionButton" runat="server" Text="Guardar" OnClick="GuardarObservacionButton_Click" CssClass="btn btn-primary" />
            </div>
        </asp:Panel>

    </div>

    <script>
        function MostrarObservacionPopup(button) {
            var idTurno = button.getAttribute('commandargument');
            document.getElementById('<%= ObservacionPanel.ClientID %>').style.display = 'block';
        }

        function CerrarObservacionPopup() {
            document.getElementById('<%= ObservacionPanel.ClientID %>').style.display = 'none';
        }
    </script>
</asp:Content>