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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientes();
                CargarEspecialidades();
            }
        }

        private void CargarPacientes()
        {
            
            List<Paciente> listaPacientes = ObtenerListaPacientes();
                     
            gvPacientes.DataSource = listaPacientes;
            gvPacientes.DataBind();
        }

        private List<Paciente> ObtenerListaPacientes()
        {
         
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            List<Paciente> listaPacientes = pacienteNegocio.listar();

            return listaPacientes;
        }

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                
                int index = Convert.ToInt32(e.CommandArgument);

                
                int idUsuario = Convert.ToInt32(gvPacientes.DataKeys[index].Value);

                
                ViewState["IDUsuarioSeleccionado"] = idUsuario;
            }
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
            txtFechaSeleccionada.Text = calendario.SelectedDate.ToShortDateString();

            CargarHorariosDisponibles(calendario.SelectedDate);
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

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
               
                int idMedico = Convert.ToInt32(ddlMedicos.SelectedValue);
                DateTime fecha = Convert.ToDateTime(txtFechaSeleccionada.Text);
                int idUsuario = ViewState["IDUsuarioSeleccionado"] != null ? Convert.ToInt32(ViewState["IDUsuarioSeleccionado"]) : 0;
                int estado = 0;
                string horarioSeleccionado = ddlHorarios.SelectedValue;
                int idHorario = ObtenerIDHorario(horarioSeleccionado);

                if (idUsuario == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'Seleccione un paciente antes de confirmar el turno.', 'error');", true);
                    return;
                }

                if (string.IsNullOrEmpty(ddlHorarios.SelectedValue))
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'Seleccione un horario antes de confirmar el turno.', 'error');", true);
                    return; 
                }

                AccesoDatos datos = new AccesoDatos();
                          
                    string consulta = "INSERT INTO Turnos (IDMedico, IDUsuario, Estado, Fecha, IDHorario) VALUES (@IDMedico, @IDUsuario, @Estado, @Fecha, @IDHorario)";

                    datos.setearConsulta(consulta);
                    datos.setearParametro("@IDMedico", idMedico);
                    datos.setearParametro("@IDUsuario", idUsuario);
                    datos.setearParametro("@Estado", estado);
                    datos.setearParametro("@Fecha", fecha);
                    datos.setearParametro("@IDHorario", idHorario);

                    
                    datos.ejecutarAccion();



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

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlMedicos.SelectedValue))
            {
                CargarHorariosPorMedico(calendario.SelectedDate);
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
                
                accesoDatos.setearConsulta("SELECT H.HoraInicio " +
                                           "FROM Horarios_x_Medico HM " +
                                           "INNER JOIN Horarios H ON HM.IDHorario = H.IDHorario " +
                                           "WHERE HM.IDMedico = @IDMedico " +
                                           "AND NOT EXISTS (SELECT 1 FROM Turnos T WHERE T.Fecha = @Fecha AND T.IDHorario = H.IDHorario)");
                accesoDatos.setearParametro("@IDMedico", idMedico);
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