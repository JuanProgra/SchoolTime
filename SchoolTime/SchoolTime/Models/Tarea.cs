using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Tarea
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Detalle { set; get; }
        public decimal Punteo { set; get; }
        public DateTime FechaEntrega { set; get; }
        public virtual ICollection<AsigancionTarea> AsigancionTarea { get; set; }


    }
}
