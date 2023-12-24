using Dapper;
using DevFreela.Aplication.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Queries.GetAllSkills
{
    public class GetAllSkillsQuerryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly string _coneectionString;
        public GetAllSkillsQuerryHandler(IConfiguration configuration)
        {
            _coneectionString = configuration.GetConnectionString("DevFreela");
        }
        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConection = new SqlConnection(_coneectionString))
            {
                sqlConection.Open();

                var script = "SELECT Id, Description FROM Skills";
                var skills = await sqlConection.QueryAsync<SkillViewModel>(script);

                return skills.ToList();
            }
            //Com EF CORE

            //var projects = _dbContext.Skills;
            //var skillViewModel = projects
            //        .Select(p => new SkillViewModel(p.Id, p.Description))
            //        .ToList();

            //return skillViewModel;
        }
    }
}
