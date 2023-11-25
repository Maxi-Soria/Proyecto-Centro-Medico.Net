<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuPaciente.aspx.cs" Inherits="Centro_Medico.MenuPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="border p-3 mb-4">
            <h1 class="text-center">PACIENTE</h1>
        </div>
        
        <div class="row text-center">
            <div class="col-md-4 mb-4">
                <img src="https://cdn.goconqr.com/uploads/media/image/14140594/desktop_7ce2d685-ce08-47aa-9002-8be3c493e7b3.png" alt="Imagen 1" class="img-fluid mb-2" style="width: 350px; height: 350px;" />
                <a href="Paciente-TurnoPersonal.aspx" class="btn btn-primary">Turno para mí</a>
            </div>
            <div class="col-md-4 mb-4">
                <img src="https://static.vecteezy.com/system/resources/previews/027/501/579/non_2x/father-and-daughter-drawing-illustration-vector.jpg" alt="Imagen 2" class="img-fluid mb-2" style="width: 350px; height: 350px;" />
                <a href="Paciente-TurnoManual.aspx" class="btn btn-primary">Turno para otra persona</a>
            </div>
            <div class="col-md-4 mb-4">
                <img src="https://img.freepik.com/premium-vector/man-avatar-profile-round-icon_24640-14044.jpg" alt="Imagen 3" class="img-fluid mb-2" style="width: 350px; height: 350px;" />
                <a href="Paciente-MiPerfil.aspx" class="btn btn-primary">Mi Perfil</a>
            </div>
        </div>
    </div>
</asp:Content>