using blamato.Shared;
using blamato.Shared.Models;
using System.Net.Http.Json;

namespace blamato.Client.Services.ProjectService
{
    public class ProjectService : IProjectService
    {

        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public ProjectService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Project>>>("api/Projects/GetProjects");
            return result.Data;
        }
    }
}
