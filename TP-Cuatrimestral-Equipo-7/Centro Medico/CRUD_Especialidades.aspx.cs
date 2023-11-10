using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Web.UI;
using System.Linq;

namespace Centro_Medico
{
    public partial class CRUDEspecialidades : System.Web.UI.Page
    {
        private EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarListaEspecialidades();
            }
        }

        protected void cargarListaEspecialidades()
        {
            try
            {
                List<Especialidad> lista = especialidadNegocio.listar();
                dgvEspecialidades.DataSource = lista;
                dgvEspecialidades.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de especialidades: " + ex.Message);
            }
        }

        protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvEspecialidades.SelectedRow;
                tbId.Text = row.Cells[1].Text;
                tbNombre.Text = row.Cells[2].Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar la especialidad: " + ex.Message);
            }
        }

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
    }
}
