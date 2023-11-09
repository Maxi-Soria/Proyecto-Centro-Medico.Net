<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Centro_Medico.Login1" %>
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

                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary mt-2 mb-3" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>




