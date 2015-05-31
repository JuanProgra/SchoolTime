using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Curso
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Detalle { set; get; }

        public virtual ICollection<AsignacionGrado> AsignacionGrado { get; set; }
        public virtual ICollection<CategoriaCurso> CategoriaCurso { get; set; }
    }
}
