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
        MedicoNegocio mediconegocio = new MedicoNegocio();
        HorarioNegocio horarioNegocio = new HorarioNegocio();
        PacienteNegocio pacienteNegocio = new PacienteNegocio();


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

        public List<int> ObtenerIDsHorariosDisponibles(int idMedico, DateTime fechaTurno)
        {
            TurnoNegocio turnosNegocio = new TurnoNegocio();
            List<Turno> listaTurnos = turnosNegocio.listar();

            Horarios_x_MedicoNegocio HxMnegocio = new Horarios_x_MedicoNegocio();
            List<Horarios_x_Medico> listaExM = HxMnegocio.listar();

            List<int> HorariosDisponibles = listaExM
                .Where(horario => horario.IDMedico == idMedico)
                .Select(horario => horario.IDHorario)
                .ToList();


            List<int> horariosOcupadosEnTurnos = listaTurnos
                .Where(turno => turno.IDMedico == idMedico && turno.Fecha_Horario_Entrada.Date == fechaTurno.Date)
                .Select(turno => turno.IDHorario)
                .ToList();

            HorariosDisponibles = HorariosDisponibles.Except(horariosOcupadosEnTurnos).ToList();

            return HorariosDisponibles;
        }

        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Medico> listaMedicos = mediconegocio.listar();
            List<Paciente> listaPacientes = pacienteNegocio.listar();
            try
            {
                GridViewRow row = dgvTurnos.SelectedRow;

                txtIdTurno.Text = row.Cells[1].Text;
                txtIdMedico.Text = row.Cells[2].Text;
                txtIdUsuario.Text = row.Cells[3].Text;
                txtFecha.Text = DateTime.Parse(row.Cells[4].Text).ToString("yyyy-MM-dd");
                txtObservaciones.Text = row.Cells[6].Text;
                txtEstado.Text = row.Cells[7].Text;

                int idMedicoSeleccionado = Convert.ToInt32(row.Cells[2].Text);
                int idPacienteSeleccionado = Convert.ToInt32(row.Cells[3].Text);
                DateTime fechaTurno = DateTime.Parse(row.Cells[4].Text);

                // Buscar el legajo del médico correspondiente al ID seleccionado en la lista de médicos
                Medico medicoSeleccionado = listaMedicos.FirstOrDefault(m => m.IDMedico == idMedicoSeleccionado);
                Paciente pacienteSeleccionado = listaPacientes.FirstOrDefault(p => p.ID == idPacienteSeleccionado);

                txtLegajoMedico.Text = medicoSeleccionado.Legajo.ToString() + " - " + medicoSeleccionado.Nombre + " " + medicoSeleccionado.Apellido;

                txtDniPaciente.Text = pacienteSeleccionado.Dni.ToString() + " - " + pacienteSeleccionado.Nombre + " " + pacienteSeleccionado.Apellido;


                List<int> idsHorariosDisponibles = ObtenerIDsHorariosDisponibles(idMedicoSeleccionado, fechaTurno);

                // Obtener los objetos Horario correspondientes a los IDs disponibles
                List<Horario> horariosDisponibles = ObtenerHorariosPorIDs(idsHorariosDisponibles);

                // Cargar el DropDownList con los horarios de inicio disponibles
                ddlHorarios.DataSource = horariosDisponibles.Select(h => h.HoraInicio.ToString(@"hh\:mm"));
                ddlHorarios.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar un turno: " + ex.Message);
            }
        }


        private List<Horario> ObtenerHorariosPorIDs(List<int> idsHorarios)
        {
            List<Horario> listaHorarios = horarioNegocio.listar();

            // Filtrar la lista de horarios por los IDs proporcionados
            return listaHorarios.Where(h => idsHorarios.Contains(h.IDHorario)).ToList();
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Turnos.aspx");
        }

        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            try
            {

                int idMedicoSeleccionado = Convert.ToInt32(txtIdMedico.Text);
                DateTime fechaSeleccionada = DateTime.Parse(txtFecha.Text);

                List<int> idsHorariosDisponibles = ObtenerIDsHorariosDisponibles(idMedicoSeleccionado, fechaSeleccionada);


                List<Horario> horariosDisponibles = ObtenerHorariosPorIDs(idsHorariosDisponibles);

                ddlHorarios.DataSource = horariosDisponibles.Select(h => h.HoraInicio.ToString(@"hh\:mm"));
                ddlHorarios.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cambiar la fecha: " + ex.Message);
            }
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {
            List<Horario> listaHorarios = horarioNegocio.listar();
            try
            {
                int idTurno = Convert.ToInt32(txtIdTurno.Text);

                int idUsuario = int.Parse(txtIdUsuario.Text);
                string estado = txtEstado.Text;

                // Obtener el horario seleccionado en el DropDownList
                string horaInicioSeleccionada = ddlHorarios.SelectedValue;

                // Obtener el IDHorario correspondiente al horario seleccionado
                int idHorarioSeleccionado = listaHorarios.FirstOrDefault(h => h.HoraInicio.ToString(@"hh\:mm") == horaInicioSeleccionada)?.IDHorario ?? -1;

                Turno turnoModificado = new Turno
                {
                    IDTurno = idTurno,
                    IDMedico = int.Parse(txtIdMedico.Text), // Se mantiene el ID del médico si es necesario para otro propósito
                    Fecha_Horario_Entrada = DateTime.ParseExact(txtFecha.Text, "yyyy-MM-dd", null),
                    Observaciones = txtObservaciones.Text,
                    IDHorario = idHorarioSeleccionado,
                    IDUsuario = idUsuario,
                    Estado = estado
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
            ddlHorarios.ClearSelection();
            txtIdUsuario.Text = string.Empty;
            txtEstado.Text = string.Empty;
        }


    }
}