#r "Newtonsoft.Json"



using System;

using System.Net;

using System.Threading.Tasks;

using Newtonsoft.Json;



public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)

{

    string jsonContent = await req.Content.ReadAsStringAsync();

    dynamic data = JsonConvert.DeserializeObject(jsonContent);



    if (data.MyData == null ) {

        return req.CreateResponse(HttpStatusCode.BadRequest, new {

            error = "Input incorrect!"

        });

    }

    else

    {

        return req.CreateResponse(HttpStatusCode.OK, new {

            result = $"Complex result {data.MyData}!"

        });

    }

}