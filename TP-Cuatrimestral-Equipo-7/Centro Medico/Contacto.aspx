<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Centro_Medico.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .contacto-container {
            max-width: 600px; 
            margin: auto;
            padding: 20px; 
            background-color: #ffffff; 
            border: 1px solid #ddd; 
            border-radius: 10px; 
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); 
        }

        .contacto-container .mb-3 {
            margin-bottom: 15px; 
        }

        .contacto-container label {
            display: block; 
            margin-bottom: 5px; 
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contacto-container">
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label class="form-label">Asunto</label>
            <asp:TextBox runat="server" ID="txtAsunto" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label class="form-label">Mensaje</label>
            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMensaje" CssClass="form-control" />
        </div>
        <asp:Button Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" ID="btnAceptar" runat="server" />
    </div>
</asp:Content>