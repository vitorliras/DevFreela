using Dapper;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.ViewModel;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _coneectionString;
        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _coneectionString = configuration.GetConnectionString("DevFreela");
        }

        public List<SkillViewModel> GetAll()
        {
            using (var sqlConection = new SqlConnection(_coneectionString))
            {
                sqlConection.Open();

                var script = "SELECT Id, Description FROM Skills";
                return sqlConection.Query<SkillViewModel>(script).ToList();
            }
            //var projects = _dbContext.Skills;
            //var skillViewModel = projects
            //        .Select(p => new SkillViewModel(p.Id, p.Description))
            //        .ToList();

            //return skillViewModel;
        }
    }
}
