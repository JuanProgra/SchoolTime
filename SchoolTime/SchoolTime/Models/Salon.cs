﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTime.Models
{
    public class Salon
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
    }
}
