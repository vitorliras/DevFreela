using DevFreela.Aplication.InputModel;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.Name, inputModel.Email, inputModel.BirthDay);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;

        }

        public UserViewModel GetUserByID(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);

            if (user == null) { return null; }

            return new UserViewModel(user.Name, user.Email);
        }
    }
}
