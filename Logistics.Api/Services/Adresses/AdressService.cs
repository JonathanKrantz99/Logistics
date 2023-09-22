using Logistics.Api.Common;
using Logistics.Api.Services.Adresses.Models;
using Newtonsoft.Json;

namespace Logistics.Api.Services.Adresses
{
    internal class AdressService
    {
        private readonly HttpClient _httpClient;

        public AdressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> IsRealAdress(Address warehouseAddress)
        {
            var request = new
            {
                location = new
                {
                    street = $"{warehouseAddress.StreetNumber} {warehouseAddress.Street}",
                    city = warehouseAddress.City,
                    postalCode = warehouseAddress.PostalCode,
                    country = "Sweden"
                },
                options = new
                {
                    maxResults = 1
                }
            };

            string json = JsonConvert.SerializeObject(request);

            var res = await _httpClient.PostAsync("geocoding/v1/address?key=x7ikSFbnivHXP2tb8ZGN3PE0k6cHK7Mf", new StringContent(json));

            if (!res.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching address from API. Message: {res.ReasonPhrase}");
            }

            var adressResponseMopdel = JsonConvert.DeserializeObject<AdressResponseModel>(await res.Content.ReadAsStringAsync());

            bool valid = false;

            foreach (var result in adressResponseMopdel.results)
            {
                var location = result.locations.FirstOrDefault();

                if (location.geocodeQualityCode == "P1AAA") // Perfect match
                {
                    valid = true;
                }
            }

            return valid;
        }

        public async Task<double> GetDistance(Address startPointAddress, Address endPointAddress)
        {
            var startPoint = new
            {
                street = $"{startPointAddress.StreetNumber} {startPointAddress.Street}",
                city = startPointAddress.City,
                postalCode = startPointAddress.PostalCode,
                country = "Sweden"
            };

            var endPoint = new
            {
                street = $"{endPointAddress.StreetNumber} {endPointAddress.Street}",
                city = endPointAddress.City,
                postalCode = endPointAddress.PostalCode,
                country = "Sweden"
            };

            var request = new
            {
                locations = new[]
                {
                    startPoint,
                    endPoint
                },
                options = new
                {
                    unit = "k",
                    routeType = "shortest"
                }
            };

            string json = JsonConvert.SerializeObject(request);

            var res = await _httpClient.PostAsync("directions/v2/routematrix?key=x7ikSFbnivHXP2tb8ZGN3PE0k6cHK7Mf", new StringContent(json));

            if (!res.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching distances from API. Message: {res.ReasonPhrase}");
            }

            var adressResponseMopdel = JsonConvert.DeserializeObject<DistanceResponseModel>(await res.Content.ReadAsStringAsync());

            return adressResponseMopdel.distance[1];
        }
    }
}
