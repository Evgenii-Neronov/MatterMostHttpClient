using MyClient.Domain;
using Newtonsoft.Json;
using System.Text;

const string Login = "e.neronov@dhrp.ru";
const string Password = "12345678";

var token = "";
var userId = "";
var teamId = "";
var channelId = "";

{
    var httpClient = new HttpClient();
    var apiUrl = "http://host.docker.internal:8065/api/v4/users/login";

    var data = new
    {
        login_id = Login,
        password = Password
    };

    var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
    //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer 1okfyjt7fb8e7kbmcsh43ro45y");

    var response = await httpClient.PostAsync(apiUrl, content);
    var responseBody = await response.Content.ReadAsStringAsync();

    var user = JsonConvert.DeserializeObject<MyUser>(responseBody);

    token = response.Headers.GetValues("Token").FirstOrDefault();

    // Обработка ответа
    Console.WriteLine(responseBody);
    Console.WriteLine(token);
    Console.WriteLine($"USER_ID: {user.id}");

    userId = user.id;

}

// teams
{
    var httpClient = new HttpClient();
    var apiUrl = "http://host.docker.internal:8065/api/v4/users/me/teams";

    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

    var response = await httpClient.GetAsync(apiUrl);
    var responseBody = await response.Content.ReadAsStringAsync();

    var teams = JsonConvert.DeserializeObject<MyTeam[]>(responseBody);

    // Обработка ответа
    Console.WriteLine($"TEAM_ID: {teams?.FirstOrDefault()?.id}");

    teamId = teams?.FirstOrDefault()?.id;
}

{
    var httpClient = new HttpClient();
    var channelsApiUrl = $"http://host.docker.internal:8065/api/v4/users/{userId}/teams/{teamId}/channels";
    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

    var channelsResponse = await httpClient.GetAsync(channelsApiUrl);
    if (channelsResponse.IsSuccessStatusCode)
    {
        var str = await channelsResponse.Content.ReadAsStringAsync();
        var channels = JsonConvert.DeserializeObject<List<MyChannel>>(str);

        var offTopicChannel = channels?.FirstOrDefault(ch => ch.name == "off-topic");

        if (offTopicChannel != null)
        {
            channelId = offTopicChannel.id;
            Console.WriteLine($"CHANNEL_ID: {channelId}");
        }
    }
}

// user Id: 945mea56jtfs5pgbtg9sjqw64a
{
    var httpClient = new HttpClient();
    var apiUrl = "http://host.docker.internal:8065/api/v4/posts";

    var data = new
    {
        channel_id = channelId,
        message = "Hello world!"
    };

    var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

    var response = await httpClient.PostAsync(apiUrl, content);
    var responseBody = await response.Content.ReadAsStringAsync();

    // Обработка ответа
    Console.WriteLine(responseBody);
}