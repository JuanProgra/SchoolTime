using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Usuario
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Nombre { set; get; }
        [Required]
        public string Apellido { set; get; }
        [Required]
        public string NombreUsuario { set; get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { set; get; }

        public virtual ICollection<AsignacionRol> AsignacionRol { get; set; }
        public virtual ICollection<AsignacionGrupo> AsignacionGrupo { get; set; }
    }
}
