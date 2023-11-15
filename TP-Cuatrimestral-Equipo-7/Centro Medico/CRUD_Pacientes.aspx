<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CRUD_Pacientes.aspx.cs" Inherits="Centro_Medico.CRUD_Pacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid vh-100">
        <div class="row">
            <!-- Contenedor de 2 columnas -->
            <div class="col-md-2 border vh-100 bg-dark">
                <div class="btn-group-vertical w-100">
                    <!-- Tus botones aquí -->
                    <asp:HyperLink ID="Especialidades" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100 " NavigateUrl="CRUD_Especialidades.aspx">Especialidades</asp:HyperLink>
                    <asp:HyperLink ID="Pacientes" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100 " NavigateUrl="CRUD_Pacientes.aspx">Pacientes</asp:HyperLink>
                    <asp:HyperLink ID="Usuarios" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Usuarios.aspx">Usuarios</asp:HyperLink>
                    <asp:HyperLink ID="Turnos" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Turnos.aspx">Turnos</asp:HyperLink>
                    <asp:HyperLink ID="Medicos" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Medicos.aspx">Medicos</asp:HyperLink>
                </div>
            </div>


            <!-- Contenedor de 10 columnas -->
            <div class="col-md-10 border ">
                <!-- Contenido del segundo contenedor -->
                <h2 class="text-center">Pacientes</h2>

<asp:GridView runat="server" ID="dgvPacientes" OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged" CssClass="table table-striped table-bordered table-dark">
    <HeaderStyle CssClass="sticky-top" />
    <Columns>
        
 
        <asp:CommandField ShowSelectButton="true" SelectText="Selec" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />

    </Columns>
</asp:GridView>




            </div>
        </div>
    </div>

</asp:Content>
