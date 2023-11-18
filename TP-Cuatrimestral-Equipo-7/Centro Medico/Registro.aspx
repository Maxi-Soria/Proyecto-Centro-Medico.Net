<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Centro_Medico.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
        <div class="row mt-1" >
            <div class="col-12 d-flex justify-content-center align-items-center min-vh-100" style="background: url(img.jpg) center center / cover; background-color: rgba(255, 255, 255, 0.5);">
                <div class="col-3 border my-auto text-center" style="border-radius: 3px; padding: 20px; background-color: #c6ecf7;">
                    <img src="logoUser.png" alt="Logo de Usuario" class="img-fluid mb-3" />

                    <label for="txtUser">Usuario</label>
                    <input type="text" class="form-control" id="txtUser" aria-describedby="emailHelp" runat="server" />

                    <label for="txtPassword">Contraseña</label>
                    <input type="password" class="form-control" id="txtPassword" runat="server" />

                    <label for="txtNombre">Nombre</label>
                    <input type="text" class="form-control" id="txtNombre" runat="server" />

                    <label for="txtApellido">Apellido</label>
                    <input type="text" class="form-control" id="txtApellido" runat="server" />

                    <label for="txtDNI">DNI</label>
                    <input type="text" class="form-control" id="txtDNI" runat="server" />

                    <label for="txtEmail">Email</label>
                    <input type="email" class="form-control" id="txtEmail" runat="server" />

                    <label for="calFechaNacimiento">Fecha de Nacimiento</label>
                    <asp:Calendar ID="calFechaNacimiento" runat="server"></asp:Calendar>

                    <label for="txtDomicilio">Domicilio</label>
                    <input type="text" class="form-control" id="txtDomicilio" runat="server" />

                    <label for="txtTelefono">Número de Teléfono</label>
                    <input type="text" class="form-control" id="txtTelefono" runat="server" />

                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" OnClick="btnRegistrar_Click" CssClass="btn btn-primary mt-2 mb-3" />
                
                </div>
            </div>
        </div>
    </div>
</asp:Content>