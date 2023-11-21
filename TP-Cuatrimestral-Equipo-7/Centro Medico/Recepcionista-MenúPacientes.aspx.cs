using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Centro_Medico
{
    public partial class Recepcionista_MenúPacientes : System.Web.UI.Page
    {
        private PacienteNegocio pacienteNegocio = new PacienteNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarListaPacientes();
            }
        }

        protected void cargarListaPacientes()
        {
            try
            {
                List<Paciente> lista = pacienteNegocio.listar();
                dgvPacientes.DataSource = lista;
                dgvPacientes.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de pacientes: " + ex.Message);
            }

        }

        protected void dgvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvPacientes.SelectedRow;
                txtIdPaciente.Text = row.Cells[1].Text;
                txtDniPaciente.Text = row.Cells[2].Text;
                txtNombrePaciente.Text = row.Cells[3].Text;
                txtApellidoPaciente.Text = row.Cells[4].Text;
                txtEmail.Text = row.Cells[5].Text;

                
                DateTime fechaNacimiento;
                if (DateTime.TryParseExact(row.Cells[6].Text, "dd/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
                {
                    
                    txtFechaNacimiento.Text = fechaNacimiento.ToString("yyyy-MM-dd");
                }
                else
                {
                    
                    txtFechaNacimiento.Text = "Fecha inválida";
                }

                txtDireccion.Text = row.Cells[7].Text;
                txtTelefono.Text = row.Cells[8].Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar un paciente: " + ex.Message);
                
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paciente nuevo = new Paciente();
                nuevo.Dni = int.Parse(txtDniPaciente.Text);
                nuevo.Nombre = txtNombrePaciente.Text;
                nuevo.Apellido = txtApellidoPaciente.Text;
                nuevo.EmailPersonal = txtEmail.Text;
                nuevo.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                nuevo.Domicilio = txtDireccion.Text;
                nuevo.NumeroTelefonico = txtTelefono.Text;

                pacienteNegocio.agregarPaciente(nuevo);
                limpiarCampos();

               
                cargarListaPacientes();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el paciente: " + ex.Message);
                
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error al agregar el paciente');", true);
            }
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

                
                cargarListaPacientes();

                
                limpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el paciente: " + ex.Message);
                
            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPaciente = Convert.ToInt32(txtIdPaciente.Text);
                pacienteNegocio.eliminarPaciente(idPaciente);
                cargarListaPacientes();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el paciente: " + ex.Message);
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