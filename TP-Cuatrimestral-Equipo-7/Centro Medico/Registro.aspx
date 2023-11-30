<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Centro_Medico.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style> 
         .custom-calendar {
        width: 100%;
        max-width: 300px;
        margin: 0 auto;
        border: 1px solid #ddd;
        border-radius: 5px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        background-color: white;
    }

    .custom-calendar th,
    .custom-calendar td {
        text-align: center;
        padding: 10px;
        border: 1px solid #ddd;
    }

    .custom-calendar th {
        background-color: navajowhite;
    }

    .custom-calendar td {
        cursor: pointer;
        transition: background-color 0.3s;
    }

    .custom-calendar td:hover {
        background-color: mediumpurple;
    }

    
    .custom-calendar th a {
        display: block;
        width: 20px;
        height: 20px;
        border-radius: 50%;
        background-color: navajowhite; 
        color: #333;
        font-size: 18px;
        line-height: 20px;
        text-align: center;
        cursor: pointer;
    }

    .custom-calendar th a:hover {
        background-color: mediumpurple;
        color: white; 
    }
    </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
        <div class="row mt-1" >
            <div class="col-12 d-flex justify-content-center align-items-center min-vh-100" style="background: url(img.jpg) center center / cover; background-color: rgba(255, 255, 255, 0.5);">
                <div class="col-3 border my-auto text-center" style="border-radius: 3px; padding: 20px; background-color: #c6ecf7;">
                    <img src="logoUser.png" alt="Logo de Usuario" class="img-fluid mb-3" />

                    <label for="txtUser">Usuario</label>
                    <input type="text" class="form-control" id="txtUser" aria-describedby="emailHelp" runat="server" required />

                    <label for="txtPassword">Contraseña</label>
                    <input type="password" class="form-control" id="txtPassword" runat="server" required />

                    <label for="txtNombre">Nombre</label>
                    <input type="text" class="form-control" id="txtNombre" runat="server" required />

                    <label for="txtApellido">Apellido</label>
                    <input type="text" class="form-control" id="txtApellido" runat="server" required />

                    <label for="txtDNI">DNI</label>
                    <input type="text" class="form-control" id="txtDNI" runat="server" required />

                    <label for="txtEmail">Email</label>
                    <input type="email" class="form-control" id="txtEmail" runat="server" required />

                    <label for="calFechaNacimiento">Fecha de Nacimiento</label>
                    <asp:Calendar ID="calFechaNacimiento" runat="server" CssClass="custom-calendar"></asp:Calendar>

                    <label for="txtDomicilio">Domicilio</label>
                    <input type="text" class="form-control" id="txtDomicilio" runat="server" required />

                    <label for="txtTelefono">Número de Teléfono</label>
                    <input type="text" class="form-control" id="txtTelefono" runat="server"/>

                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" OnClick="btnRegistrar_Click" CssClass="btn btn-primary mt-2 mb-3" />
                
                </div>
            </div>
        </div>
    </div>
</asp:Content>