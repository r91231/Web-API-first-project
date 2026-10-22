using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
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
        public ActionResult<User> Post([FromBody] User user)
        {
            string path = "DataUsers.txt";
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.Id });
        }

        [HttpPost("LogIn")]
        public ActionResult<User> Post([FromBody] LogInUser logInUser)
        {
            string path = "DataUsers.txt";
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == logInUser.Email && user.Password == logInUser.Password)
                        return Ok(user);
                }
            }
            return NotFound();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User updateUserDetails)
        {
            string path = "DataUsers.txt";
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(path))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(updateUserDetails));
                System.IO.File.WriteAllText(path, text);
            }
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
