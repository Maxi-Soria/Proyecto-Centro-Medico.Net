<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Paciente-MiPerfil.aspx.cs" Inherits="Centro_Medico.Paciente_MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .center-content {
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        .content-container {
            width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center-content">
        <div class="col-md-3 mt-1 border content-container">
            <div class="mb-3">
                <asp:Label ID="lblIdPaciente" runat="server" AssociatedControlID="txtDniPaciente" CssClass="form-label fw-bold">ID</asp:Label>
                <asp:TextBox ID="txtIdPaciente" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                <asp:Label ID="lblDniPaciente" runat="server" AssociatedControlID="txtDniPaciente" CssClass="form-label fw-bold">DNI</asp:Label>
                <asp:TextBox ID="txtDniPaciente" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblNombrePaciente" runat="server" AssociatedControlID="txtNombrePaciente" CssClass="form-label fw-bold">Nombre</asp:Label>
                <asp:TextBox ID="txtNombrePaciente" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblApellidoPaciente" runat="server" AssociatedControlID="txtApellidoPaciente" CssClass="form-label fw-bold">Apellido</asp:Label>
                <asp:TextBox ID="txtApellidoPaciente" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="form-label fw-bold">Correo Electrónico</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblFechaNacimiento" runat="server" AssociatedControlID="txtFechaNacimiento" CssClass="form-label fw-bold">Fecha de Nacimiento</asp:Label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

                <asp:Label ID="lblDireccion" runat="server" AssociatedControlID="txtDireccion" CssClass="form-label fw-bold">Domicilio</asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblTelefono" runat="server" AssociatedControlID="txtTelefono" CssClass="form-label fw-bold">Número Telefónico</asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>

                <div class="mt-4 w-100">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning btn-sm" OnClick="btnModificar_Click" />
                    <asp:HyperLink ID="linkPacientes" runat="server" class="btn btn-primary btn-sm bg-dark" NavigateUrl="CRUD_Pacientes.aspx">Cancelar</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>