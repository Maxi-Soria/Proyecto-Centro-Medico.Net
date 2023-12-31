﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Recepcionista-MenúPacientes.aspx.cs" Inherits="Centro_Medico.Recepcionista_MenúPacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


            <div class="col-md-7 border ">
                
                <h2 class="text-center">Pacientes</h2>
                <div class="table-responsive" style="max-height: 600px; max-width: 800px; overflow-x: auto;">
                    <asp:GridView runat="server" ID="dgvPacientes" OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged" CssClass="table table-striped table-bordered table-dark">
                        <HeaderStyle CssClass="sticky-top" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" SelectText="Selec" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />
                        </Columns>
                    </asp:GridView>
                </div>

            </div>

            <div class="col-md-3 mt-1 border">

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
