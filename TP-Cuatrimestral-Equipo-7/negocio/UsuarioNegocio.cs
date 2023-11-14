using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Usuario, Pass, TipoUser FROM Usuarios WHERE Usuario = @User AND Pass = @Pass");
                datos.setearParametro("@User", usuario.User);
                datos.setearParametro("@Pass", usuario.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    if((int)(datos.Lector["TipoUser"]) == 1)
                    {
                        usuario.TipoUsuario = TipoUsuario.Admin;
                    }else if ((int)(datos.Lector["TipoUser"]) == 2)
                    {
                        usuario.TipoUsuario = TipoUsuario.Recepcionista;
                    }
                    else if ((int)(datos.Lector["TipoUser"]) == 3)
                    {
                        usuario.TipoUsuario = TipoUsuario.Medico;
                    }
                    else if ((int)(datos.Lector["TipoUser"]) == 4)
                    {
                        usuario.TipoUsuario = TipoUsuario.Paciente;
                    }
                    else 
                    {
                        usuario.TipoUsuario = TipoUsuario.Default;
                    }

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int insertarUsuario(Usuario nuevoUsuario)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email",nuevoUsuario.Email);
                datos.setearParametro("@pass",nuevoUsuario.Pass);
                datos.setearParametro("@user",nuevoUsuario.User);
                return datos.ejecutarScalar();

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
