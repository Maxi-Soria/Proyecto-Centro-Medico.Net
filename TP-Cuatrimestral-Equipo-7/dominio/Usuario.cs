using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public String NombreUsuario { get; set; }
        public string Conraseña { get; set;}
        public String Rol { get; set; }
    }
}
