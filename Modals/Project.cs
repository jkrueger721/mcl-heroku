using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiCoLab2.Models
{
    public class Project
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
        public string Name { get; set; }

        //public virtual List<ProjectUser> ProjectUsers { get; set; }
        public bool IsPrivate { get; set; }
        public string Daw { get; set; }
        public string Style { get; set; }
        public string Instruments { get; set; }
        public string Comments { get; set; }
        public string AudioUrl { get; set; }
        public User ProjectOwner { get; set; }
        public ICollection<User> ProjectContributors { get; set; } = new List<User>();

    }
}