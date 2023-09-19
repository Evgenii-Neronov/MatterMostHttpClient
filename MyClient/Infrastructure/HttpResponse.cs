using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClient.Infrastructure;
public class HttpResponse<T>
{
    public T ResponseObject { get; set; }

    public HttpResponseMessage HttpResponseMessage { get; set; }
}
