using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Centro_Medico
{
    public partial class CRUD_Medicos : System.Web.UI.Page
    {
        MedicoNegocio medicoNegocio = new MedicoNegocio();
        EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
        HorarioNegocio horarioNegocio = new HorarioNegocio();

        Especialidades_X_MedicoNegocio especialidades_X_Medico = new Especialidades_X_MedicoNegocio();
        Horarios_x_MedicoNegocio horarios_X_Med = new Horarios_x_MedicoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!IsUserAuthenticated())
                {

                    Response.Redirect("~/Login.aspx");
                    return;
                }
                cargarListaMedicos();


            }
        }

        private bool IsUserAuthenticated()
        {
            return Session["usuario"] != null;
        }


        protected void cargarListaMedicos()
        {
            try
            {
                List<Medico> lista = medicoNegocio.listar();


                dgvMedicos.DataSource = lista;
                dgvMedicos.DataBind();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de medicos: " + ex.Message);
            }

        }

        protected void cargarDropDawnList(int idMedico)
        {
            try
            {
                List<Especialidad_x_Medico> especialidadesDelMedico = especialidades_X_Medico.listar().Where(em => em.IDMedico == idMedico).ToList();

                List<Especialidad> todasLasEspecialidades = especialidadNegocio.listar();

                List<Especialidad> especialidadesNoAsignadas = todasLasEspecialidades.Where(especialidad =>
                                   !especialidadesDelMedico.Any(espMed => espMed.IDEspecialidad == especialidad.Id)
                                   ).ToList();

                ddlAgregarEsp.DataSource = especialidadesNoAsignadas;


                ddlAgregarEsp.DataTextField = "Nombre"; 
                ddlAgregarEsp.DataValueField = "Id";    

                ddlAgregarEsp.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }



        protected void cargarDropDawnListHxM(int idMedico)
        {
            try
            {
                List<Horarios_x_Medico> horariosDelMedico = horarios_X_Med.listar().Where(hm => hm.IDMedico == idMedico).ToList();
                List<Horario> todosLosHorarios = horarioNegocio.listar();

                List<Horario> horariosNoAsignados = todosLosHorarios.Where(horario =>
                    !horariosDelMedico.Any(horaXMed => horaXMed.IDHorario == horario.IDHorario)
                ).ToList();

                DropDownListHxM.DataSource = horariosNoAsignados;
                DropDownListHxM.DataTextField = "HoraInicio"; // Cambia al campo que desees mostrar
                DropDownListHxM.DataValueField = "IDHorario"; // Cambia al campo de valor que desees

                DropDownListHxM.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los horarios no asignados: " + ex.Message);
            }
        }




        protected void cargarListBox(int idMedico)
        {
            List<Especialidad> especialidades = especialidadNegocio.listar();
            List<Especialidad_x_Medico> listaEspXMed = especialidades_X_Medico.listar().Where(em => em.IDMedico == idMedico).ToList();

            try
            {
                List<Especialidad> especialidadesEncontradas = new List<Especialidad>();

                foreach (Especialidad_x_Medico espXMed in listaEspXMed)
                {
                    Especialidad especialidadEncontrada = especialidades.FirstOrDefault(e => e.Id == espXMed.IDEspecialidad);

                    if (especialidadEncontrada != null)
                    {
                        especialidadesEncontradas.Add(especialidadEncontrada);
                    }
                }

                listBox.DataSource = especialidadesEncontradas;
                listBox.DataTextField = "Nombre";
                listBox.DataValueField = "Id";
                listBox.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de especialidades: " + ex.Message);
                throw;
            }
        }

        protected void cargarListBoxHxM(int idMedico)
        {
            List<Horario> horarios = horarioNegocio.listar();
            List<Horarios_x_Medico> listaHoraxMed = horarios_X_Med.listar().Where(hm => hm.IDMedico == idMedico).ToList();
            try
            {
                List<Horario> horariosEncontrados = new List<Horario>();

                foreach (Horarios_x_Medico horaXMed in listaHoraxMed)
                {
                    Horario horarioEncontrado = horarios.FirstOrDefault(h => h.IDHorario == horaXMed.IDHorario);

                    if (horarioEncontrado != null)
                    {
                        horariosEncontrados.Add(horarioEncontrado);
                    }
                }

                listBoxHxM.DataSource = horariosEncontrados;
                listBoxHxM.DataTextField = "HoraInicio"; // Cambia al campo que desees mostrar
                listBoxHxM.DataValueField = "IDHorario"; // Cambia al campo de valor que desees
                listBoxHxM.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la lista de horarios: " + ex.Message);
                throw;
            }
        }







        protected void dgvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                GridViewRow row = dgvMedicos.SelectedRow;

                txtIdMedico.Text = row.Cells[1].Text;
                txtLegajoMedico.Text = row.Cells[2].Text;
                txtNombreMedico.Text = row.Cells[3].Text;
                txtApellidoMedico.Text = row.Cells[4].Text;
                txtEmail.Text = row.Cells[5].Text;

                int idMedico = Convert.ToInt32(row.Cells[1].Text);

                cargarListBox(idMedico);
                cargarDropDawnList(idMedico);

                cargarListBoxHxM(idMedico);
                cargarDropDawnListHxM(idMedico);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar un medico: " + ex.Message);

            }

        }

        protected void btnAgregarEspecialidad_a_Medico(object sender, EventArgs e)
        {
            if (ddlAgregarEsp.SelectedIndex != -1)
            {
                Especialidad_x_Medico nuevaExM = new Especialidad_x_Medico();

                string idEspecialidadSeleccionada = ddlAgregarEsp.SelectedValue;

                int idEspecialidad = Convert.ToInt32(idEspecialidadSeleccionada);
                int idMedico = Convert.ToInt32(txtIdMedico.Text);

                nuevaExM.IDEspecialidad = idEspecialidad;
                nuevaExM.IDMedico = idMedico;

                especialidades_X_Medico.agregarEspecialidad_x_Medico(nuevaExM);

                cargarListBox(nuevaExM.IDMedico);
                cargarDropDawnList(nuevaExM.IDMedico);

            }
        }

        protected void btnAgregarHorario_a_Medico(object sender, EventArgs e)
        {
            if (DropDownListHxM.SelectedIndex != -1)
            {
                Horarios_x_Medico nuevoHorarioMedico = new Horarios_x_Medico();

                string idHorarioSeleccionado = DropDownListHxM.SelectedValue;

                int idHorario = Convert.ToInt32(idHorarioSeleccionado);
                int idMedico = Convert.ToInt32(txtIdMedico.Text);

                nuevoHorarioMedico.IDHorario = idHorario;
                nuevoHorarioMedico.IDMedico = idMedico;

                horarios_X_Med.agregarHorario_x_Medico(nuevoHorarioMedico);

                cargarListBox(idMedico);
                cargarDropDawnList(idMedico);
                cargarDropDawnListHxM(idMedico);
                cargarListBoxHxM(idMedico);

            }
        }
        

        protected void btnQuitarEspecialidad_a_Medico(object sender, EventArgs e)
        {
            Especialidad_x_Medico nuevaExM = new Especialidad_x_Medico();
            if (listBox.SelectedIndex != -1)
            {

             
                                                                         
                string valorSeleccionado = listBox.SelectedItem.Value;

                int idEspecialidad = Convert.ToInt32(valorSeleccionado);
                int idMedico =  Convert.ToInt32(txtIdMedico.Text);

                nuevaExM.IDEspecialidad = idEspecialidad;
                nuevaExM.IDMedico = idMedico;

                especialidades_X_Medico.eliminarEspecialidad_x_Medico(nuevaExM);

                cargarListBox(nuevaExM.IDMedico);
                cargarDropDawnList(nuevaExM.IDMedico);

            }
        }

        protected void btnQuitarHorario_a_Medico(object sender, EventArgs e)
        {
            if (listBoxHxM.SelectedIndex != -1)
            {
                Horarios_x_Medico nuevoHorarioMedico = new Horarios_x_Medico();

                string valorSeleccionado = listBoxHxM.SelectedItem.Value;
                int idHorario = Convert.ToInt32(valorSeleccionado);
                int idMedico = Convert.ToInt32(txtIdMedico.Text);

                nuevoHorarioMedico.IDHorario = idHorario;
                nuevoHorarioMedico.IDMedico = idMedico;

                // Eliminar el horario del médico
                horarios_X_Med.eliminarHorario_x_Medico(nuevoHorarioMedico);

                // Recargar los DropDownList después de eliminar el horario del médico
                cargarListBox(idMedico);
                cargarDropDawnList(idMedico);
                cargarDropDawnListHxM(idMedico);
                cargarListBoxHxM(idMedico);
            }
        }




        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Medico> lista = medicoNegocio.listar();

                int legajo = int.Parse(txtLegajoMedico.Text);

                if (!lista.Any(medico => medico.Legajo == legajo))
                {
                    Medico nuevo = new Medico();
                    nuevo.Legajo = legajo;
                    nuevo.Nombre = txtNombreMedico.Text;
                    nuevo.Apellido = txtApellidoMedico.Text;
                    nuevo.EmailInstitucional = txtEmail.Text;

                    medicoNegocio.agregarMedico(nuevo);
                    limpiarCampos();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Perfecto', 'Se registro el Medico.', 'success');", true);
                    cargarListaMedicos();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'El legajo ingresado ya se encuentra registrado.', 'error');", true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el médico: " + ex.Message);

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error al agregar el médico');", true);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtIdMedico.Text);
                int Legajo = Convert.ToInt32(txtLegajoMedico.Text);
                string nombre = txtNombreMedico.Text;
                string apellido = txtApellidoMedico.Text;
                string email = txtEmail.Text;

                Medico medicoModificado = new Medico
                {
                    IDMedico = Id,
                    Legajo = Legajo,
                    Nombre = nombre,
                    Apellido = apellido,
                    EmailInstitucional = email,

                };


                medicoNegocio.modificarMedico(medicoModificado);


                cargarListaMedicos();


                limpiarCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el paciente: " + ex.Message);

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            List<Medico> listaMedicos = medicoNegocio.listar();
            try
            {
                int idMedico = Convert.ToInt32(txtIdMedico.Text);
                bool medicoConTurno = listaMedicos.Any(medi => medi.IDMedico == idMedico);

                if (!medicoConTurno)
                {
                    medicoNegocio.eliminarMedico(idMedico);
                    cargarListaMedicos();
                    limpiarCampos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'No se puede eliminar un medico con turno pendiente.', 'error');", true);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el Medico: " + ex.Message);
            }
        }

        protected void limpiarCampos()
        {
            txtIdMedico.Text = string.Empty;
            txtLegajoMedico.Text = string.Empty;
            txtNombreMedico.Text = string.Empty;
            txtApellidoMedico.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }


    }
}