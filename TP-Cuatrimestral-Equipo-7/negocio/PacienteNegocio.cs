using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class PacienteNegocio
    {
        public List<Paciente> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Paciente> lista = new List<Paciente>();

            try
            {
                datos.setearConsulta("SELECT IDUsuario, DNI, Nombre, Apellido, Email, FechaNacimiento, Domicilio, NumeroTelefonico  FROM Pacientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.ID = (int)datos.Lector["IDUsuario"];
                    aux.Dni = (int)datos.Lector["DNI"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.EmailPersonal = (string)datos.Lector["Email"];
                    aux.FechaDeNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.Domicilio = (String)datos.Lector["Domicilio"];
                    aux.NumeroTelefonico = (string)datos.Lector["NumeroTelefonico"];

                    lista.Add(aux);
                }

                return lista;
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

        public Paciente listarUnPaciente(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.setearConsulta("SELECT IDUsuario, DNI, Nombre, Apellido, Email, FechaNacimiento, Domicilio, NumeroTelefonico  FROM Pacientes WHERE IDUsuario = @IDUsuario");

                datos.ejecutarLectura();
                Paciente aux = new Paciente();
                datos.setearParametro("@IDUsuario", id);

                while (datos.Lector.Read())
                {
                    
                    aux.ID = (int)datos.Lector["IDUsuario"];
                    aux.Dni = (int)datos.Lector["DNI"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.EmailPersonal = (string)datos.Lector["Email"];
                    aux.FechaDeNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.Domicilio = (String)datos.Lector["Domicilio"];
                    aux.NumeroTelefonico = (string)datos.Lector["NumeroTelefonico"];

                    
                }

                return aux;
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



        public void agregarPaciente(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Pacientes VALUES ('" + nuevo.Dni + "', '" + nuevo.Nombre + "', '" + nuevo.Apellido + "', '" + nuevo.EmailPersonal + "', '" + nuevo.FechaDeNacimiento.ToString("yyyy-MM-dd") + "', '" + nuevo.Domicilio + "', '" + nuevo.NumeroTelefonico + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        //--------------------------------------------------------------------------------

        public void modificarPaciente(Paciente paciente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Pacientes SET DNI = @Dni, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, FechaNacimiento = @FechaNacimiento, Domicilio = @Domicilio, NumeroTelefonico = @NumeroTelefonico WHERE IDUsuario = @Id");

                datos.setearParametro("@Dni", paciente.Dni);
                datos.setearParametro("@Nombre", paciente.Nombre);
                datos.setearParametro("@Apellido", paciente.Apellido);
                datos.setearParametro("@Email", paciente.EmailPersonal);
                datos.setearParametro("@FechaNacimiento", paciente.FechaDeNacimiento);
                datos.setearParametro("@Domicilio", paciente.Domicilio);
                datos.setearParametro("@NumeroTelefonico", paciente.NumeroTelefonico);
                datos.setearParametro("@Id", paciente.ID);

                datos.ejecutarAccion();
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

        //---------------------------------------------------------------------------------
        public void eliminarPaciente(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Pacientes WHERE IDUsuario = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
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

        public bool verificarExistenciaDNI(int dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
               
                string consulta = "SELECT COUNT(*) FROM Pacientes WHERE DNI = @DNI";
                datos.setearConsulta(consulta);
                datos.setearParametro("@DNI", dni);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = Convert.ToInt32(datos.Lector[0]);
                    return cantidad > 0; 
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

        public bool verificarExistenciaUsuario(string usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Usuario", usuario);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = Convert.ToInt32(datos.Lector[0]);
                    return cantidad > 0;
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

    }
}
