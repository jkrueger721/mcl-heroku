using System.ComponentModel.DataAnnotations.Schema;

namespace MusiCoLab2.Models
{
    public class ProjectUser
    {

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}
