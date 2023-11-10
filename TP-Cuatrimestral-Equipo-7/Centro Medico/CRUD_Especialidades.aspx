﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CRUD_Especialidades.aspx.cs" Inherits="Centro_Medico.CRUDEspecialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid vh-100">
        <div class="row">
            <!-- Contenedor de 2 columnas -->
            <div class="col-md-2 vh-100 bg-dark">
                <div class="btn-group-vertical btn-group-lg w-100">
                    <!-- Tus botones aquí -->
        <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-primary rounded custom-btn-size w-100 mt-3" NavigateUrl="CRUD_Especialidades.aspx" >Especialidades</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" class="btn btn-success mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Usuarios.aspx">Usuarios</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" runat="server" class="btn btn-info mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Turnos">Turnos</asp:HyperLink>
        <asp:HyperLink ID="HyperLink4" runat="server" class="btn btn-warning mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Medicos.aspx">Medicos</asp:HyperLink>
        <asp:HyperLink ID="HyperLink5" runat="server" class="btn btn-danger mt-3 rounded custom-btn-size w-100" NavigateUrl="#">NO se</asp:HyperLink>
                </div>
            </div>


            <!-- Contenedor de 10 columnas -->
            <div class="col-md-7">
                <!-- Contenido del segundo contenedor -->
                <h2 class="text-center">vista de CRUD Especialidades</h2>
                <div class="table-responsive" style="max-height: 400px; max-width: 800px; overflow-x: auto;">
                    <asp:GridView runat="server" ID="dgvEspecialidades" OnSelectedIndexChanged="dgvEspecialidades_SelectedIndexChanged" CssClass="table table-striped table-bordered table-dark">
                        <HeaderStyle CssClass="sticky-top " />
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="btn mt-3">
                    <asp:TextBox ID="tbAgregar" runat="server"></asp:TextBox>
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                </div>

            </div>

            <div class="col-md-3 border">
                <asp:Label ID="lblId" runat="server" Text="ID:    "></asp:Label>
                <asp:TextBox ID="tbId" runat="server" CssClass="mt-3" ReadOnly="true"></asp:TextBox>
                <br />
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="tbNombre" runat="server" CssClass="mt-3"></asp:TextBox>
                <div class="mt-2">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnElminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                    <asp:HyperLink ID="linkEspecialidades" runat="server" class="btn btn-primary" NavigateUrl="CRUD_Especialidades.aspx">Cancelar</asp:HyperLink>

                </div>

            </div>

        </div>
    </div>


</asp:Content>
