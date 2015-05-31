using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Usuario
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string NombreUsuario { set; get; }
        public string Password { set; get; }
        public string Correo { set; get; }

        public virtual ICollection<AsignacionRol> AsignacionRol { get; set; }
        public virtual ICollection<AsignacionGrupo> AsignacionGrupo { get; set; }
    }
}
