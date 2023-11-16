using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Medico
    {
        public int IDMedico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        public string EmailInstitucional { get; set; }
    }
}
