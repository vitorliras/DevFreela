using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.InputModel
{
    public class CreateUserInputModel
    {
        public CreateUserInputModel(string name, string email, DateTime birthDay)
        {
            Name = name;
            Email = email;
            BirthDay = birthDay;
        }

        public string Name { get;  set; }
        public string Email { get;  set; }
        public DateTime BirthDay { get;  set; }
    }
}
