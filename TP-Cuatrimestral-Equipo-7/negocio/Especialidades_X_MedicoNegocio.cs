using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Especialidades_X_MedicoNegocio
    {
        public List<Especialidad_x_Medico> listar()
        {
            
            AccesoDatos datos = new AccesoDatos();
            List<Especialidad_x_Medico> lista = new List<Especialidad_x_Medico>();

            try
            {
                datos.setearConsulta("SELECT IDEspecialidad, IDMedico FROM Especialidades_x_Medico");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad_x_Medico aux = new Especialidad_x_Medico();
                    aux.IDEspecialidad = (int)datos.Lector["IDEspecialidad"];
                    aux.IDMedico = (int)datos.Lector["IDMedico"];

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

        public void agregarEspecialidad_x_Medico(Especialidad_x_Medico nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Especialidades_x_Medico VALUES ('" + nueva.IDEspecialidad + "', '" + nueva.IDMedico + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void eliminarEspecialidad_x_Medico(Especialidad_x_Medico ExM)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Especialidades_x_Medico WHERE IDEspecialidad = @IdEspecialidad AND IDMedico = @IdMedico;");
                datos.setearParametro("@IdEspecialidad", ExM.IDEspecialidad);
                datos.setearParametro("@IdMedico", ExM.IDMedico);
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


    }
}
