using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Centro_Medico
{
    public partial class CRUDEspecialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio negocio = new EspecialidadNegocio();
            dgvEspecialidades.DataSource = negocio.listar();
            dgvEspecialidades.DataBind();
        }

        protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (dgvEspecialidades.SelectedRow != null)
            {
                
                string id = dgvEspecialidades.SelectedRow.Cells[1].Text; 
                string nombre = dgvEspecialidades.SelectedRow.Cells[2].Text; 

                
                tbId.Text = id;
                tbNombre.Text = nombre;
            }
        }

        

    }
}