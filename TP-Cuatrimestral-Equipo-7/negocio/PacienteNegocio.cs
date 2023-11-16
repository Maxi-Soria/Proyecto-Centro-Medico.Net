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
                datos.setearConsulta("SELECT ID, DNI, Nombre, Apellido, Email, FechaNacimiento, Domicilio, NumeroTelefonico  FROM Pacientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.ID = (int)datos.Lector["ID"];
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

        //--------------------------------------------------

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


    }
}
