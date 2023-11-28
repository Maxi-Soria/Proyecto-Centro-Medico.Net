using System;
using System.Data;
using negocio;
using dominio;
using System.Web.UI.WebControls;

namespace Centro_Medico
{
    public partial class Médico_Informes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosEnGridView();
                if (!IsUserAuthenticated())
                {
                    Response.Redirect("~/Login.aspx");
                    return;
                }
            }
        }

        private bool IsUserAuthenticated()
        {
            return Session["usuario"] != null;
        }

        private void CargarDatosEnGridView()
        {
            try
            {
                int idMedicoActual = ObtenerIdMedicoActual();

                if (idMedicoActual > 0)
                {
                    AccesoDatos datos = new AccesoDatos();

                    datos.setearConsulta("SELECT T.IDTurno, DAY(T.Fecha) AS Día, MONTH(T.Fecha) AS MES, (P.Apellido + ', ' + P.Nombre) as Nombre, H.HoraInicio as Horario FROM Turnos T INNER JOIN Pacientes P ON P.IDUsuario = T.IDUsuario INNER JOIN Horarios H ON H.IDHorario = T.IDHorario INNER JOIN Medicos M ON M.IDMedico = T.IDMedico WHERE T.IDMedico = M.IDMedico AND Fecha < GETDATE()");
                    datos.ejecutarLectura();

                    DataTable dtTurnos = new DataTable();
                    dtTurnos.Load(datos.Lector);

                    GridViewTurnos.DataSource = dtTurnos;
                    GridViewTurnos.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int ObtenerIdMedicoActual()
        {
            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];

                if (usuario.TipoUsuario == TipoUsuario.Medico)
                {
                    return usuario.Id;
                }
            }

            return 0;
        }

        protected void GridViewTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AgregarObservacion")
            {
                int idTurno = Convert.ToInt32(e.CommandArgument);
                ViewState["IDTurno"] = idTurno;

                ObservacionPanel.Style.Add("display", "block");
            }
        }

        protected void GuardarObservacionButton_Click(object sender, EventArgs e)
        {
            int idTurno = Convert.ToInt32(ViewState["IDTurno"]);
            string observacion = ObservacionTextBox.Text;

            GuardarObservacionEnBaseDeDatos(idTurno, observacion);

            ObservacionPanel.Style.Add("display", "none");

            CargarDatosEnGridView();
        }

        private void GuardarObservacionEnBaseDeDatos(int idTurno, string observacion)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("UPDATE Turnos SET ObservacionesMedico = @Observacion WHERE IDTurno = @IDTurno");
                datos.setearParametro("@Observacion", observacion);
                datos.setearParametro("@IDTurno", idTurno);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}