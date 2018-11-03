using MusiCoLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCoLab2.Modals
{
    public class UpdateProjectVM
    {
        public int UserId { get; set; }
        public Project UpdatedProject { get; set; }


    }
}
