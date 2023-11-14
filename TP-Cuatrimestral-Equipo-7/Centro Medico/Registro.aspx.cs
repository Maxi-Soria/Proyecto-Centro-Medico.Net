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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                Usuario nuevoUsuario = new Usuario("paciente","paciente",4);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                nuevoUsuario.Email = txtEmail.Value;
                nuevoUsuario.User = txtUser.Value;
                nuevoUsuario.Pass = txtPassword.Value;
                int id = usuarioNegocio.insertarUsuario(nuevoUsuario);
            }
            catch (Exception ex)
            {

                Session.Add("Error",ex.ToString());
            }
        }
    }
}