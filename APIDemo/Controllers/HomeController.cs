using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var id = Guid.NewGuid().ToString();

            return Ok(id);
        }

        [HttpPost]
        public IActionResult Post(PostRequest request)
        {
            return Ok(new { Id = request.Id, Name = request.Name, Time = DateTime.Now.ToString("hh:mm:ss tt")});
        }

        public class PostRequest
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}
