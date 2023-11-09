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
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio usuarioNegocio = new negocio.UsuarioNegocio();
            
            int nroUser;
            if(txtUser.Value == "Admin" && txtPassword.Value == "Admin")
            {
                nroUser = 1;
            }else if(txtUser.Value == "Recepcionista" && txtPassword.Value == "Recepcionista")
            {
                nroUser = 2;
            }
            else if (txtUser.Value == "Medico" && txtPassword.Value == "Medico")
            {
                nroUser = 3;
            }
            else if (txtUser.Value == "Paciente" && txtPassword.Value == "Paciente")
            {
                nroUser = 4;
            }
            else 
            {
                nroUser = 5;
            }

            try
            {
                

                usuario = new Usuario(txtUser.Value, txtPassword.Value, nroUser);

                if (usuarioNegocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    switch (nroUser)
                    {
                        case 1:Response.Redirect("MenuAdmin.aspx", false);
                        break;
                        case 2:Response.Redirect("MenuRecepcionista.aspx", false);
                        break;
                        case 3: Response.Redirect("MenuMedico.aspx", false);
                        break;
                        case 4:Response.Redirect("MenuPaciente.aspx", false);
                        break;
                        case 5:Response.Redirect("Default.aspx", false);
                        break;
                    }
                    
                }
                else
                {
                    Session.Add("error", "user o pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}