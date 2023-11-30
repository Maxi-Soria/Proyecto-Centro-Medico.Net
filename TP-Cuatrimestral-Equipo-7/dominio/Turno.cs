using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Turno
    {
        public int IDTurno { get; set; }
        public int IDMedico { get; set; }
        public int IDUsuario { get; set; }
        public DateTime Fecha_Horario_Entrada { get; set; }
        public int IDHorario { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public String Situacion { get; set; }

    }
}
