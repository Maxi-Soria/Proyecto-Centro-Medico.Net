using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Paciente
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public String Domicilio { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string EmailPersonal { get; set; }
        public string NumeroTelefonico { get; set; }
        public List<string> Observaciones { get; set; }
    }
}
