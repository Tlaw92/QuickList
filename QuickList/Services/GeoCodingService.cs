using Newtonsoft.Json.Linq;
using QuickList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickList.Services
{
    public class GeoCodingService : IGeoCodingService
    {
        public async Task<Shopper> AttachLatAndLong(Shopper shopper)
        {
            string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?radius=2000&key=AIzaSyC2Uyq82S9tdxWSHz4c4eI4E1IEHqjkaFg&location=40.748817,-73.985428&type=grocery_or_supermarket&rankby=prominence";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(jsonResult);
            shopper.Latitude = (double)jObject["results"][0]["geometry"]["location"]["lat"];
            shopper.Longitude = (double)jObject["results"][0]["geometry"]["location"]["lng"];
            return shopper;
        }

        public async Task<Location> GetLocation(string Address)
        {
            Location location = new Location();
            string shopperAddress = "https://maps.googleapis.com/maps/api/geocode/json?address="+Address+"&key="+APIKeys.GOOGLE_API_KEY+"";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(shopperAddress);
            string jsonResult = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(jsonResult);
            

            return location;
        }


    }
}

//string url2 = https://maps.googleapis.com/maps/api/place/nearbysearch/json?radius=2000&key=AIzaSyC2Uyq82S9tdxWSHz4c4eI4E1IEHqjkaFg&location=40.748817,-73.985428&type=grocery_or_supermarket&rankby=prominence;
//string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={shopper.Address}+{shopper.City}+{shopper.State}+&key={APIKeys.GOOGLE_API_KEY}";
