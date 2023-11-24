using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using negocio;
using dominio;

namespace Centro_Medico
{
    public partial class Paciente_TurnoManual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsUserAuthenticated())
                {

                    Response.Redirect("~/Login.aspx");
                    return;
                }
                CargarEspecialidades();
                calendario.SelectedDate = DateTime.Today;
            }
        }
        private bool IsUserAuthenticated()
        {
            return Session["usuario"] != null;
        }




        private List<Paciente> ObtenerListaPacientes()
        {

            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            List<Paciente> listaPacientes = pacienteNegocio.listar();

            return listaPacientes;
        }

        

        private void CargarEspecialidades()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre FROM Especialidades");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ListItem listItem = new ListItem(datos.Lector["Nombre"].ToString(), datos.Lector["Id"].ToString());
                    ddlEspecialidad.Items.Add(listItem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMedicosPorEspecialidad(Convert.ToInt32(ddlEspecialidad.SelectedValue));
        }

        private void CargarMedicosPorEspecialidad(int idEspecialidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT M.IDMedico, M.Nombre + ' ' + M.Apellido as NombreCompleto " +
                                     "FROM Medicos M " +
                                     "JOIN Especialidades_x_Medico EM ON M.IDMedico = EM.IDMedico " +
                                     "WHERE EM.IDEspecialidad = @ID");
                datos.setearParametro("@ID", idEspecialidad);
                datos.ejecutarLectura();

                ddlMedicos.Items.Clear();

                while (datos.Lector.Read())
                {
                    ListItem listItem = new ListItem(datos.Lector["NombreCompleto"].ToString(), datos.Lector["IDMedico"].ToString());
                    ddlMedicos.Items.Add(listItem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void calendario_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = calendario.SelectedDate;

            if (fechaSeleccionada >= SqlDateTime.MinValue.Value && fechaSeleccionada <= SqlDateTime.MaxValue.Value)
            {
                txtFechaSeleccionada.Text = fechaSeleccionada.ToShortDateString();
                CargarHorariosDisponibles(fechaSeleccionada);
            }
            else
            {
                
                DateTime fechaActual = DateTime.Today;
                calendario.SelectedDate = fechaActual;
                txtFechaSeleccionada.Text = fechaActual.ToShortDateString();
                CargarHorariosDisponibles(fechaActual);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'La fecha seleccionada está fuera del rango permitido.', 'error');", true);
            }
        }


        private void CargarHorariosDisponibles(DateTime fechaSeleccionada)
        {
            CargarHorariosPorMedico(fechaSeleccionada);
        }

        private List<string> ObtenerHorariosDisponibles(DateTime fecha)
        {
            List<string> horariosDisponibles = new List<string>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT HoraInicio FROM Horarios WHERE NOT EXISTS (SELECT 1 FROM Turnos WHERE Turnos.Fecha = @Fecha AND Horarios.IDHorario = Turnos.IDHorario)");
                accesoDatos.setearParametro("@Fecha", fecha);

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    horariosDisponibles.Add(accesoDatos.Lector["HoraInicio"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

            return horariosDisponibles;
        }


        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuRecepcionista.aspx");
        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaSeleccionada = Convert.ToDateTime(txtFechaSeleccionada.Text);

                if (fechaSeleccionada < DateTime.Today)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'No se pueden registrar turnos en fechas anteriores al día actual.', 'error');", true);
                    return;
                }

                int idMedico = Convert.ToInt32(ddlMedicos.SelectedValue);
                DateTime fecha = Convert.ToDateTime(txtFechaSeleccionada.Text);
                int idUsuario = ViewState["IDUsuarioSeleccionado"] != null ? Convert.ToInt32(ViewState["IDUsuarioSeleccionado"]) : 0;
                
                string horarioSeleccionado = ddlHorarios.SelectedValue;
                int idHorario = ObtenerIDHorario(horarioSeleccionado);

              
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDNI.Text) || string.IsNullOrEmpty(txtEmail.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'Complete todos los campos antes de confirmar el turno.', 'error');", true);
                    return;
                }

                

                if (string.IsNullOrEmpty(ddlHorarios.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'Seleccione un horario antes de confirmar el turno.', 'error');", true);
                    return;
                }




                InsertarTurnoManual(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtDNI.Text, idMedico, fecha, idHorario
);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Turno confirmado', 'El turno se ha registrado exitosamente.', 'success');", true);
                LimpiarDropDownLists();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'Error al confirmar el turno: " + ex.Message + "', 'error');", true);
            }
        }

        private int ObtenerIDHorario(string horario)
        {

            int idHorario = 0;
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT IDHorario FROM Horarios WHERE HoraInicio = @HoraInicio");
            datos.setearParametro("@HoraInicio", horario);

            try
            {
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    idHorario = Convert.ToInt32(datos.Lector["IDHorario"]);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }

            return idHorario;
        }

        private void InsertarTurnoManual(string nombre, string apellido, string email, string dni, int idMedico, DateTime fecha, int idHorario)
        {
            AccesoDatos datos = new AccesoDatos();

            
            if (ExisteTurnoParaMedicoEnFechaHora(idMedico, fecha, idHorario))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'Ya existe un turno para ese médico, horario y fecha.', 'error');", true);
                return;
            }

            string consultaTurnosManuales = "INSERT INTO TurnosManuales (NombrePaciente, ApellidoPaciente, EmailPaciente, DNIPaciente, IDMedico, Fecha, IDHorario) VALUES (@NombrePaciente, @ApellidoPaciente, @EmailPaciente, @DNIPaciente, @IDMedico, @Fecha, @IDHorario)";
            string consultaTurnos = "INSERT INTO Turnos (IDMedico, Fecha, IDHorario, IDUsuario) VALUES (@IDMedico2, @Fecha2, @IDHorario2, 0)";

            try
            {
                datos.setearConsulta(consultaTurnosManuales);
                datos.setearParametro("@NombrePaciente", nombre);
                datos.setearParametro("@ApellidoPaciente", apellido);
                datos.setearParametro("@EmailPaciente", email);
                datos.setearParametro("@DNIPaciente", dni);
                datos.setearParametro("@IDMedico", idMedico);
                datos.setearParametro("@Fecha", fecha);
                datos.setearParametro("@IDHorario", idHorario);

                datos.ejecutarAccion();

                datos.setearConsulta(consultaTurnos);
                datos.setearParametro("@IDMedico2", idMedico);
                datos.setearParametro("@Fecha2", fecha);
                datos.setearParametro("@IDHorario2", idHorario);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

         }

        private bool ExisteTurnoParaMedicoEnFechaHora(int idMedico, DateTime fecha, int idHorario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Turnos WHERE IDMedico = @IDMedico AND Fecha = @Fecha AND IDHorario = @IDHorario");
                datos.setearParametro("@IDMedico", idMedico);
                datos.setearParametro("@Fecha", fecha);
                datos.setearParametro("@IDHorario", idHorario);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidadTurnos = Convert.ToInt32(datos.Lector[0]);
                    return cantidadTurnos > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlMedicos.SelectedValue))
            {
                if (calendario.SelectedDate != DateTime.MinValue)
                {
                    CargarHorariosPorMedico(calendario.SelectedDate);
                }
                else
                {
                    calendario.SelectedDate = DateTime.Today;
                }
            }
        }

        private void CargarHorariosPorMedico(DateTime fechaSeleccionada)
        {
            if (!string.IsNullOrEmpty(ddlMedicos.SelectedValue))
            {
                int idMedico = Convert.ToInt32(ddlMedicos.SelectedValue);
                List<string> horariosDisponibles = ObtenerHorariosDisponiblesPorMedico(fechaSeleccionada, idMedico);

                ddlHorarios.Items.Clear();
                foreach (string horario in horariosDisponibles)
                {
                    ddlHorarios.Items.Add(new ListItem(horario, horario));
                }
            }
        }

        private void CargarHorariosDisponibles(DateTime fechaSeleccionada, int idMedico)
        {
            List<string> horariosDisponibles = ObtenerHorariosDisponiblesPorMedico(fechaSeleccionada, idMedico);

            ddlHorarios.Items.Clear();

            foreach (string horario in horariosDisponibles)
            {
                ddlHorarios.Items.Add(new ListItem(horario, horario));
            }
        }

        private List<string> ObtenerHorariosDisponiblesPorMedico(DateTime fecha, int idMedico)
        {
            List<string> horariosDisponibles = new List<string>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {

                DateTime ahora = DateTime.Now;
                accesoDatos.setearConsulta("SELECT H.HoraInicio " +
                                           "FROM Horarios_x_Medico HM " +
                                           "INNER JOIN Horarios H ON HM.IDHorario = H.IDHorario " +
                                           "WHERE HM.IDMedico = @IDMedico " +
                                           "AND NOT EXISTS (SELECT 1 FROM Turnos T WHERE T.Fecha = @Fecha AND T.IDHorario = H.IDHorario AND T.IDMedico = @IDMedico)");
                accesoDatos.setearParametro("@IDMedico", idMedico);
                accesoDatos.setearParametro("@Fecha", fecha);

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    string horaInicio = accesoDatos.Lector["HoraInicio"].ToString();
                    DateTime fechaYHoraInicio = fecha.Date + DateTime.Parse(horaInicio).TimeOfDay;


                    if (fechaYHoraInicio > ahora)
                    {
                        horariosDisponibles.Add(horaInicio);
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

            return horariosDisponibles;
        }

        private bool EsHorarioMayorQueActual(string hora, DateTime horaActual)
        {
            DateTime horaInicio = DateTime.Parse(hora);
            return horaInicio > horaActual;
        }

        private bool ExisteTurnoParaPacienteEnFechaHora(int idPaciente, DateTime fecha, int idHorario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Turnos WHERE IDUsuario = @IDUsuario AND Fecha = @Fecha AND IDHorario = @IDHorario");
                datos.setearParametro("@IDUsuario", idPaciente);
                datos.setearParametro("@Fecha", fecha);
                datos.setearParametro("@IDHorario", idHorario);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidadTurnos = Convert.ToInt32(datos.Lector[0]);
                    return cantidadTurnos > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private void LimpiarDropDownLists()
        {
            ddlEspecialidad.SelectedIndex = -1;
            ddlMedicos.Items.Clear();
            ddlHorarios.Items.Clear();
            calendario.SelectedDate = DateTime.Today;
            txtFechaSeleccionada.Text = string.Empty;
        }
    }
}