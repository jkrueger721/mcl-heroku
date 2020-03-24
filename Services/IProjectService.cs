using System.Collections.Generic;
using MusiCoLab2.Models;
using MusiCoLab2.Modals;

namespace MusiCoLab2.Services
{
    public interface IProjectService
    {
        void Add(AddProjectVM vm);
        IProject Find(long id);
        IProject FindWithOwner(long id);
        List<IProject> GetProjects();
        void Remove(long key);
        void Update(IProject item);
        void AddProjectContributor(ProjectContributor projectContributor);
    }
}