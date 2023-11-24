<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Centro_Medico.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .rectangle {
            width: 500px;
            height: 50px;
            margin: 15px;
            display: inline-block;
            background-color: white;
            border: 2px solid;
            border-image: linear-gradient(45deg, #D291BC, #B4A5E5);
            border-image-slice: 1;
            border-radius: 10px;
            transition: background-color 0.3s, border-color 0.3s, transform 0.3s;
            font-family: 'Javanese Text', sans-serif;
            position: relative;
            cursor: pointer;
        }

        .rectangle:hover {
            background-color: #D291BC;
            border-color: #D291BC;
            transform: scale(1.05);
        }

        .text-inside {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            color: black;
            transition: color 0.3s;
        }

        .rectangle:hover .text-inside {
            color: white;
        }


    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center;">
        <asp:Image ID="Image1" runat="server" ImageUrl="https://img.freepik.com/premium-vector/heart-stethoscope-cartoon-illustration_138676-898.jpg" Width="500" Height="500" />
        <asp:Image ID="Image2" runat="server" ImageUrl="https://static.vecteezy.com/system/resources/previews/005/845/873/original/cute-heart-holding-stethoscope-cartoon-icon-illustration-healthy-mascot-character-health-and-medical-icon-concept-white-isolated-flat-cartoon-style-vector.jpg" Width="500" Height="500" />
        <asp:Image ID="Image3" runat="server" ImageUrl="https://img.freepik.com/vecteurs-premium/illustration-coeur-fort-personnage-dessin-anime-mascotte-amour-sante-medical-isole_138676-1045.jpg?w=2000" Width="500" Height="500" />

        <div class="rectangle">
            <div class="text-inside">SALUD</div>
        </div>
        <div class="rectangle">
            <div class="text-inside">PROFESIONALISMO</div>
        </div>
        <div class="rectangle">
            <div class="text-inside">COMPROMISO</div>
        </div>
        <div class="rectangle">
            <div class="text-inside">ESPECIALIDAD</div>
        </div>
        <div class="rectangle">
            <div class="text-inside">SEGUIMIENTO</div>
        </div>
        <div class="rectangle">
            <div class="text-inside">VITALIDAD</div>
        </div>
        
        

    </div>
</asp:Content>