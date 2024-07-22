using Common.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.FetchCoordinates
{
    public class CoordinatesService : ICoordinatesService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public CoordinatesService(IConfiguration configuration,HttpClient httpClient)
        {
            _apiKey= configuration.GetValue<string>("Secret:SecretApiKey");
            _httpClient = httpClient;
        }
        public async Task<Coordinates> GetCoordinates(string address)
        {
            
            var url = $"https://geocode.maps.co/search?q={Uri.EscapeDataString(address)}&api_key={_apiKey}";
            var response = await _httpClient.GetStringAsync(url);

            var geocodeResponses = JsonConvert.DeserializeObject<List<Coordinates>>(response);
            return geocodeResponses?.Count > 0 ? geocodeResponses[0] : null;
        }
    }
}
