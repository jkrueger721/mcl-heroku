
using MusiCoLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCoLab2.Services
{
    public class ProjectService
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
        public void Add(Project item)
        {
            _db.Projects.Add(item);
            _db.SaveChanges();
        }
        public Project Find(long id)
        {
            return _db.Projects.FirstOrDefault(project => project.Id == id);
        }
        public void Remove(long key)
        {
            var projectEntity = _db.Projects.First(course => course.Id == key);
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
