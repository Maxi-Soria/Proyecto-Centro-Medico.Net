using System;
using System.Data;
using negocio;
using System.Web.UI;
using dominio;

namespace Centro_Medico
{
    public partial class AgendaMedico : Page
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


                    datos.setearConsulta(@"
    SELECT T.IDTurno,
           DAY(T.Fecha) AS Día,
           MONTH(T.Fecha) AS MES,
           (P.Apellido + ', ' + P.Nombre) as Nombre,
           H.HoraInicio as Horario
    FROM Turnos T
    INNER JOIN Pacientes P ON P.IDUsuario = T.IDUsuario
    INNER JOIN Horarios H ON H.IDHorario = T.IDHorario
    INNER JOIN Medicos M ON M.IDMedico = T.IDMedico
    INNER JOIN Usuarios U ON U.Id = M.IDUsuario
    WHERE T.IDMedico = M.IDMedico
    AND U.Id = @IDUsuario
    AND Fecha >= GETDATE()
");
                    datos.setearParametro("@IDUsuario", idMedicoActual);
                    datos.ejecutarLectura();

                    DataTable dtAgenda = new DataTable();
                    dtAgenda.Load(datos.Lector);

                    GridViewAgenda.DataSource = dtAgenda;
                    GridViewAgenda.DataBind();
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
    }
}