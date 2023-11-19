using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TurnoNegocio
    {
        public List<Turno> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Turno> lista = new List<Turno>();

            try
            {
                datos.setearConsulta("SELECT IDTurno, IDMedico, Fecha, ObservacionesMedico, Estado, IDHorario, IDUsuario FROM Turnos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.IDTurno = (int)datos.Lector["IDTurno"];
                    aux.IDMedico = (int)datos.Lector["IDMedico"];
                    aux.Fecha_Horario_Entrada = (DateTime)datos.Lector["Fecha"];
                    aux.Observaciones = (string)datos.Lector["ObservacionesMedico"];
                    aux.Estado = (string)datos.Lector["Estado"];
                    aux.IDHorario = (int)datos.Lector["IDHorario"];
                    aux.IDUsuario = (int)datos.Lector["IDUsuario"];

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

        public void agregarTurno(Turno nuevoTurno)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Turnos VALUES ('" + nuevoTurno.IDMedico + "', '" + nuevoTurno.Fecha_Horario_Entrada + "', '" + nuevoTurno.Observaciones + "', '" + nuevoTurno.IDHorario + "', '" + nuevoTurno.IDUsuario + "', '" + nuevoTurno.Estado + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void modificarTurno(Turno turno)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Turnos SET IDTurno = @IDTurno, IDMedico = @IDMedico, Fecha = @Fecha, ObservacionesMedico = @ObservacionesMedico, Estado = @Estado, IDHorario = @IDHorario, IDUsuario = @IDUsuario WHERE IDTurno = @IDTurno");

                datos.setearParametro("@IDTurno", turno.IDTurno);
                datos.setearParametro("@IDMedico", turno.IDMedico);
                datos.setearParametro("@Fecha", turno.Fecha_Horario_Entrada);
                datos.setearParametro("@ObservacionesMedico", turno.Observaciones);
                datos.setearParametro("@Estado", turno.Estado);
                datos.setearParametro("@IDHorario", turno.IDHorario);
                datos.setearParametro("@IDUsuario", turno.IDUsuario);
                

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

        public void cancelarTurno(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Turnos SET Estado = 'Cancelado'WHERE IDTurno = @IDTurno");
                datos.setearParametro("@IDTurno", id);
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
