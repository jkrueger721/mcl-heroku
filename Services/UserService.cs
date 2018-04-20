using MusiCoLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCoLab2.Services
{
    public class UserService : IUserService
    {
        private UserContext _db;
        public UserService(UserContext db)
        {
            _db = db;
        }
        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        public void AddProjectUser(ProjectUser projectuser)
        {
            _db.Add(projectuser);
            _db.SaveChanges();
        }

    }
}
