using MyClient.Domain;
using MyClient.Infrastructure.MattermostHttpClient.Implementation;


// INPUT DATA
const string Login = "e.neronov@dhrp.ru";
const string Password = "12345678";
var ct = CancellationToken.None;

//var filePath = @"C:\Users\eneronov\Desktop\my_file.txt";
var filePath = @"C:\Users\eneronov\Desktop\pikachu.gif";
using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
//////////////


var matterMostHttpClient = new MatterMostHttpClient(new HttpClient(), "http://host.docker.internal:8065");

await matterMostHttpClient.Login(Login, Password, ct);
var channel = await matterMostHttpClient.GetChannelByNameAsync("off-topic", ct);

if (channel != null)
{
    await matterMostHttpClient.PostMessageAsync(channel.Id, "This is my test 12345 !", ct);

    //var fileIds = await matterMostHttpClient.UploadFileAsync(fileStream, "my_file.txt", channel.Id, ct);
    var fileIds = await matterMostHttpClient.UploadFileAsync(fileStream, "pikachu.gif", channel.Id, ct);

    await matterMostHttpClient.PostMessageWithFilesAsync(channel.Id, "Mesage with file", fileIds, ct);

    await matterMostHttpClient.PostMessageWithButtonsAsync(channel.Id, "Сообщение с кнопкой", "Выбери свой вариант", new List<Button>()
    {
        new Button()
        {
            Name = "Кнопка 1",
            Url = "http://ya.ru",
            Context = new { test = "test 1" }
        },
        new Button()
        {
            Name = "Кнопка 2",
            Url = "http://ya.ru",
            Context = new { test = "test 2" }
        }
    }, ct);

    Console.WriteLine($"file ids: {string.Join(", ", fileIds)}");
}