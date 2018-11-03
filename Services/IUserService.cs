using MusiCoLab2.Models;

namespace MusiCoLab2.Services
{
    public interface IUserService
    {
        //void AddProjectUser(ProjectUser projectuser);
        void AddUser(User user);
        User Find(long id);
    }
}