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
    public partial class Paciente_MiPerfil : System.Web.UI.Page
    {
        private PacienteNegocio pacienteNegocio = new PacienteNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsUserAuthenticated())
                {
                    
                    Response.Redirect("~/Login.aspx");
                    return;
                }

                int idPacienteActual = ObtenerIdPacienteActual();

                if (idPacienteActual > 0)
                {
                    CargarDatosPaciente(idPacienteActual);
                }
            }
        }

        private bool IsUserAuthenticated()
        {
            return Session["usuario"] != null;
        }

        private void CargarDatosPaciente(int idPaciente)
        {
            Paciente paciente = pacienteNegocio.listarUnPaciente(idPaciente);

            if (paciente != null)
            {
                txtIdPaciente.Text = paciente.ID.ToString();
                txtDniPaciente.Text = paciente.Dni.ToString();
                txtNombrePaciente.Text = paciente.Nombre;
                txtApellidoPaciente.Text = paciente.Apellido;
                txtEmail.Text = paciente.EmailPersonal;
                txtFechaNacimiento.Text = paciente.FechaDeNacimiento.ToString("yyyy-MM-dd");
                txtDireccion.Text = paciente.Domicilio;
                txtTelefono.Text = paciente.NumeroTelefonico;
            }
        }

        private int ObtenerIdPacienteActual()
        {
            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];

                if (usuario.TipoUsuario == TipoUsuario.Paciente)
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
                int Id = Convert.ToInt32(txtIdPaciente.Text);
                int dni = Convert.ToInt32(txtDniPaciente.Text);
                string nombre = txtNombrePaciente.Text;
                string apellido = txtApellidoPaciente.Text;
                string email = txtEmail.Text;
                DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                string domicilio = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                Paciente pacienteModificado = new Paciente
                {
                    ID = Id,
                    Dni = dni,
                    Nombre = nombre,
                    Apellido = apellido,
                    EmailPersonal = email,
                    FechaDeNacimiento = fechaNacimiento,
                    Domicilio = domicilio,
                    NumeroTelefonico = telefono
                };

                pacienteNegocio.modificarPaciente(pacienteModificado);
                Console.WriteLine("Paciente modificado correctamente");
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "swal('Éxito', 'La información se ha editado correctamente', 'success');", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el paciente: " + ex.Message);
            }
        }

        

        protected void limpiarCampos()
        {
            txtIdPaciente.Text = string.Empty;
            txtDniPaciente.Text = string.Empty;
            txtNombrePaciente.Text = string.Empty;
            txtApellidoPaciente.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }
    }
}