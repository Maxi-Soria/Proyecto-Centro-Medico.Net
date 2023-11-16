using System;
using System.Data;
using negocio;
using System.Web.UI;
namespace Centro_Medico
{
    public partial class AgendaMedico : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosEnGridView();
            }
        }

        private void CargarDatosEnGridView()
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("SELECT * FROM Turnos WHERE IDMedico = 1");
                datos.ejecutarLectura();

      
                DataTable dtAgenda = new DataTable();
                dtAgenda.Load(datos.Lector);

                GridViewAgenda.DataSource = dtAgenda;
                GridViewAgenda.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
       
        }
    }
}