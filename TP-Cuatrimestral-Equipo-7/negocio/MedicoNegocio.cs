using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MedicoNegocio
    {
        public List<Medico> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Medico> lista = new List<Medico>();

            try
            {
                datos.setearConsulta("SELECT IDMedico, Legajo, Nombre, Apellido, Email FROM Medicos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.IDMedico = (int)datos.Lector["IDMedico"];
                    aux.Legajo = (int)datos.Lector["Legajo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.EmailInstitucional = (string)datos.Lector["Email"];

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

        public void agregarMedico(Medico nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Medicos VALUES ('" + nuevo.Legajo + "', '" + nuevo.Nombre + "', '" + nuevo.Apellido + "', '" + nuevo.EmailInstitucional + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void modificarMedico(Medico medico)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Medicos SET Legajo = @Legajo, Nombre = @Nombre, Apellido = @Apellido, Email = @Email WHERE IDMedico = @IDMedico");

                datos.setearParametro("@Legajo", medico.Legajo);
                datos.setearParametro("@Nombre", medico.Nombre);
                datos.setearParametro("@Apellido", medico.Apellido);
                datos.setearParametro("@Email", medico.EmailInstitucional);
                datos.setearParametro("@IDMedico", medico.IDMedico);

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
        
        public void eliminarMedico(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Medicos WHERE IDMedico = @IDMedico");
                datos.setearParametro("@IDMedico", id);
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

        public List<Especialidad> obtenerEspecialidadesDeMedico(int idMedico)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                datos.setearConsulta("SELECT E.Id, E.Nombre FROM Especialidades E INNER JOIN Especialidades_x_Medico EM ON E.IDEspecialidad = EM.IDEspecialidad WHERE EM.IDMedico = @IDMedico");
                datos.setearParametro("@IDMedico", idMedico);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad especialidad = new Especialidad
                    {
                        Id = (int)datos.Lector["IDEspecialidad"],
                        Nombre = (string)datos.Lector["Nombre"]
                    };

                    especialidades.Add(especialidad);
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

            return especialidades;
        }

    }
}
