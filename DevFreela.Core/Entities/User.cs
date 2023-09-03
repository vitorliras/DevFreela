using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, DateTime birthDay)
        {
            Name = name;
            Email = email;
            BirthDay = birthDay;
            Active = true;
            CreatedAt = DateTime.Now;
            skills =  new List<UserSkill>();
            OwenedProjects =  new List<Project>();
            FreelancerProjects =  new List<Project>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDay { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }

        public List<UserSkill> skills { get; private set; }
        public List<Project> OwenedProjects { get; private set; }
        public List<Project> FreelancerProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}
