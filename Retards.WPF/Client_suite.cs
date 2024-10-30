using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace Retards.WPF;

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