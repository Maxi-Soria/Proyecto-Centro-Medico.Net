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
                    aux.HoraInicio = (DateTime)datos.Lector["HoraInicio"];
                    aux.HoraFin = (DateTime)datos.Lector["HoraFin"];

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
                datos.setearConsulta("insert into Horarios(HoraInicio, HoraFin) VALUES ('" + horaInicio + "''" + horaFin + "')");
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
                datos.setearConsulta("UPDATE Horario SET HoraInicio = @HoraInicio, HoraFin = @HoraFin WHERE IDHorario = @IDHorario");
                datos.setearParametro("@IDHorario", editada.IDHorario);
                datos.setearParametro("@HoraInicio", editada.HoraInicio);
                datos.setearParametro("@HoraFin", editada.HoraFin);
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
