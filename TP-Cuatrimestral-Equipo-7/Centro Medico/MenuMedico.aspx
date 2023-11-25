<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuMedico.aspx.cs" Inherits="Centro_Medico.MenuMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="border p-3 mb-4">
            <h1 class="text-center">MÉDICO</h1>
        </div>
        
        <div class="row text-center">
            <div class="col-md-4 mb-4">
                <img src="https://www.clipartkey.com/mpngs/m/258-2583691_doctor-appointment-icon.png" alt="Imagen 1" class="img-fluid mb-2" style="width: 350px; height: 350px;" />
                <a href="AgendaMedico.aspx" class="btn btn-primary">Turnos asociados</a>
            </div>
            <div class="col-md-4 mb-4">
                <img src="https://1.bp.blogspot.com/-ZAjwF8qMn7I/X6v59qe2_vI/AAAAAAAAAAs/RE9cYjq9lPIDTPvwnDZL9JnnV1laf5L0wCLcBGAsYHQ/s448/informe.png" alt="Imagen 2" class="img-fluid mb-2" style="width: 350px; height: 350px;" />
                <a href="administrar_turnos.html" class="btn btn-primary">Informes</a>
            </div>
            <div class="col-md-4 mb-4">
                <img src="https://img.freepik.com/vector-premium/ilustracion-lindo-medico-estetoscopio-diseno-personajes-dibujos-animados-vector-kawaii_380474-31.jpg" alt="Imagen 3" class="img-fluid mb-2" style="width: 350px; height: 350px;" />
                <a href="Medico-Perfil.aspx" class="btn btn-primary">Perfil</a>
            </div>
        </div>
    </div>
</asp:Content>