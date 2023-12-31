﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Centro_Medico
{
    public partial class CRUD_Usuarios : System.Web.UI.Page
    {
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!IsUserAuthenticated())
                {

                    Response.Redirect("~/Login.aspx");
                    return;
                }

                cargarListaUsuarios();
            }
        }

        private bool IsUserAuthenticated()
        {
            return Session["usuario"] != null;
        }


        protected void cargarListaUsuarios()
        {
            try
            {
                List<Usuario> lista = usuarioNegocio.listar();
                dgvUsuarios.DataSource = lista;
                dgvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de usuarios: " + ex.Message);
            }
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                GridViewRow row = dgvUsuarios.SelectedRow;
                txtIdUsuario.Text = row.Cells[1].Text;
                txtUser.Text = row.Cells[2].Text;
                txtPass.Text = row.Cells[3].Text;
                ddlTipoUser.Text = row.Cells[4].Text;
                txtEmail.Text = row.Cells[5].Text;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar un medico: " + ex.Message);

            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> lista = usuarioNegocio.listar();

                string nombreUsuario = txtUser.Text.ToString();

                if (!lista.Any(usuario => usuario.User.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase)))
                {
                    Usuario nuevo = new Usuario();
                    nuevo.User = nombreUsuario;
                    nuevo.Pass = txtPass.Text;
                    nuevo.Email = txtEmail.Text;
                    //nuevo.TipoUsuario = (int)4; PARA VER

                    usuarioNegocio.agregarUsuario(nuevo);
                    limpiarCampos();

                    cargarListaUsuarios();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('El usuario ya existe en la lista');", true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el usuario: " + ex.Message);

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error al agregar un usuario');", true);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            
            try
            {
                int id = Convert.ToInt32(txtIdUsuario.Text);
                String user = txtUser.Text;
                string pass = txtPass.Text;
                string email = txtEmail.Text;
                

                Usuario usuarioModificado = new Usuario
                {
                    Id = id,
                    User = user,
                    Pass = pass,
                    Email = email,

                };

                // Llamar al método para modificar el paciente
                usuarioNegocio.modificarUsuario(usuarioModificado);

                // Volver a cargar la lista de pacientes
                cargarListaUsuarios();

                // Limpiar los campos después de la modificación
                limpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el usuario: " + ex.Message);
                // Manejar la excepción y mostrar un mensaje de error si es necesario
            }
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            
            try
            {
                int id = Convert.ToInt32(txtIdUsuario.Text);
                usuarioNegocio.eliminarUsuario(id);
                cargarListaUsuarios();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el usuario: " + ex.Message);
            }
            
        }

        protected void limpiarCampos()
        {
            
            txtIdUsuario.Text = string.Empty;
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtEmail.Text = string.Empty;
            
        }


    }
}