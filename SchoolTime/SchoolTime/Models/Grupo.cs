﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Grupo
    {
        public int Id { set; get; }
        public int Codigo { set; get; }

        public int AsignacionGradoId { set; get; }
        public virtual AsignacionGrado AsignacionGrado { set; get; }

        public int JornadaId { set; get; }
        public virtual Jornada Jornada { set; get; }

        public virtual ICollection<AsignacionMateria> AsignacionMateria { get; set; }
        public virtual ICollection<AsignacionGrupo> AsignacionGrupo { get; set; }
    }
}
