using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class AsignacionMateria
    {
        [Key]
        public int Id { set; get; }

        public int MateriaId { set; get; }
        public virtual Materia Materia { set; get; }

        public int GrupoId { set; get; }
        public virtual Grupo Grupo { set; get; }
    }
}
