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
                CargarEspecialidades();
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

            List<string> horariosDisponibles = ObtenerHorariosDisponibles(fechaSeleccionada);

            ddlHorarios.Items.Clear();

            foreach (string horario in horariosDisponibles)
            {
                ddlHorarios.Items.Add(new ListItem(horario, horario));
            }
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
                int idUsuario = 1; // FORZADO
                int estado = 0; // FORZADO
                string horarioSeleccionado = ddlHorarios.SelectedValue;
                int idHorario = ObtenerIDHorario(horarioSeleccionado);

                AccesoDatos datos = new AccesoDatos();
                          
                    string consulta = "INSERT INTO Turnos (IDMedico, IDUsuario, Estado, Fecha, IDHorario) VALUES (@IDMedico, @IDUsuario, @Estado, @Fecha, @IDHorario)";

                    datos.setearConsulta(consulta);
                    datos.setearParametro("@IDMedico", idMedico);
                    datos.setearParametro("@IDUsuario", idUsuario);
                    datos.setearParametro("@Estado", estado);
                    datos.setearParametro("@Fecha", fecha);
                    datos.setearParametro("@IDHorario", idHorario);

                    
                    datos.ejecutarAccion();
                

                
                Response.Write("Turno confirmado exitosamente."); 
            }
            catch (Exception ex)
            {
                
                Response.Write("Error al confirmar el turno: " + ex.Message); 
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

    }
}