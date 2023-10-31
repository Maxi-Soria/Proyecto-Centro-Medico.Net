using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Turno
    {
        public int Numero { get; set; }
        public DateTime Fecha_Horario_Entrada { get; set; }
        public DateTime Fecha_Horario_Salida { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}
