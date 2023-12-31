﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.setearConsulta("SELECT Id, Usuario, Pass,TipoUser, Email FROM Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.User = (String)datos.Lector["Usuario"];
                    aux.Pass = (String)datos.Lector["Pass"];
                    aux.TipoUsuario = (TipoUsuario)datos.Lector["TipoUser"];
                    aux.Email = datos.Lector["Email"] != DBNull.Value ? (String)datos.Lector["Email"] : "Sin Correo";


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

        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Usuario, Pass, TipoUser FROM Usuarios WHERE Usuario = @User AND Pass = @Pass");
                datos.setearParametro("@User", usuario.User);
                datos.setearParametro("@Pass", usuario.Pass);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
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

                throw ex;
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

        public void agregarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Usuarios VALUES ('" + nuevo.User + "', '" + nuevo.Pass + "', '" + nuevo.TipoUsuario + "', '" + nuevo.Email + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void eliminarUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Usuarios WHERE Id = @Id");
                datos.setearParametro("@Id", id);
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

        public void modificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET Usuario = @Usuario, Pass = @Pass, Email = @Email WHERE Id = @Id");

                datos.setearParametro("@Usuario", usuario.User);
                datos.setearParametro("@Pass", usuario.Pass);

                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Id", usuario.Id);

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

        public int ObtenerIDUsuario(string nombreUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id FROM Usuarios WHERE Usuario = @Usuario");
                datos.setearParametro("@Usuario", nombreUsuario);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return Convert.ToInt32(datos.Lector["Id"]);
                }
                else
                {
                    
                    return 0;
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
        }

        public string ObtenerEmailUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Email FROM Usuarios WHERE Id = @Id");
                datos.setearParametro("@Id", idUsuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    
                    return datos.Lector["Email"] != DBNull.Value ? (string)datos.Lector["Email"] : string.Empty;
                }

                
                return string.Empty;
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
