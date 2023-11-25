<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CRUD_Horarios.aspx.cs" Inherits="Centro_Medico.CRUD_Horarios" %>
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

            <div class="col-md-7 border">
                
                <div class="table-responsive" style="max-height: 600px; max-width: 800px; overflow-x: auto;">
                    <asp:GridView runat="server" ID="dgvHorarios" OnSelectedIndexChanged="dgvHorarios_SelectedIndexChanged" CssClass="table table-striped table-bordered table-dark" AutoGenerateColumns="false">
    <HeaderStyle CssClass="sticky-top" />
    <Columns>
        <asp:BoundField DataField="IDHorario" HeaderText="IDHorario" SortExpression="IDHorario" Visible="true" />
        <asp:BoundField DataField="HoraInicio" HeaderText="Hora de Inicio" SortExpression="HoraInicio" Visible="true" />
        <asp:BoundField DataField="HoraFin" HeaderText="Hora de Fin" SortExpression="HoraFin" Visible="true" />
        <asp:CommandField ShowSelectButton="true" SelectText="Selec" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />
    </Columns>
</asp:GridView>
                </div>
            </div>

            <div class="col-md-3 mt-1 border">
                <div class="mb-3">
                    <asp:Label ID="lblIDHorario" runat="server" AssociatedControlID="txtIDHorario" CssClass="form-label fw-bold" style="display:none;">IDHorario</asp:Label>
                    <asp:TextBox ID="txtIDHorario" runat="server" CssClass="form-control" ReadOnly="true" style="display:none;"></asp:TextBox>

                    <asp:Label ID="lblHoraInicio" runat="server" AssociatedControlID="txtHoraInicio" CssClass="form-label fw-bold">HoraInicio</asp:Label>
                    <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblHoraFin" runat="server" AssociatedControlID="txtHoraFin" CssClass="form-label fw-bold">HoraFin</asp:Label>
                    <asp:TextBox ID="txtHoraFin" runat="server" CssClass="form-control"></asp:TextBox>

                    <div class="mt-4 w-100">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-sm" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning btn-sm" OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClick="btnEliminar_Click" />
                        <asp:HyperLink ID="linkHorarios" runat="server" class="btn btn-primary btn-sm bg-dark" NavigateUrl="CRUD_Medicos.aspx">Cancelar</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>