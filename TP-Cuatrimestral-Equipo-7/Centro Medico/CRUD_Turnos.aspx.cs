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
    public partial class CRUD_Turnos : System.Web.UI.Page
    {
        
        TurnoNegocio turnoNegocio = new TurnoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsUserAuthenticated())
                {

                    Response.Redirect("~/Login.aspx");
                    return;
                }
                CargarListaTurnos();
            }
        }

        private bool IsUserAuthenticated()
        {
            return Session["usuario"] != null;
        }


        protected void CargarListaTurnos()
        {
            try
            {
            
                List<Turno> lista = turnoNegocio.listar();

                
                dgvTurnos.DataSource = lista;
                dgvTurnos.DataBind();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al cargar la lista de turnos: " + ex.Message);
            }
        }

        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvTurnos.SelectedRow;

                txtIdTurno.Text = row.Cells[1].Text;
                txtIdMedico.Text = row.Cells[2].Text;
                
                txtFecha.Text = DateTime.Parse(row.Cells[3].Text).ToString("yyyy/dd/MM");
                txtObservaciones.Text = row.Cells[4].Text;
                txtIdHorario.Text = row.Cells[5].Text;
                txtIdUsuario.Text = row.Cells[6].Text;
                txtEstado.Text = row.Cells[7].Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar un turno: " + ex.Message);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
             
                Turno nuevoTurno = new Turno
                {
                    IDMedico = int.Parse(txtIdMedico.Text),
                    Fecha_Horario_Entrada = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null), 
                    Observaciones = txtObservaciones.Text,
                    IDHorario = int.Parse(txtIdHorario.Text),
                    IDUsuario = int.Parse(txtIdUsuario.Text),
                    Estado = txtEstado.Text
                };

                
                turnoNegocio.agregarTurno(nuevoTurno);

              
                LimpiarCampos();

                
                CargarListaTurnos();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al agregar el turno: " + ex.Message);
            }
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int idTurno = Convert.ToInt32(txtIdTurno.Text);

                Turno turnoModificado = new Turno
                {
                    IDTurno = idTurno,
                    IDMedico = int.Parse(txtIdMedico.Text),
                    Fecha_Horario_Entrada = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null),
                    Observaciones = txtObservaciones.Text,
                    IDHorario = int.Parse(txtIdHorario.Text),
                    IDUsuario = int.Parse(txtIdUsuario.Text),
                    Estado = txtEstado.Text
                };

                
                turnoNegocio.modificarTurno(turnoModificado);

              
                CargarListaTurnos();

                
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el turno: " + ex.Message);
               
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idTurno = Convert.ToInt32(txtIdTurno.Text);
                turnoNegocio.cancelarTurno(idTurno);
                CargarListaTurnos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el turno: " + ex.Message);
                
            }
        }



        protected void LimpiarCampos()
        {
            txtIdTurno.Text = string.Empty;
            txtIdMedico.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtIdHorario.Text = string.Empty;
            txtIdUsuario.Text = string.Empty;
            txtEstado.Text = string.Empty;
        }
    }
}