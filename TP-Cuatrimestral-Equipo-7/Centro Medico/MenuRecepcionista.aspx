<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuRecepcionista.aspx.cs" Inherits="Centro_Medico.MenuRecepcionista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="border p-3 mb-4">
            <h1 class="text-center">RECEPCIONISTA</h1>
        </div>
        
        <div class="row text-center">
            <div class="col-md-4 mb-4">
                <img src="https://omniawfm.com/blog/images/optimizar-el-calendario-de-turnos-de-trabajo.jpg" alt="Imagen 1" class="img-fluid mb-2" style="width: 350px; height: 350px;" />
                <a href="Turnos.aspx" class="btn btn-primary">Turnos</a>
            </div>
            <div class="col-md-4 mb-4">
                <img src="https://img.freepik.com/vector-gratis/medicos-enfermeras-dibujos-animados_52683-59918.jpg" alt="Imagen 2" class="img-fluid mb-2" style="width: 350px; height: 350px;" />
                <a href="Recepcionista-MenúMedicos.aspx" class="btn btn-primary">Médicos</a>
            </div>
            <div class="col-md-4 mb-4">
                <img src="https://elmedicointeractivo.com/wp-content/uploads/2018/02/pacientes.jpg" alt="Imagen 3" class="img-fluid mb-2" style="width: 350px; height: 350px;" />
                <a href="Recepcionista-MenúPacientes.aspx" class="btn btn-primary">Pacientes</a>
            </div>
        </div>
    </div>
</asp:Content>