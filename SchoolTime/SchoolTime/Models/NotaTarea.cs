using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class NotaTarea
    {
        [Key]
        public int Id { set; get; }
        [Required]
        [Range(0, 100)]
        public int PunteoFinal { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCalificacion { set; get; }

        public int TareaId { set; get; }
        public virtual Tarea Tarea { set; get; }
    }
}
