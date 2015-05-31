using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Categoria
    {
        public int Id { set; get; }
        public string Nombre { set; get; }

        public virtual ICollection<CategoriaCurso> CategoriaCurso { get; set; }
    }
}
