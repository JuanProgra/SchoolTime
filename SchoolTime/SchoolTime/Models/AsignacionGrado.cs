﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class AsignacionGrado
    {
        public int Id { set; get; }

        public int CursoId { set; get; }
        public virtual Curso Curso { set; get; }

        public int GradoId { set; get; }
        public virtual Grado Grado { set; get; }

    }
}