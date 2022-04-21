namespace blamato.Server.Services.ProjectService
{
    public interface IProjectService
    {
        Task<ServiceResponse<List<Project>>> GetProjectsAsync();
        Task<ServiceResponse<Project>> GetProjectAsync(int projectId);
        Task<ServiceResponse<Project>> CreateProject(Project project);
        Task<ServiceResponse<Project>> UpdateProjectAsync(Project project);
        Task<ServiceResponse<bool>> HideProject(int projectId);
    }
}
