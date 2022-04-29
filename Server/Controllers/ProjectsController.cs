using blamato.Server.Services.ProjectService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blamato.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService project)
        {
            _projectService = project;
        }

        [HttpGet("GetProjects"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<Project>>>> GetProjects()
        {
            var result = await _projectService.GetProjectsAsync();
            return Ok(result);
        }


        [HttpPost("Create"), Authorize]
        public async Task<ActionResult<ServiceResponse<Project>>> CreateProject(Project project)
        {
            var result = await _projectService.CreateProject(project);
            return Ok(result);
        }
    }
}
