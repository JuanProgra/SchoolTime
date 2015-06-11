using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class AsigancionSalon
    {
        [Key]
        public int Id { set; get; }
        public int SalonId { set; get; }
        public int? GrupoId { set; get; }
        public int MateriaId { set; get; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime Hora { set; get; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd}", ApplyFormatInEditMode = true)]
        public DateTime Dia { set; get; }

        public virtual Salon Salon { get; set; }
        public virtual Materia Materia { get; set; }
        public virtual Grupo Grupo { get; set; }


    }
}
