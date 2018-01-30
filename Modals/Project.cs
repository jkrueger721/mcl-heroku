﻿using System;
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
    }
}
