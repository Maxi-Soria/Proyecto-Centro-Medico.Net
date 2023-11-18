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





    }
}
