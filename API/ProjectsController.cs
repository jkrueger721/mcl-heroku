using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusiCoLab2.Models;
using MusiCoLab2.Services;


namespace MusiCoLab2.API
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private IProjectService _service;
        public ProjectsController(IProjectService service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var projects = _service.GetProjects();
            return Ok(projects);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult GetById(long id)
        {
            var item = _service.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] Project item)
        {
           
            if (item == null)
            {
                return BadRequest();
            }

            _service.Add(item);

            // get current user
            // add new ProjectUser to database (include userId and projectId)
           


            return CreatedAtAction("GetProject", new { id = item.Id });
        }

        // PUT api/values/5
       // [HttpPut("update/{id}/{projectUpdate}")]
       [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Project projectUpdate)
        {
            if (projectUpdate == null || projectUpdate.Id != id)
            {
                return BadRequest();
            }

            var project = _service.Find(id);
            if (project == null)
            {
                return NotFound();
            }

           // project.IsComplete = projectUpdate.IsComplete;
            project.Name = projectUpdate.Name;

            _service.Update(project);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var project = _service.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            _service.Remove(id);
            return new NoContentResult();
        }
    }
}

