using blamato.Shared;
using blamato.Shared.Models;
using System.Net.Http.Json;

namespace blamato.Client.Services.ProjectService
{
    public class ProjectService : IProjectService
    {

        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IAuthService _authService;

        public ProjectService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, IAuthService authService)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _authService = authService;
        }

        public async Task<ServiceResponse<Project>> Create(ProjectCreateDTO request)
        {

            Project project = new Project
            {
                Name = request.Name,
                DailyGoal = request.DailyGoal,
                Description = request.Description,
                EndingDate = request.EndingDate,
                Id = request.Id,
                StartingDate = request.StartingDate,
                Visible = true,
                Pomodoros = null
            };

            var response = await _httpClient.PostAsJsonAsync("api/Projects/Create", project);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Project>>();

        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Project>>>("api/Projects/GetProjects");
            return result.Data;
        }

       
    }
}
