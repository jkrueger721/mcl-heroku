using System.Collections.Generic;
using MusiCoLab2.Models;
using MusiCoLab2.Modals;

namespace MusiCoLab2.Services
{
    public interface IProjectService
    {
        void Add(AddProjectVM vm);
        Project Find(long id);
        Project FindWithOwner(long id);
        List<Project> GetProjects();
        void Remove(long key);
        void Update(Project item);
        void AddProjectContributor(ProjectContributor projectContributor);
    }
}