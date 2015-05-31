using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class NotaTarea
    {
        public int Id { set; get; }
        public int PunteoFinal { set; get; }
        public DateTime FechaCalificacion { set; get; }

        public int TareaId { set; get; }
        public virtual Tarea Tarea { set; get; }
    }
}
