using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Grupo
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public String Codigo { set; get; }

        public int AsignacionGradoId { set; get; }
        public virtual AsignacionGrado AsignacionGrado { set; get; }

        public int JornadaId { set; get; }
        public virtual Jornada Jornada { set; get; }

        public virtual ICollection<AsigancionSalon> AsigancionSalon { get; set; }
        public virtual ICollection<AsignacionGrupo> AsignacionGrupo { get; set; }
    }
}
