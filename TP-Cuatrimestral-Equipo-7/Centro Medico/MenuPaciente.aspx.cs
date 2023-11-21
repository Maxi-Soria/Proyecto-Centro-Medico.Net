using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Centro_Medico
{
    public partial class MenuPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnSolicitarTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("Turnos.aspx", false);
        }

      
    }
}