using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    class Paciente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Edad { get; set; }
        public string EmailPersonal { get; set; }
        public string NumeroTelefonico { get; set; }
        public List<string> Observaciones { get; set; }
    }
}
