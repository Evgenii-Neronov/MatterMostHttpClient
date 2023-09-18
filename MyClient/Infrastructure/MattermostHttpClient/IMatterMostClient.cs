using MyClient.Domain;

namespace MyClient.Infrastructure.MattermostHttpClient;

internal interface IMatterMostClient
{
    Task<User> Login(string username, string password, CancellationToken ct);
}
