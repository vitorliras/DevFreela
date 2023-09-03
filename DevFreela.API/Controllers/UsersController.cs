using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {

        public UsersController(ExampleClass exClass)
        {
            exClass.Name = "Update here";
        }
        [HttpGet]
        public IActionResult getByID(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel user)
        {
            return CreatedAtAction(nameof(getByID), new {id = 1}, user );
        }

        // api/users/1/login
        [HttpPut("{id}/Login")]
        public IActionResult Login(int id, [FromBody]  LoginModel login)
        {
            return NoContent();
        }
    }
}
