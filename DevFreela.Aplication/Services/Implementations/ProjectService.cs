using Dapper;
using DevFreela.Aplication.InputModel;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _coneectionString;

        public ProjectService(DevFreelaDbContext dbContext, IConfiguration configuration) 
        {
            _dbContext = dbContext;
            _coneectionString = configuration.GetConnectionString("DevFreela");
        }       

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                project.Finish();
                _dbContext.SaveChanges();

            }
        }

        public ProjectDetailsViewModel GetByID(int id)
        {
            var project = _dbContext.Projects.Include(x => x.Client).Include(x => x.Freelancer).SingleOrDefault(p => p.Id == id);

            if (project != null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinisedAt,
                project.Client.Name,
                project.Freelancer.Name
                );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                project.Start();
                _dbContext.SaveChanges();

            }

            using (var sqlConection = new SqlConnection(_coneectionString))
            {
                sqlConection.Open();

                var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE ID = @id";

                sqlConection.Execute(script, new { status = project.Status, startedat = project.StartedAt,  id });
            }
        }
    }
}
