using Newtonsoft.Json;
using System.Text;

namespace MyClient.Infrastructure;
public static class HttpClientExtensions
{
    public static async Task<TResponse> GetAsync<TResponse>(this HttpClient httpClient, string url, CancellationToken cancellationToken = default)
    {
        using var response = await httpClient.GetAsync(url, cancellationToken);

        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject<TResponse>(responseJson);
    }

    public static async Task<TResponse> PostAsync<TRequest, TResponse>(this HttpClient httpClient, string url, TRequest request, CancellationToken cancellationToken = default)
    {
        var requestJson = JsonConvert.SerializeObject(request);

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        };

        using var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject<TResponse>(responseJson);
    }

    public static async Task<HttpResponse<TResponse>> PostWithResponseAsync<TRequest, TResponse>(
          this HttpClient httpClient,
          string url,
          TRequest request,
          CancellationToken cancellationToken = default)
    {

        var requestJson = JsonConvert.SerializeObject(request);

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        };

        var responseMessage = await httpClient.SendAsync(httpRequest, cancellationToken);
        var responseJson = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
        var responseObject = JsonConvert.DeserializeObject<TResponse>(responseJson);

        return new HttpResponse<TResponse>
        {
            ResponseObject = responseObject,
            HttpResponseMessage = responseMessage
        };
    }

    public static async Task<TResponse> PostFileAsync<TResponse>(this HttpClient httpClient, string url, Stream fileStream, string fileName, string channelId, CancellationToken cancellationToken = default)
    {
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(fileStream), "files", fileName);
        content.Add(new StringContent(channelId), "channel_id");

        using var response = await httpClient.PostAsync(url, content, cancellationToken);

        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject<TResponse>(responseJson);
    }
}