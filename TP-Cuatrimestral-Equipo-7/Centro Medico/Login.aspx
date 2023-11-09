<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Centro_Medico.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <label for="exampleInputEmail1">Usuario</label>
        <input type="text" class="form-control" id="txtUser" aria-describedby="emailHelp" runat="server" />
    </div>
    <div class="form-group">
        <label for="exampleInputPassword1">Contraseña</label>
        <input type="password" class="form-control" id="txtPassword" runat="server" />
    </div>
    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
</asp:Content>