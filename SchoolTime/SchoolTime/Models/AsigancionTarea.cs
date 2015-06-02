using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class AsigancionTarea
    {
        [Key]
        public int Id { set; get; }

        public int MateriaId { set; get; }
        public virtual Materia Materia { set; get; }

        public int TareaId { set; get; }
        public virtual Tarea Tarea { set; get; }

    }
}
