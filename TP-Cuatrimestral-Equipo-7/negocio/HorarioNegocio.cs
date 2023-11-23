using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class HorarioNegocio
    {
        public List<Horario> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Horario> lista = new List<Horario>();

            try
            {
                datos.setearConsulta("SELECT IDHorario, HoraInicio, HoraFin FROM Horarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Horario aux = new Horario();
                    aux.IDHorario = (int)datos.Lector["IDHorario"];
                    aux.HoraInicio = (TimeSpan)datos.Lector["HoraInicio"];
                    aux.HoraFin = (TimeSpan)datos.Lector["HoraFin"];

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

        public void agregarHorario(DateTime horaInicio, DateTime horaFin)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Horarios (HoraInicio, HoraFin) VALUES (@HoraInicio, @HoraFin)");
                datos.setearParametro("@HoraInicio", horaInicio.TimeOfDay);
                datos.setearParametro("@HoraFin", horaFin.TimeOfDay);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void eliminarHorario(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Horarios WHERE IDHorario = @IDHorario");
                datos.setearParametro("@IDHorario", id);
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

        public void modificarHorario(Horario editada)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Horarios SET HoraInicio = @HoraInicio, HoraFin = @HoraFin WHERE IDHorario = @IDHorario");
                datos.setearParametro("@IDHorario", editada.IDHorario);
                datos.setearParametro("@HoraInicio", editada.HoraInicio);
                datos.setearParametro("@HoraFin", editada.HoraFin);
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
