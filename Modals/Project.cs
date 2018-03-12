using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCoLab2.Models
{
    public class Project
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<ProjectUser> Users { get; set; }
        public bool IsPrivate { get; set; }
        public string Daw { get; set; }
        public string Style { get; set; }
        public string Instruments { get; set; }
        public string Comments { get; set; }


    }
}
