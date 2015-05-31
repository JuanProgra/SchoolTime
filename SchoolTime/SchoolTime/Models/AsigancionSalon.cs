using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class AsigancionSalon
    {
        public int Id { set; get; }
        public string Salon { set; get; }
        public DateTime Hora { set; get; }
        public DateTime Dia { set; get; }

        public int AsignacionMateriaId { set; get; }
        public virtual AsignacionMateria AsignacionMateria { set; get; }
    }
}
