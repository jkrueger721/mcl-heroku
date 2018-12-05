﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MusiCoLab2.Modals;

namespace MusiCoLab2.Models
{
    public class User
    {
        //Use Class
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }

        public List<ProjectContributor> ProjectContributors { get; set; }


    }
}
