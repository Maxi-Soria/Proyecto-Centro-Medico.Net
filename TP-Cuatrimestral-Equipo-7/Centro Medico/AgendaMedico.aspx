<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgendaMedico.aspx.cs" Inherits="Centro_Medico.AgendaMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
     


        <asp:GridView ID="GridViewAgenda" runat="server" AutoGenerateColumns="False" 
            EmptyDataText="No hay datos disponibles" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="IDTurno" HeaderText="IDTurno" SortExpression="IDTurno" />
                <asp:BoundField DataField="Día" HeaderText="Día" SortExpression="Día" />
                <asp:BoundField DataField="Mes" HeaderText="Mes" SortExpression="Mes" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Horario" HeaderText="Horario" SortExpression="Horario" />


            </Columns>
        </asp:GridView>
    </div>
</asp:Content>