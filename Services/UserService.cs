using MusiCoLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCoLab2.Services
{
    public class UserService
    {
        private UserContext _db;
        public UserService(UserContext db)
        {
            _db = db;
        }
        public void Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}
