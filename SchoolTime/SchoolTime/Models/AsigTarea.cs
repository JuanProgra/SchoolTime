using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolTime.Models
{
    public class AsigTarea
    {
        public String NombreTare { get; set; }
        public String Nombre { get; set; }
        public String Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Punteo { get; set; }
    }
}