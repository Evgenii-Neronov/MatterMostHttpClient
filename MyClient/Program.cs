using MyClient.Infrastructure.MattermostHttpClient.Implementation;

const string Login = "e.neronov@dhrp.ru";
const string Password = "12345678";
var ct = CancellationToken.None;


var matterMostHttpClient = new MatterMostHttpClient(new HttpClient());
await matterMostHttpClient.Login(Login, Password, ct);
var channel = await matterMostHttpClient.GetChannelByNameAsync("off-topic", ct);

if(channel != null)
{
    await matterMostHttpClient.PostMessageAsync(channel.Id, "This is my test 1234 !", ct);
}