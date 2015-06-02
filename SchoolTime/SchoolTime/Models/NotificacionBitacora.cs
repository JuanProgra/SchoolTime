using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class NotificacionBitacora
    {
        [Key]
        public int Id { set; get; }
        public string Nueva { set; get; }
        public int Calificada { set; get; }

        public int NotaTareaId { set; get; }
        public virtual NotaTarea NotaTarea { set; get; }

        public int TareaId { set; get; }
        public virtual Tarea Tarea { set; get; }
    }
}
