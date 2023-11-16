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
            
            int nroUser = 5;       

            try
            {
                                
                usuario = new Usuario(txtUser.Value, txtPassword.Value, nroUser);
                usuarioNegocio.Loguear(usuario);
                nroUser = (int)usuario.TipoUsuario;

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
                    Session.Add("Error", "Usuario o Contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}