using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class AsignacionRol
    {
        [Key]
        public int Id { set; get; }

        public int RolId { set; get; }
        public virtual Rol Rol { set; get; }

        public int UsuarioId { set; get; }
        public virtual Usuario Usuario { set; get; }

    }
}
