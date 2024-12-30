using ReposSearchAppServer.Interfaces;
using ReposSearchAppServer.Entities;
using System.Text.Json;
using System.Net.Http.Headers;

namespace ReposSearchAppServer.Services
{
    public class SearchService : BaseService, ISearchInterface
    {
        private readonly HttpClient _httpClient;
        public SearchService(
         AppContext ctx,
         ILogger<SearchService> logger,
         HttpClient httpClient) : base(ctx, logger)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Repository>> SearchRepos(string searchTerm)
        {
            var url = $"https://api.github.com/search/repositories?q={searchTerm}";
            //Add my github token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", "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");
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ReposSearchApp/1.0");

            try
            {
                //get the data
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var searchResult = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(content);

                if (searchResult.TryGetValue("items", out var items) && items.ValueKind == JsonValueKind.Array)
                {
                    var repositories = new List<Repository>();
                    foreach (var item in items.EnumerateArray())
                    {
                        //Insert the data into an array from Repository class
                        repositories.Add(new Repository
                        {
                            Id = item.GetProperty("id").GetDecimal(),
                            Name = item.GetProperty("name").GetString(),
                            AvatarUrl = item.GetProperty("owner").GetProperty("avatar_url").GetString(),
                            HtmlUrl = item.GetProperty("html_url").GetString(),
                        });
                    }
                    return repositories;
                }
                else
                {
                    return new List<Repository>(); // Return an empty list if no repositories are found
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching repositories from GitHub API: {ex.Message}");
            }
        }
    }
}
