using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class CategoriaCurso
    {
        public int Id { set; get; }

        public int CategoriaId { set; get; }
        public virtual Categoria Categoria { set; get; }

        public int CursoId { set; get; }
        public virtual Curso Curso { set; get; }

    }
}
