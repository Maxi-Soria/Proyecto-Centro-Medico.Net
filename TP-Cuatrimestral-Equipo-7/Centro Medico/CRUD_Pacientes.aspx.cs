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

        }
    }
}