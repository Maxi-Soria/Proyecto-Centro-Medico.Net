using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Centro_Medico
{
    public partial class CRUD_Pacientes : System.Web.UI.Page
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
                txtDniPaciente.Text = row.Cells[2].Text;
                txtNombrePaciente.Text = row.Cells[3].Text;
                txtApellidoPaciente.Text = row.Cells[4].Text;
                txtEmail.Text = row.Cells[5].Text;
                txtFechaNacimiento.Text = row.Cells[6].Text;    
                txtDireccion.Text = row.Cells[7].Text;
                txtTelefono.Text = row.Cells[8].Text;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar Un Paciente: " + ex.Message);
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

                // Luego de agregar el paciente, actualiza la lista en el GridView
                cargarListaPacientes();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el paciente: " + ex.Message);
                // Muestra un mensaje de error al usuario
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error al agregar el paciente');", true);
            }
        }



        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void limpiarCampos()
        {
            txtDniPaciente.Text = string.Empty;
            txtNombrePaciente.Text = string.Empty;
            txtApellidoPaciente.Text = string.Empty;
            txtEmail.Text= string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        /*
                 protected void btnEliminar_Click(object sender, EventArgs e)
        {
            
            try
            {
                int idEspecialidad = Convert.ToInt32(tbId.Text);
                especialidadNegocio.eliminarEspecialidad(idEspecialidad);
                cargarListaEspecialidades();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la especialidad: " + ex.Message);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nuevaEspecialidad = "";
                nuevaEspecialidad = tbAgregar.Text;

                if (!existeEspecialidad(nuevaEspecialidad) && nuevaEspecialidad != "")
                {
                    especialidadNegocio.agregarCategoria(nuevaEspecialidad);
                    cargarListaEspecialidades();
                    limpiarCampos();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('La especialidad ya existe en la lista, o el campo esta vacio');", true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar la especialidad: " + ex.Message);
            }
        }

        private bool existeEspecialidad(string especialidad)
        {
            List<Especialidad> lista = especialidadNegocio.listar();

            return lista.Any(e => e.Nombre.Equals(especialidad, StringComparison.OrdinalIgnoreCase));
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                
                int idEspecialidad = Convert.ToInt32(tbId.Text);
                string nuevaNombre = tbNombre.Text;

                
                Especialidad especialidadEditada = new Especialidad
                {
                    Id = idEspecialidad,
                    Nombre = nuevaNombre
                };

                
                especialidadNegocio.modificarEspecialidad(especialidadEditada);

                
                cargarListaEspecialidades();

                
                limpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar la especialidad: " + ex.Message);
            }
        }

        protected void limpiarCampos()
        {
            tbAgregar.Text = string.Empty;
            tbId.Text = string.Empty;
            tbNombre.Text = string.Empty;
        }
        */


    }
}