using MyClient.Domain;

namespace MyClient.Infrastructure.MattermostHttpClient.Implementation;

internal class MatterMostHttpClient : IMatterMostClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public MatterMostHttpClient(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public HttpClient HttpClient => _httpClient;

    public string _token = string.Empty;
    public string _userId = string.Empty;

    public async Task<User> Login(string username, string password, CancellationToken cancellationToken)
    {

        var httpClient = new HttpClient();

        var apiUrl = BuildApiUrl("api/v4/users/login");

        var data = new
        {
            login_id = username,
            password = password
        };

        var response = await httpClient.PostWithResponseAsync<object, User>(apiUrl, data, cancellationToken);

        _token = response.HttpResponseMessage.Headers.GetValues("Token").FirstOrDefault();
        _userId = response.ResponseObject.Id;

        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

        return response.ResponseObject;
    }

    public async Task<List<Team>> GetTeamsAsync(CancellationToken ct)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

        var apiUrl = BuildApiUrl("api/v4/users/me/teams");

        var teams = await _httpClient.GetAsync<List<Team>>(apiUrl, ct);

        return teams;
    }

    public async Task<List<Channel>> GetChannelsAsync(string teamId, CancellationToken ct)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

        var apiUrl = BuildApiUrl($"api/v4/users/{_userId}/teams/{teamId}/channels");

        var channels = await _httpClient.GetAsync<List<Channel>>(apiUrl, ct);

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

        var apiUrl = BuildApiUrl($"api/v4/posts");

        return await _httpClient.PostAsync<object, Post>(apiUrl, data, ct);
    }

    private string BuildApiUrl(string apiEndpoint)
    {
        return $"{_baseUrl}/{apiEndpoint}";
    }
}