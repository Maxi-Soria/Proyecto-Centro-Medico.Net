using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Horarios_x_MedicoNegocio
    {
        public List<Horarios_x_Medico> listar()
        {

            AccesoDatos datos = new AccesoDatos();
            List<Horarios_x_Medico> lista = new List<Horarios_x_Medico>();

            try
            {
                datos.setearConsulta("SELECT IDHorario, IDMedico FROM Horarios_x_Medico");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Horarios_x_Medico aux = new Horarios_x_Medico();
                    aux.IDHorario = (int)datos.Lector["IDHorario"];
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

        public void agregarHorario_x_Medico(Horarios_x_Medico nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Horarios_x_Medico VALUES ('" + nueva.IDMedico + "', '" + nueva.IDHorario + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }


        public void eliminarHorario_x_Medico(Horarios_x_Medico HxM)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Horarios_x_Medico WHERE IDHorario = @IdHorario AND IDMedico = @IdMedico;");
                datos.setearParametro("@IdHorario", HxM.IDHorario);
                datos.setearParametro("@IdMedico", HxM.IDMedico);
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
