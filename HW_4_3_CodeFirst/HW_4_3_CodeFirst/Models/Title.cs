﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_3_CodeFirst.Models
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public virtual List<Employee> Employee { get; set; } = new List<Employee>();
    }
}