namespace MyClient.Infrastructure;
public class HttpResponse<T>
{
    public T ResponseObject { get; set; }

    public HttpResponseMessage HttpResponseMessage { get; set; }
}
