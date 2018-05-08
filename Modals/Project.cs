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
        public Project()
        {
            ProjectUsers = new List<ProjectUser>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = " Project Name Required")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Must be between 3 and 20 characters")]
        public string Name { get; set; }

        public List<ProjectUser> ProjectUsers { get; set; }
        public bool IsPrivate { get; set; }
        public string Daw { get; set; }
        public string Style { get; set; }
        public string Instruments { get; set; }
        public string Comments { get; set; }
        public string AudioUrl { get; set; }


    }
}