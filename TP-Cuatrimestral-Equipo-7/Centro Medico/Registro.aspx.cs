using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Centro_Medico
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            calFechaNacimiento.SelectedDate = DateTime.Today;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Value;
                string apellido = txtApellido.Value;
                int dni = Convert.ToInt32(txtDNI.Value);
                string email = txtEmail.Value;
                DateTime fechaNacimiento = calFechaNacimiento.SelectedDate;
                string domicilio = txtDomicilio.Value;
                string telefono = txtTelefono.Value;
                string usuario = txtUser.Value;

                PacienteNegocio pacienteNegocio = new PacienteNegocio();

                if (pacienteNegocio.verificarExistenciaDNI(dni))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'El paciente ya existe.', 'error');", true);
                    return;
                }

                if (pacienteNegocio.verificarExistenciaUsuario(usuario))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'El usuario ya existe.', 'error');", true);
                    return;
                }



                AccesoDatos datos = new AccesoDatos();
                
                    
                    string consultaUsuario = "INSERT INTO Usuarios (Usuario, Pass, TipoUser, Email) " +
                                            "VALUES (@Usuario, @Pass, @TipoUser, @Email); " +
                                            "SELECT SCOPE_IDENTITY();";

                    datos.setearConsulta(consultaUsuario);
                    datos.setearParametro("@Usuario", txtUser.Value);
                    datos.setearParametro("@Pass", txtPassword.Value);
                    datos.setearParametro("@TipoUser", 4);
                    datos.setearParametro("@Email", email);

                    int idUsuario = Convert.ToInt32(datos.ejecutarScalar());


                
                string consultaPaciente = "INSERT INTO Pacientes (DNI, Nombre, Apellido, Email, FechaNacimiento, Domicilio, NumeroTelefonico, IDUsuario) " +
                                          "VALUES (@DNI, @Nombre, @Apellido, @EmailPaciente, @FechaNacimiento, @Domicilio, @NumeroTelefonico, @IDUsuario)";

                datos.setearConsulta(consultaPaciente);
                    datos.setearParametro("@DNI", dni);
                    datos.setearParametro("@Nombre", nombre);
                    datos.setearParametro("@Apellido", apellido);
                    datos.setearParametro("@EmailPaciente", email);
                    datos.setearParametro("@FechaNacimiento", fechaNacimiento);
                    datos.setearParametro("@Domicilio", domicilio);
                    datos.setearParametro("@NumeroTelefonico", telefono);
                    datos.setearParametro("@IDUsuario", idUsuario);

                    datos.ejecutarAccion();
                

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Éxito', 'Paciente registrado correctamente.', 'success');", true);
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"Swal.fire('Error', 'Error de SQL: {sqlEx.Message}', 'error');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"Swal.fire('Error', 'Error general: {ex.Message}', 'error');", true);
            }
        }
    }
}