<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Recepcionista-MenúMedicos.aspx.cs" Inherits="Centro_Medico.Recepcionista_MenúMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid vh-100">
        <div class="row">
                        
            <div class="col-md-7 border ">
                
                <h2 class="text-center">Medicos</h2>
                <div class="table-responsive" style="max-height: 600px; max-width: 800px; overflow-x: auto;">
                    <asp:GridView runat="server" ID="dgvMedicos" OnSelectedIndexChanged="dgvMedicos_SelectedIndexChanged" CssClass="table table-striped table-bordered table-dark">
                        <HeaderStyle CssClass="sticky-top" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" SelectText="Selec" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="col-md-3 mt-1 border">
                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" AssociatedControlID="txtIdMedico" CssClass="form-label fw-bold">ID</asp:Label>
                    <asp:TextBox ID="txtIdMedico" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                    <asp:Label ID="lblLegajo" runat="server" AssociatedControlID="txtLegajoMedico" CssClass="form-label fw-bold">Legajo</asp:Label>
                    <asp:TextBox ID="txtLegajoMedico" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblNombreMedico" runat="server" AssociatedControlID="txtNombreMedico" CssClass="form-label fw-bold">Nombre</asp:Label>
                    <asp:TextBox ID="txtNombreMedico" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblApellidoMedico" runat="server" AssociatedControlID="txtApellidoMedico" CssClass="form-label fw-bold">Apellido</asp:Label>
                    <asp:TextBox ID="txtApellidoMedico" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="form-label fw-bold">Correo Electrónico</asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>


                    <div class="mt-4 w-100">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-sm" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning btn-sm" OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClick="btnEliminar_Click" />
                        <asp:HyperLink ID="linkPacientes" runat="server" class="btn btn-primary btn-sm bg-dark" NavigateUrl="MenuRecepcionista.aspx">Volver</asp:HyperLink>
                    </div>

                </div>

            </div>




        </div>
    </div>


</asp:Content>


