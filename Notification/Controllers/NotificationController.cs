using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notification.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> logger;

        public NotificationController(ILogger<NotificationController> logger)
        {
            this.logger = logger;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string value)
        {
            Stream reqBody = Request.Body;
            StreamReader reader = new StreamReader(reqBody);
            var response = await reader.ReadToEndAsync();
            logger.LogInformation(response);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
