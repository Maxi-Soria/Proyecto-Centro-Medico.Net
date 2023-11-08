using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario
    {
        Admin = 1,
        Recepcionista = 2,
        Medico = 3,
        Paciente = 4,
        Default = 5
    }
    public class Usuario
    {
        public int Id { get; set; }
        public String User { get; set; }
        public string Pass { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario(string user, string pass, int tipoUsuario)
        {
            User = user;
            Pass = pass;
            if(tipoUsuario == 1)
            {
                TipoUsuario = TipoUsuario.Admin; 
            } else if(tipoUsuario == 2)
            {
                TipoUsuario = TipoUsuario.Recepcionista;
            }else if(tipoUsuario == 3)
            {
                TipoUsuario = TipoUsuario.Medico;
            }else if(tipoUsuario == 4)
            {
                TipoUsuario = TipoUsuario.Paciente;
            }
            else
            {
                TipoUsuario = TipoUsuario.Default;
            }
            
        }
    }


}
