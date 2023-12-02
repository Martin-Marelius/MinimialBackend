using BackendService.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BackendService.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class DynamicController : ControllerBase
    {
        private readonly IMemoryDatabase<dynamic> _memoryDatabase;

        public DynamicController(IMemoryDatabase<dynamic> memoryDatabase)
        {
            _memoryDatabase = memoryDatabase;
        }

        [HttpGet]
        public IEnumerable<dynamic> GetAll()
        {
            return _memoryDatabase.GetAll();
        }

        [HttpGet("{id}/{type}")]
        public ActionResult<dynamic> GetById(int id, string type)
        {
            var entity = _memoryDatabase.GetById(id, type);

            if (entity is null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpGet("{type}")]
        public IActionResult GetByType(string type)
        {
            var entities = _memoryDatabase.GetByType(type);

            if (!entities.Any())
            {
                return NotFound();
            }

            return Ok(entities);
        }

        [HttpPost("{id}/{type}")]
        public IActionResult Add(int id, string type, [FromBody] dynamic body)
        {
            _memoryDatabase.Add(id, type, body);
            return Ok();
        }

        [HttpPut("{id}/{type}")]
        public IActionResult Update(int id, string type, [FromBody] dynamic updatedEntity)
        {
            _memoryDatabase.Update(id, type, updatedEntity);
            return Ok();
        }

        [HttpDelete("{id}/{type}")]
        public IActionResult Delete(int id, string type)
        {
            _memoryDatabase.Delete(id, type);
            return Ok();
        }
    }
}
