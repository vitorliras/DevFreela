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

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
            _dbContext.Projects.Add(project);

            _dbContext.SaveChanges();

            return project.Id;
        }

        public void CreateComment(CreatedCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();


        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            //_dbContext.Projects.Remove()
            if(project != null)
            {
                project.Cancel();
                _dbContext.SaveChanges();

            }
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

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;
            var projectViewModel =  projects
                    .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                    .ToList();

            return projectViewModel;


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

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
            _dbContext.SaveChanges();

        }
    }
}
