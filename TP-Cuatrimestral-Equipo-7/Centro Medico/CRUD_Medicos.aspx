<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CRUD_Medicos.aspx.cs" Inherits="Centro_Medico.CRUD_Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid vh-100">
        <div class="row">

            <div class="col-md-2 border vh-100 bg-dark">
                <div class="btn-group-vertical w-100">

                    <asp:HyperLink ID="Especialidades" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100 " NavigateUrl="CRUD_Especialidades.aspx">Especialidades</asp:HyperLink>
                    <asp:HyperLink ID="Pacientes" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100 " NavigateUrl="CRUD_Pacientes.aspx">Pacientes</asp:HyperLink>
                    <asp:HyperLink ID="Usuarios" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Usuarios.aspx">Usuarios</asp:HyperLink>
                    <asp:HyperLink ID="Turnos" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Turnos.aspx">Turnos</asp:HyperLink>
                    <asp:HyperLink ID="Medicos" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Medicos.aspx">Medicos</asp:HyperLink>
                    <asp:HyperLink ID="Horarios" runat="server" class="btn btn-primary mt-3 rounded custom-btn-size w-100" NavigateUrl="CRUD_Horarios.aspx">Horarios</asp:HyperLink>
                </div>
            </div>



            <div class="col-md-7 border ">

                
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
                    <asp:Label ID="lblId" runat="server" AssociatedControlID="txtIdMedico" CssClass="form-label fw-bold" Style="display: none;">ID</asp:Label>
                    <asp:TextBox ID="txtIdMedico" runat="server" CssClass="form-control" ReadOnly="true" Style="display: none;"></asp:TextBox>

                    <asp:Label ID="lblLegajo" runat="server" AssociatedControlID="txtLegajoMedico" CssClass="form-label fw-bold">DNI</asp:Label>
                    <asp:TextBox ID="txtLegajoMedico" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblNombreMedico" runat="server" AssociatedControlID="txtNombreMedico" CssClass="form-label fw-bold">Nombre</asp:Label>
                    <asp:TextBox ID="txtNombreMedico" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblApellidoMedico" runat="server" AssociatedControlID="txtApellidoMedico" CssClass="form-label fw-bold">Apellido</asp:Label>
                    <asp:TextBox ID="txtApellidoMedico" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="form-label fw-bold">Correo Electrónico</asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblEspecialidades" runat="server" CssClass="form-label fw-bold">Especialidades</asp:Label>
                    <div class="mb-1">
                        <asp:DropDownList ID="ddlAgregarEsp" runat="server"></asp:DropDownList>
                        <asp:Button ID="btnAgregarEsp" OnClick="btnAgregarEspecialidad_a_Medico" runat="server" Text="+" />
                        <asp:Button ID="Button2" runat="server" OnClick="btnQuitarEspecialidad_a_Medico" Text="-" />
                    </div>
                    <div class="input-group">
                        <asp:ListBox ID="listBox" CssClass="form-control h-100" runat="server"></asp:ListBox>
                    </div>


                   <asp:Label ID="lblHorarios" runat="server" CssClass="form-label fw-bold">Horarios</asp:Label>
                   <div class="mb-1">
                        <asp:DropDownList ID="DropDownListHxM" runat="server"></asp:DropDownList>
                        <asp:Button ID="agregarHxM" OnClick="btnAgregarHorario_a_Medico" runat="server" Text="+" />
                        <asp:Button ID="quitarHxM" runat="server" Text="-" onClick="btnQuitarHorario_a_Medico" />
                    </div>
                    <div>
                        <asp:ListBox ID="listBoxHxM" CssClass="form-control h-100" runat="server"></asp:ListBox>
                    </div>

                    <div class="mt-4 w-100">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-sm" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning btn-sm" OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClick="btnEliminar_Click" />
                        <asp:HyperLink ID="linkPacientes" runat="server" class="btn btn-primary btn-sm bg-dark" NavigateUrl="CRUD_Medicos.aspx">Cancelar</asp:HyperLink>
                    </div>

                </div>

            </div>




        </div>
    </div>




</asp:Content>
