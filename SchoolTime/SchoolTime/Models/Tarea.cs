using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Tarea
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Nombre { set; get; }
        public string Detalle { set; get; }
        [Required]
        [Range(0, 100)]
        public decimal Punteo { set; get; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEntrega { set; get; }
        public virtual ICollection<AsigancionTarea> AsigancionTarea { get; set; }


    }
}
