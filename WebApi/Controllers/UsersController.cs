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
        private IConfiguration _configuration;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserService usersService, IStrongPasswordService passwordService,IConfiguration configuration,ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _passwordService = passwordService;
            _configuration = configuration;
            _logger = logger;
        }

        //GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Ruti", "Tamar", "Dasi" };
        }

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
            int score = int.Parse(_configuration["StrongPasswordScore:Developer"]);
            if (_passwordService.GetStrongPassword(user.Password).Score > (score!=null?score:4))
            {
                user = await _usersService.AddUser(user);
                _logger.LogInformation($"--Added User number {user.Id}, with email {user.Email}, with name {user.FirstName} {user.LastName}--");
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<User>> Post([FromBody] LogInUser logInUser)
        {
            var user = await _usersService.GetUser(logInUser);
            if(user == null)
                return NoContent();
            _logger.LogInformation($"--Login attemped User, with email {logInUser.Email}--");
            return Ok(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User updateUserDetails)
        {
            if (_passwordService.GetStrongPassword(updateUserDetails.Password).Score >2)
            {
                await _usersService.UpdateUser(id, updateUserDetails);
                _logger.LogInformation($"--Update attemped User, with email {updateUserDetails.Email}, with name {updateUserDetails.FirstName} {updateUserDetails.LastName}--");
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
