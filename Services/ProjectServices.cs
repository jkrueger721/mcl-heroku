
using Microsoft.EntityFrameworkCore;
using MusiCoLab2.Modals;
using MusiCoLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCoLab2.Services
{
    public class ProjectService : IProjectService
    {
        private UserContext _db;
        public ProjectService(UserContext db)
        {
            _db = db;
        }

        public List<Project> GetProjects()
        {
            var projects = _db.Projects.ToList();
            return projects;
        }
        public void Add(AddProjectVM vm)
        {
            
            vm.Project.ProjectUsers = new List<ProjectUser> {
                new ProjectUser { ProjectId = vm.Project.Id , UserId = vm.UserId }
            };
            _db.Projects.Add(vm.Project);
            _db.SaveChanges();
        }

        public Project Find(long id)
        {
            return _db.Projects.FirstOrDefault(project => project.Id == id);
        } 
        public void Remove(long key)
        {
            var projectEntity = _db.Projects.First(project => project.Id == key);
            _db.Projects.Remove(projectEntity);
            _db.SaveChanges();
        }
        public void AddProjectUser(ProjectUser projectuser)
        {
            var user = _db.Users.Include(u => u.ProjectUsers).FirstOrDefault(u => u.Id == projectuser.UserId);
            user.ProjectUsers.Add(projectuser);
            _db.SaveChanges();
        }
        public void Update(Project ite m)
        {
            _db.Projects.Update(item);
            _db.SaveChanges();
        }
    }
}
