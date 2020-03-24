using Microsoft.AspNetCore.Mvc;
using MusiCoLab2.Services;
using MusiCoLab2.Modals;
using System;
using MusiCoLab2.Models;
using System.Collections.Generic;

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
        public List<IProject> Get()
        {
            var projects = _service.GetProjects();
            return projects;
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

            // if (vm.Project == null || vm.UserId == 0)
            // {
            //     return BadRequest();
            // }
            
            _service.Add(vm); 
             return CreatedAtAction("GetProject", new { id = vm.Id });
            // get current user
            
            // return CreatedAtAction("GetProject", new { id = vm.Project.Id });
        }

        // PUT api/values/5
       [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UpdateProjectVM vm)
        {
            if (vm == null || vm.Id != id)
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
            projectContributor.ProjectId = vm.Id;

            _service.AddProjectContributor(projectContributor);

            

            project.Name = vm.Name;
            project.Daw = vm.Daw;
            project.Comments = vm.Comments;
            project.AudioUrl = vm.AudioUrl;
            project.Instruments = vm.Instruments;
            project.IsPrivate = vm.IsPrivate;
            project.Style = vm.Style;

            _service.Update(project);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpPost("{id}")]
        public IActionResult Delete(long id, [FromBody] ProjectDeleteVM vm)
        {
            try
            {
                var project = _service.FindWithOwner(id);

                

                if (project == null)
                {
                    return NotFound();
                }

                if (vm.UserId == project.ProjectOwner.Id)
                {
                    _service.Remove(id);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Content(id.ToString());
        }
    }
}

