using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MusiCoLab2.Modals;

namespace MusiCoLab2.Models
{
    public interface IProject
 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         int Id { get; set; }

         string Name { get; set; }
         bool IsPrivate { get; set; }
         string Daw { get; set; }
         string Style { get; set; }
         string Instruments { get; set; }
         string Comments { get; set; }
         string AudioUrl { get; set; }

        //[InverseProperty("Owner")]
         User ProjectOwner { get; set; }

        //[InverseProperty("Contributor")]
         List<ProjectContributor> ProjectContributors { get; set; }


    }
}