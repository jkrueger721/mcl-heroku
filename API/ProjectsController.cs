using Microsoft.AspNetCore.Mvc;
using MusiCoLab2.Services;
using MusiCoLab2.Modals;
using System;

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
        public IActionResult Create( [FromBody] AddProjectVM vm)
        {

            if (vm.Project == null || vm.UserId == 0)
            {
                return BadRequest();
            }
            
            _service.Add(vm); 
            
            // get current user
            
            return CreatedAtAction("GetProject", new { id = vm.Project.Id });
        }

        // PUT api/values/5
       [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UpdateProjectVM vm)
        {
            if (vm.UpdatedProject == null || vm.UpdatedProject.Id != id)
            {
                return BadRequest();
            } else if ( vm.UserId == 0 )
            {
                return BadRequest();
            }
           
            var project = _service.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            ProjectContributor projectContributor = new ProjectContributor();
            projectContributor.UserId = vm.UserId;
            projectContributor.ProjectId = vm.UpdatedProject.Id;

            _service.AddProjectContributor(projectContributor);

            

            project.Name = vm.UpdatedProject.Name;
            project.Daw = vm.UpdatedProject.Daw;
            project.Comments = vm.UpdatedProject.Comments;
            project.AudioUrl = vm.UpdatedProject.AudioUrl;
            project.Instruments = vm.UpdatedProject.Instruments;
            project.IsPrivate = vm.UpdatedProject.IsPrivate;
            project.Style = vm.UpdatedProject.Style;

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

