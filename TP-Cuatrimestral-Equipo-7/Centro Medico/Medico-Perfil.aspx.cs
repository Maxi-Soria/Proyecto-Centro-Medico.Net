using System;
using System.Collections.Generic;
using System.Linq;
using dominio;
using negocio;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;


namespace Centro_Medico
{
    public partial class Medico_Perfil : System.Web.UI.Page
    {
        private MedicoNegocio medicoNegocio = new MedicoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsUserAuthenticated())
                {
                    Response.Redirect("~/Login.aspx");
                    return;
                }

                int idMedicoActual = ObtenerIdMedicoActual();

                if (idMedicoActual > 0)
                {
                    CargarDatosMedico(idMedicoActual);
                }
            }
        }

        private bool IsUserAuthenticated()
        {
            return Session["usuario"] != null;
        }

        private void CargarDatosMedico(int idMedico)
        {
            Medico medico = medicoNegocio.listarUnMedico(idMedico);

            if (medico != null)
            {
                txtIdMedico.Text = medico.IDMedico.ToString();
                txtLegajo.Text = medico.Legajo.ToString();
                txtNombreMedico.Text = medico.Nombre;
                txtApellidoMedico.Text = medico.Apellido;
                txtEmail.Text = medico.EmailInstitucional;
            }
        }

        private int ObtenerIdMedicoActual()
        {
            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];

                if (usuario.TipoUsuario == TipoUsuario.Medico)
                {
                    return usuario.Id;
                }
            }

            return 0;
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtIdMedico.Text);
                string nombre = txtNombreMedico.Text;
                string apellido = txtApellidoMedico.Text;
                string email = txtEmail.Text;

                Medico medicoModificado = new Medico
                {
                    IDMedico = Id,
                    Nombre = nombre,
                    Apellido = apellido,
                    EmailInstitucional = email,
                };

                medicoNegocio.modificarMedico(medicoModificado);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "swal('Éxito', 'La información se ha editado correctamente', 'success');", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el médico: " + ex.Message);
            }
        }



        protected void limpiarCampos()
        {
            txtIdMedico.Text = string.Empty;
            txtNombreMedico.Text = string.Empty;
            txtApellidoMedico.Text = string.Empty;
            txtLegajo.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }
    }
}