using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Centro_Medico
{
    public partial class MenuMedico : System.Web.UI.Page
    {
        private Medico medico = new Medico();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnAgenda_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgendaMedico.aspx");
        }


        protected void btnPacientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("administrar_pacientes.html");
        }


        protected void btnHorarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("administrar_horarios.html");
        }


        protected void btnEstudios_Click(object sender, EventArgs e)
        {
            Response.Redirect("administrar_estudios.html");
        }


        protected void btnInformes_Click(object sender, EventArgs e)
        {
            Response.Redirect("administrar_informes.html");
        }


        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("administrar_perfil.html");
        }
    }
}