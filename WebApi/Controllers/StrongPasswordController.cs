using Microsoft.AspNetCore.Mvc;
using Services;
using Zxcvbn;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrongPasswordController : ControllerBase
    {
        StrongPasswordService strongPasswordService = new StrongPasswordService();
        // GET: api/<StrongPasswordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StrongPasswordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StrongPasswordController>
        [HttpPost]
        public ActionResult<Result> Post([FromBody] string password)
        { 
            return Ok(strongPasswordService.GetStrongPassword(password));
        }

        // PUT api/<StrongPasswordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StrongPasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
