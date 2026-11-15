using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usersService;
        private IStrongPasswordService _passwordService;
        public UsersController(IUserService usersService, IStrongPasswordService passwordService)
        {
            _usersService = usersService;
            _passwordService = passwordService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Ruti", "Tamar", "Dasi" };
        }

        //Question: Why does GET by id always return 'value'? The assignment asks it to return the user with this id, or NotFound / NoContent when there is none
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            if (_passwordService.GetStrongPassword(user.Password).Score > 2)
            {
                user = await _usersService.AddUser(user);
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("LogIn")]
        public ActionResult<User> Post([FromBody] LogInUser logInUser)
        {
            var user = _usersService.GetUser(logInUser);
            //The assignment asks a login with a wrong password to return 204 NoContent: what does NotFound return here, and when is 204 used?
            if(user == null)
                return NotFound();
            return Ok(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User updateUserDetails)
        {
            if (_passwordService.GetStrongPassword(updateUserDetails.Password).Score >2)
            {
                await _usersService.UpdateUser(id, updateUserDetails);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
