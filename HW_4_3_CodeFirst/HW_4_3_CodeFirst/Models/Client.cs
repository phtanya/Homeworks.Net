using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_3_CodeFirst.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public DateTime FoundedDate { get; set; }
        public string Email { get; set; }
        public virtual List<Project> Project { get; set; } = new List<Project>();
    }
}
