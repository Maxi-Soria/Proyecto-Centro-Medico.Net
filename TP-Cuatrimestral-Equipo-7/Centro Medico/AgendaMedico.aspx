<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgendaMedico.aspx.cs" Inherits="Centro_Medico.AgendaMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Agenda Médico</h2>


        <asp:GridView ID="GridViewAgenda" runat="server" AutoGenerateColumns="False" 
            EmptyDataText="No hay datos disponibles" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="IDUsuario" HeaderText="IDUsuario" SortExpression="IDUsuario" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha de Cita" SortExpression="Fecha" />


            </Columns>
        </asp:GridView>
    </div>
</asp:Content>