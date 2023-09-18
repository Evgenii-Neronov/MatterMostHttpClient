using MyClient.Domain;
using Newtonsoft.Json;
using System.Text;

namespace MyClient.Infrastructure.MattermostHttpClient.Implementation;

internal class MatterMostHttpClient : IMatterMostClient
{
    private readonly HttpClient _httpClient;

    public MatterMostHttpClient(HttpClient httpClient)
    {
        _httpClient=httpClient;
    }

    public HttpClient HttpClient => _httpClient;

    public string _token = string.Empty;
    public string _userId = string.Empty;

    public async Task<User> Login(string username, string password, CancellationToken ct)
    {
        var httpClient = new HttpClient();
        var apiUrl = "http://host.docker.internal:8065/api/v4/users/login";

        var data = new
        {
            login_id = username,
            password = password
        };

        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(apiUrl, content, ct);
        var responseBody = await response.Content.ReadAsStringAsync();

        var user = JsonConvert.DeserializeObject<User>(responseBody);

        _token = response.Headers?.GetValues("Token")?.FirstOrDefault();
        _userId = user.Id;

        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

        return user;
    }

    public async Task<List<Team>> GetTeamsAsync(CancellationToken ct)
    {
        _httpClient.DefaultRequestHeaders.Clear();
         _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

        var apiUrl = "http://host.docker.internal:8065/api/v4/users/me/teams";

        var teams = await _httpClient.GetAsync<List<Team>>(apiUrl, ct);

        return teams;
    }

    public async Task<List<Channel>> GetChannelsAsync(string teamId, CancellationToken ct)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

        var channelsApiUrl = $"http://host.docker.internal:8065/api/v4/users/{_userId}/teams/{teamId}/channels";

        var channels = await _httpClient.GetAsync<List<Channel>>(channelsApiUrl, ct);

        return channels;
    }

    public async Task<Channel?> GetChannelByNameAsync(string name, CancellationToken ct)
    {
        var teams = await GetTeamsAsync(ct);

        foreach (var team in teams)
        {
            var channels = await GetChannelsAsync(team.Id, ct);
            var channel = channels.FirstOrDefault(x => x.Name == name);

            if (channel != null)
                return channel;
        }

        return null;
    }

    public async Task<Post> PostMessageAsync(string channelId, string messageText, CancellationToken ct)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

        var data = new
        {
            channel_id = channelId,
            message = messageText
        };

        var apiUrl = "http://host.docker.internal:8065/api/v4/posts";

        return await _httpClient.PostAsync<object, Post>(apiUrl, data, ct);
    }
}