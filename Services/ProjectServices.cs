
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
            //  _db.Projects.Add(vm.Project);
            // _db.SaveChanges();

            // ProjectUser projectUser = new ProjectUser();
            // add project first
            //projectUser.UserId = vm.UserId;
            //projectUser.ProjectId = vm.Project.Id;
            // find porject then add ProjectUser to that project
            // use find on line 39
            //var _project =  Find(projectUser.ProjectId);
            //_project.ProjectUsers.Add(projectUser);
            //_db.SaveChanges();
           // Project project = new Project;
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
        public void Update(Project item)
        {
            _db.Projects.Update(item);
            _db.SaveChanges();
        }
    }
}
