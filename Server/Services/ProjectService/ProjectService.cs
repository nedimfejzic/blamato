using blamato.Server.Data;
using blamato.Server.Services.AuthService;
using Microsoft.EntityFrameworkCore;

namespace blamato.Server.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly DataContext _dataContext;
        private readonly IAuthService _authService;

        public ProjectService(DataContext dataContext, IAuthService authService)
        {
            _dataContext = dataContext;
            _authService = authService;
        }

        public async Task<ServiceResponse<Project>> CreateProject(Project project)
        {
            project.UserId=_authService.GetUserId();
            _dataContext.Projects.Add(project);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<Project>
            {
                Data = project
            };
        }

        public Task<ServiceResponse<Project>> GetProjectAsync(int projectId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Project>>> GetProjectsAsync()
        {

            var response = new ServiceResponse<List<Project>>
            {
                Data = await _dataContext.Projects
                    .Where(p => p.Visible == true && p.UserId ==  _authService.GetUserId())
                    .ToListAsync()
            };

            return response;
        }

        public Task<ServiceResponse<bool>> HideProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Project>> UpdateProjectAsync(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
