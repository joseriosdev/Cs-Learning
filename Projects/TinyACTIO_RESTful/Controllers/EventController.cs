using Microsoft.AspNetCore.Mvc;
using TinyACTIO_RESTful.Utilities;
using TinyACTIO_RESTful.Entities;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;

namespace TinyACTIO_RESTful.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class EventController : Controller
    {
        [HttpGet("allEvents")]
        public IActionResult AllEvents()
        {
            var events = DBMethods.GetAllEvents();
            return Ok(events);
        }

        [HttpPost("insert/{name}")]
        public IActionResult Insert(string name)
        {
            var evt = new Event() { Name=name, CreatedDate = DateTime.Now };
            DBMethods.InsertEvent(evt);
            return Ok("Successful saved Event: "+name);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            DBMethods.DeleteEvent(id);
            return Ok();
        }

        [HttpPut("update/{id}/{name}")]
        public IActionResult UpdateEvent(int id, string name)
        {
            DBMethods.UpdateEvent(id, name);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            var evt = DBMethods.GetSingleEvent(id);
            return Ok(evt);
        }
    }
}
