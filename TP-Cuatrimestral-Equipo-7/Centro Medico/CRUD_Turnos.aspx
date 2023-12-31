﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CRUD_Turnos.aspx.cs" Inherits="Centro_Medico.CRUD_Turnos" %>



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

            <div class="col-md-7 border ">
                
                
                <div class="table-responsive" style="max-height: 3000px; max-width: 3000px; overflow-x: auto;">
                    <asp:GridView runat="server" ID="dgvTurnos" OnSelectedIndexChanged="dgvTurnos_SelectedIndexChanged" CssClass="table table-striped table-bordered table-dark">
            <HeaderStyle CssClass="sticky-top" />
                <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="Selec" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />

                </Columns>
</asp:GridView>
                </div>
            </div>

            <div class="col-md-3 mt-1 border">
                <div class="mb-3">
                    
                    <asp:TextBox ID="txtIdTurno" runat="server" CssClass="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtIdMedico" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtIdUsuario" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>

                    <asp:Label ID="lblM" runat="server" AssociatedControlID="txtLegajoMedico" CssClass="form-label fw-bold">Datos Medico</asp:Label>
                    <asp:TextBox ID="txtLegajoMedico" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                    <asp:Label ID="lblP" runat="server" AssociatedControlID="txtDniPaciente" CssClass="form-label fw-bold">Datos Paciente</asp:Label>
                    <asp:TextBox ID="txtDniPaciente" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                    <asp:Label ID="lblHorarioTurno" runat="server" AssociatedControlID="txtHorarioTurno" CssClass="form-label fw-bold">Horario del Turno</asp:Label>
                    <asp:TextBox ID="txtHorarioTurno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>


                    <asp:Label ID="lblFecha" runat="server" AssociatedControlID="txtFecha" CssClass="form-label fw-bold">Fecha</asp:Label>
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="true" OnTextChanged="txtFecha_TextChanged"></asp:TextBox>


                    <div>
                    <asp:Label ID="lblHorario" runat="server" AssociatedControlID="ddlHorarios" CssClass="form-label fw-bold">Otros Horarios</asp:Label>
                    <asp:DropDownList ID="ddlHorarios" runat="server"></asp:DropDownList>
                    </div>
                    
                    <asp:Label ID="lblObservaciones" runat="server" AssociatedControlID="txtObservaciones" CssClass="form-label fw-bold">Observaciones</asp:Label>
                    <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control"></asp:TextBox>

>
                    <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>

                    <asp:Label ID="lbiSituacion" runat="server" AssociatedControlID="txtSituacion" CssClass="form-label fw-bold">Situacion</asp:Label>
                    <asp:TextBox ID="txtSituacion" runat="server" CssClass="form-control text-dark" ReadOnly="true"></asp:TextBox>

                    <div class="mt-4 w-100">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-sm" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning btn-sm" OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-sm" OnClick="btnEliminar_Click" />
                        <asp:HyperLink ID="linkPacientes" runat="server" class="btn btn-primary btn-sm bg-dark" NavigateUrl="CRUD_Medicos.aspx">Volver</asp:HyperLink>
                    </div>

                </div>

            </div>
         
          

            </div>
        
    </div>

</asp:Content>
