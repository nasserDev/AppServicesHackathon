#r "System.IO"
#r "System.Runtime"
#r "System.Threading.Tasks"
#r "Microsoft.WindowsAzure.Storage"
#r "Newtonsoft.Json"

  using System;
  using System.Net;
  using System.IO;
  using System.Text;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.WindowsAzure.Storage.Table;
  using Newtonsoft.Json;


// This function read from table storage and return HTTP Response as JSON
  public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, IQueryable<StorageTable> inputTable,  TraceWriter log)
  {

      var result = new List<SimpleStorageTable>();

      var query = from StorageTable in inputTable select StorageTable;

      foreach (StorageTable StorageTable in query)
      {
          result.Add( new SimpleStorageTable(){Text = StorageTable.Text, Uri = StorageTable.Uri});
      }

      return  req.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(result));
  }



  public class StorageTable : TableEntity
  {
      public string Text { get; set; }
      public string Uri {get; set; }
  }

  public class SimpleStorageTable
  {
      public string Text { get; set; }
      public string Uri {get; set; }
  }