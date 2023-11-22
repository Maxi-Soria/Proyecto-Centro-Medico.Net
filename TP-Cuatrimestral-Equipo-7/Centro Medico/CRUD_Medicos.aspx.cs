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
    public partial class CRUD_Medicos : System.Web.UI.Page
    {
        MedicoNegocio medicoNegocio = new MedicoNegocio();
        EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();

        Especialidades_X_MedicoNegocio especialidades_X_Medico = new Especialidades_X_MedicoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarListaMedicos();
                
            }
        }

        protected void cargarListaMedicos()
        {
            try
            {
                List<Medico> lista = medicoNegocio.listar();


                dgvMedicos.DataSource = lista;
                dgvMedicos.DataBind();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de medicos: " + ex.Message);
            }

        }

        protected void cargarCheckBoxEspecialidades(int idMedico)
        {
            try
            {
                chkEspecialidades.Items.Clear();

                List<Especialidad_x_Medico> listaEspXMed = especialidades_X_Medico.listar().Where(em => em.IDMedico == idMedico).ToList();

                List<int> especialidadesDelMedico = listaEspXMed.Select(em => em.IDEspecialidad).ToList();

                List<Especialidad> especialidades = especialidadNegocio.listar();

                foreach (Especialidad especialidad in especialidades)
                {
                    ListItem item = new ListItem(especialidad.Nombre, especialidad.Id.ToString());
                    item.Selected = especialidadesDelMedico.Contains(especialidad.Id);
                    chkEspecialidades.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de especialidades: " + ex.Message);
            }
        }




        protected void dgvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                GridViewRow row = dgvMedicos.SelectedRow;

                txtIdMedico.Text = row.Cells[1].Text;
                txtLegajoMedico.Text = row.Cells[2].Text;
                txtNombreMedico.Text = row.Cells[3].Text;
                txtApellidoMedico.Text = row.Cells[4].Text;
                txtEmail.Text = row.Cells[5].Text;

                cargarCheckBoxEspecialidades(Convert.ToInt32(row.Cells[1].Text));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar un medico: " + ex.Message);
        
            }
        
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Medico nuevo = new Medico();
                nuevo.Legajo = int.Parse(txtLegajoMedico.Text);
                nuevo.Nombre = txtNombreMedico.Text;
                nuevo.Apellido = txtApellidoMedico.Text;
                nuevo.EmailInstitucional = txtEmail.Text;

                medicoNegocio.agregarMedico(nuevo);
                limpiarCampos();


                cargarListaMedicos();
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
                int Id = Convert.ToInt32(txtIdMedico.Text);
                int Legajo = Convert.ToInt32(txtLegajoMedico.Text);
                string nombre = txtNombreMedico.Text;
                string apellido = txtApellidoMedico.Text;
                string email = txtEmail.Text;

                Medico medicoModificado = new Medico
                {
                    IDMedico = Id,
                    Legajo = Legajo,
                    Nombre = nombre,
                    Apellido = apellido,
                    EmailInstitucional = email,

                };

               
                medicoNegocio.modificarMedico(medicoModificado);

                
                cargarListaMedicos();

               
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
                int idMedico = Convert.ToInt32(txtIdMedico.Text);
                medicoNegocio.eliminarMedico(idMedico);
                cargarListaMedicos();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el Medico: " + ex.Message);
            }
        }

        protected void limpiarCampos()
        {
            txtIdMedico.Text = string.Empty;
            txtLegajoMedico.Text = string.Empty;
            txtNombreMedico.Text = string.Empty;
            txtApellidoMedico.Text = string.Empty;
            txtEmail.Text = string.Empty;   
        }


    }
}