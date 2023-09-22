namespace Logistics.Api.Services.Adresses.Models
{
    public class AdressResponseModel
    {
        public List<Result> results { get; set; }
    }

    public class Result
    {
        public List<Location> locations { get; set; }
    }

    public class Location
    {
        public string street { get; set; }

        public string adminArea5 { get; set; }

        public string postalCode { get; set; }
        public string geocodeQualityCode { get; set; }
    }
}
