using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get;  set; }
        public string Email { get;  set; }
    }
}
