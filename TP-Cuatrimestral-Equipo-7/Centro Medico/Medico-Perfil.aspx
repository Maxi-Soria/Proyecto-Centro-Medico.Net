<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Medico-Perfil.aspx.cs" Inherits="Centro_Medico.Medico_Perfil" %>
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
                <asp:Label ID="lblIdMedico" runat="server" AssociatedControlID="txtIdMedico" CssClass="form-label fw-bold">ID</asp:Label>
                <asp:TextBox ID="txtIdMedico" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                <asp:Label ID="lblLegajo" runat="server" AssociatedControlID="txtLegajo" CssClass="form-label fw-bold">Legajo</asp:Label>
                <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                <asp:Label ID="lblNombreMedico" runat="server" AssociatedControlID="txtNombreMedico" CssClass="form-label fw-bold">Nombre</asp:Label>
                <asp:TextBox ID="txtNombreMedico" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblApellidoMedico" runat="server" AssociatedControlID="txtApellidoMedico" CssClass="form-label fw-bold">Apellido</asp:Label>
                <asp:TextBox ID="txtApellidoMedico" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="form-label fw-bold">Correo Electrónico</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>

                <div class="mt-4 w-100">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning btn-sm" OnClick="btnModificar_Click" />
                    <asp:HyperLink ID="linkMedicos" runat="server" class="btn btn-primary btn-sm bg-dark" NavigateUrl="MenuMedico.aspx">Cancelar</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>

</asp:Content>