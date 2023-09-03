using DevFreela.API.Models;
using DevFreela.Aplication.Commands.CreateComment;
using DevFreela.Aplication.Commands.CreateProject;
using DevFreela.Aplication.Commands.DeleteProject;
using DevFreela.Aplication.Commands.UpdateProject;
using DevFreela.Aplication.InputModel;
using DevFreela.Aplication.Queries.GetAllProjects;
using DevFreela.Aplication.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace DevFreela.API.Controllers
{
    [Route("/api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator) 
        {
            _projectService = projectService;
            _mediator = mediator;
        } 

        //api/projects?query=
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllQuery = new GetAllProjectsQuery(query);
            var projects = await _mediator.Send(getAllQuery);

            return Ok(projects);
        }

        //api/projects/23
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var project = _projectService.GetByID(id);
            if(project == null) 
            {
            return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
           if(command.Title.Length > 50)
            {
                return BadRequest();
            }
            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetbyId), new { id = id }, command);

        }

        // api/projects/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 50)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }

       

    }
}
