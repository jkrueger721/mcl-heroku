using System.Collections.Generic;
using MusiCoLab2.Models;

namespace MusiCoLab2.Services
{
    public interface IProjectService
    {
        void Add(Project item);
        Project Find(long id);
        List<Project> GetProjects();
        void Remove(long key);
        void Update(Project item);
    }
}