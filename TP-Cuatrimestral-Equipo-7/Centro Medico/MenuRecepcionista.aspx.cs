using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Centro_Medico
{
    public partial class MenuRecepcionista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnInsertarTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("Turnos.aspx");
        }

        protected void btnModificarTurno_Click(object sender, EventArgs e)
        {
            // Lógica cuando se hace clic en Modificar Turno
            // Puedes redirigir a la página correspondiente o realizar otras acciones
        }

        protected void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            // Lógica cuando se hace clic en Cancelar Turno
            // Puedes redirigir a la página correspondiente o realizar otras acciones
        }
    }
}