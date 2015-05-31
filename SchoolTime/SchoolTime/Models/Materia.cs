using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Materia
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public virtual ICollection<AsignacionMateria> AsignacionMateria { get; set; }
        public virtual ICollection<AsigancionTarea> AsigancionTarea { get; set; }
    }
}
