using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Centro_Medico
{
    public partial class CRUD_Horarios : System.Web.UI.Page
    {

        private HorarioNegocio horarioNegocio = new HorarioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsUserAuthenticated())
                {

                    Response.Redirect("~/Login.aspx");
                    return;
                }

                cargarListaHorarios();
            }
        }

        private bool IsUserAuthenticated()
        {
            return Session["usuario"] != null;
        }


        protected void cargarListaHorarios()
        {
            try
            {
                List<Horario> lista = horarioNegocio.listar();
                dgvHorarios.DataSource = lista;
                dgvHorarios.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de especialidades: " + ex.Message);
            }
        }

        protected void dgvHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvHorarios.SelectedRow;
                txtIDHorario.Text = row.Cells[1].Text;

                if (TimeSpan.TryParse(row.Cells[2].Text, out TimeSpan horaInicio))
                {
                    txtHoraInicio.Text = horaInicio.ToString("hh\\:mm\\:ss");
                }

                if (TimeSpan.TryParse(row.Cells[3].Text, out TimeSpan horaFin))
                {
                    txtHoraFin.Text = horaFin.ToString("hh\\:mm\\:ss");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar el horario: " + ex.Message);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                int idHorario = Convert.ToInt32(txtIDHorario.Text);
                horarioNegocio.eliminarHorario(idHorario);
                cargarListaHorarios();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el horario: " + ex.Message);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan tiempoInicio = new TimeSpan(0, 0, 0);
                TimeSpan tiempoFin = new TimeSpan(0, 0, 0);  

                DateTime nuevoHorarioInicio = DateTime.Today.Add(tiempoInicio);
                DateTime nuevoHorarioFin = DateTime.Today.Add(tiempoFin);

                string horaInicioText = txtHoraInicio.Text;
                DateTime.TryParse(horaInicioText, out DateTime horaInicio);


                string horaFinText = txtHoraFin.Text;
                DateTime.TryParse(horaFinText, out DateTime horaFin);

                if (!existeHorario(nuevoHorarioInicio.TimeOfDay, nuevoHorarioFin.TimeOfDay))
                {
                    horarioNegocio.agregarHorario(nuevoHorarioInicio,nuevoHorarioFin);
                    cargarListaHorarios();
                    limpiarCampos();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('El horario ya existe en la lista, o el campo esta vacio');", true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el horario: " + ex.Message);
            }
        }

        private bool existeHorario(TimeSpan horaInicio, TimeSpan horaFin)
        {
            List<Horario> lista = horarioNegocio.listar();

            return lista.Any(e => e.HoraInicio == horaInicio && e.HoraFin == horaFin);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int idHorario = Convert.ToInt32(txtIDHorario.Text);
                TimeSpan tiempoInicio = new TimeSpan(0, 0, 0);
                TimeSpan tiempoFin = new TimeSpan(0, 0, 0);

                string horaInicioText = txtHoraInicio.Text;
                string horaFinText = txtHoraFin.Text;

                if (TimeSpan.TryParse(horaInicioText, out TimeSpan horaInicio) && TimeSpan.TryParse(horaFinText, out TimeSpan horaFin))
                {
                    Horario horarioEditado = new Horario
                    {
                        IDHorario = idHorario,
                        HoraInicio = horaInicio,
                        HoraFin = horaFin
                    };

                    horarioNegocio.modificarHorario(horarioEditado);

                    cargarListaHorarios();
                    limpiarCampos();
                }
                else
                {
                    
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Formato de hora no válido');", true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el horario: " + ex.Message);
            }
        }

        protected void limpiarCampos()
        {
            txtIDHorario.Text = string.Empty;
            txtHoraInicio.Text = string.Empty;
            txtHoraFin.Text = string.Empty;
        }

    }
}