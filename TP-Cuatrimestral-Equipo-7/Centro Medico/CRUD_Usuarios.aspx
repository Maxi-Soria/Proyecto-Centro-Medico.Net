<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CRUD_Usuarios.aspx.cs" Inherits="Centro_Medico.CRUD_Usuarios" %>

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
                    <asp:HyperLink ID="Horarios" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Horarios.aspx">Horarios</asp:HyperLink>
                </div>
            </div>


            <div class="col-md-7">
               

                <div class="table-responsive" style="max-height: 600px; max-width: 800px; overflow-x: auto;">
                    <asp:GridView runat="server" ID="dgvUsuarios" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" CssClass="table table-striped table-bordered table-dark">
                        <HeaderStyle CssClass="sticky-top " />
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" ControlStyle-CssClass="btn btn-sm btn-primary" />
                        </Columns>
                    </asp:GridView>
                </div>

            </div>


            
            <div class="col-md-3 mt-1 border">
                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" AssociatedControlID="txtIdUsuario" CssClass="form-label fw-bold">ID</asp:Label>
                    <asp:TextBox ID="txtIdUsuario" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                    <asp:Label ID="lblUser" runat="server" AssociatedControlID="txtUser" CssClass="form-label fw-bold">User</asp:Label>
                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblPass" runat="server" AssociatedControlID="txtPass" CssClass="form-label fw-bold">Password</asp:Label>
                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="form-label fw-bold">Correo Electrónico</asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>


                    <div class="mt-4 w-100">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-sm" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning btn-sm" OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClick="btnEliminar_Click" />
                        <asp:HyperLink ID="linkPacientes" runat="server" class="btn btn-primary btn-sm bg-dark" NavigateUrl="CRUD_Usuarios.aspx">Cancelar</asp:HyperLink>
                    </div>

                </div>

            </div>


        </div>
    </div>


</asp:Content>
