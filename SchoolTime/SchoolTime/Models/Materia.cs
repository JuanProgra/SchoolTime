using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Materia
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Nombre { set; get; }
        public virtual ICollection<AsignacionMateria> AsignacionMateria { get; set; }
        public virtual ICollection<AsigancionTarea> AsigancionTarea { get; set; }
    }
}
