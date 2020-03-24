using MusiCoLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCoLab2.Modals
{
    public class AddProjectVM:IProject
    {
        // public  Project  Project{ get; set; }
        public int UserId { get; set; }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsPrivate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Daw { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Style { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Instruments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Comments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AudioUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public User ProjectOwner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ProjectContributor> ProjectContributors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
