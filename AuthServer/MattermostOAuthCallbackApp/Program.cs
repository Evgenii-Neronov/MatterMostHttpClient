var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting();

builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.MapGet("/callback", async context =>
{
    var authCode = context.Request.Query["code"];
    if (string.IsNullOrEmpty(authCode))
    {
        await context.Response.WriteAsync("No authorization code provided.");
        return;
    }

    // Получаем HttpClient через Dependency Injection
    var httpClient = context.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();

    var tokenRequestData = new Dictionary<string, string>
    {
        ["client_id"] = "5ap36j453fdfud8w19uquywndo", // Замените на ваш Client ID
        ["client_secret"] = "hqqjcx7997d18nyzg7kqo8jf1w", // Замените на ваш Client Secret
        ["code"] = authCode,
        ["grant_type"] = "authorization_code",
        ["redirect_uri"] = "http://host.docker.internal:7777/" // Ваш Redirect URI
    };

    // Этот URL может отличаться в зависимости от версии и настроек Mattermost.
    
    var response = await httpClient.PostAsync("http://host.docker.internal:8065/api/v4/oauth/access_token", new FormUrlEncodedContent(tokenRequestData));

    if (response.IsSuccessStatusCode)
    {
        var responseData = await response.Content.ReadAsStringAsync();
        await context.Response.WriteAsync($"Token response: {responseData}");
    }
    else
    {
        await context.Response.WriteAsync($"Error fetching token: {response.StatusCode}");
    }
});

app.Run();
