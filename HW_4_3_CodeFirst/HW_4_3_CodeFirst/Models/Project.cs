using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_3_CodeFirst.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public EmployeeProject EmployeeProject { get; set; }

    }
}
