using System.Net;
using System.Threading.Tasks;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    var helloRequest = await req.Content.ReadAsAsync<HelloRequest>();
    
    var personToGreet = helloRequest?.Name ?? "world";    
    var responseMessage = $"Hello {personToGreet}!";

    return req.CreateResponse(HttpStatusCode.OK, responseMessage);
}

public class HelloRequest
{
    public string Name { get; set; }
}