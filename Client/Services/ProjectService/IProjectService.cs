using blamato.Shared;
using blamato.Shared.Models;

namespace blamato.Client.Services.ProjectService
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjectsAsync();
    }
}
