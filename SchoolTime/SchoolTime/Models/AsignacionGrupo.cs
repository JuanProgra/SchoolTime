using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class AsignacionGrupo
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId {get; set;}
        public int GrupoId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
