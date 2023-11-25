<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Centro_Medico.SobreNosotros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .faq-container {
            max-width: 800px; /* Ajusta el ancho máximo según tu preferencia */
            margin: auto; /* Centra horizontalmente */
            padding: 20px; /* Añade espacio interno */
            background-color: #ffffff; /* Color de fondo del recuadro */
            border: 1px solid #ddd; /* Borde del recuadro */
            border-radius: 10px; /* Bordes redondeados */
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Sombra */
        }

        .faq-container h1, .faq-container h2 {
            text-align: center; /* Centra el texto */
        }

        .faq-container p {
            margin-bottom: 10px; /* Añade espacio inferior a los párrafos */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="faq-container">
        <h1>FAQ</h1>

        <h2>¿Quiénes somos?</h2>
        <p>Coco Health es un centro médico donde lo más importante son sus pacientes</p>
        <p>Aquí encontrará una alta variedad de especialistas aptos y capaces para atenderlo</p>

        <h2>¿Cómo reservo mi turno?</h2>
        <p>Para reservar su turno debe primero estar registrado en nuestra base de datos</p>
        <p>Luego, debe dirigirme al apartado de Turnos, donde podrá elegir sacar un turno personal o para otra persona</p>
        <p>Posteriormente, el sistema le mostrará el calendario con los días y horarios disponibles para el médico elegido</p>

        <h2>¿Cómo me contacto con ustedes?</h2>
        <p>Para ponerse en contacto con nosotros puede hacerlo a través del apartado Contacto</p>
        <p>Allí el sistema le solicitará un email y un mensaje</p>

        <h2>¿Es ese el único modo de contacto?</h2>
        <p>No, también puede comunicarse telefónicamente al número 0800-123-4413</p>
        <p>Nuestra recepción atenderá su llamada y lo guiará en lo que necesite</p>
    </div>
</asp:Content>