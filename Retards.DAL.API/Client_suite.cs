using Microsoft.Extensions.Configuration;

namespace Retards.DAL.API;

  partial class Client
  {
      public Client()
      {
          var buider = new ConfigurationBuilder();
          var config = buider.AddJsonFile("app.json", false, true ).Build();
          BaseUrl = config.GetConnectionString("baseURL");
          _httpClient = new HttpClient();
          
      }
  }