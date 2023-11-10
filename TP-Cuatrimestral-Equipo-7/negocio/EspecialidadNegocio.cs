using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EspecialidadNegocio
    {
        public List<Especialidad> listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre FROM Especialidades");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (String)datos.Lector["Nombre"];

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

        public void eliminarEspecialidad(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Especialidades WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la eliminación
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
