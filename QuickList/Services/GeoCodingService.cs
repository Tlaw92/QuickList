using Newtonsoft.Json.Linq;
using QuickList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickList.Services
{
    //public class GeoCodingService : IGeoCodingService
    //{
    //    public async Task<Shopper> AttachLatAndLong(Shopper shopper)
    //    {                  https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=32.715738, -117.161084&radius=2000&keyword=Grocery store&key=GOOGLE_API_KEY;
    //        string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={shopper.Address}+{shopper.City}+{shopper.State}+&key={APIKeys.GOOGLE_API_KEY}";
    //        HttpClient client = new HttpClient();
    //        HttpResponseMessage response = await client.GetAsync(url);
    //        string jsonResult = await response.Content.ReadAsStringAsync();
    //        JObject jObject = JObject.Parse(jsonResult);
    //        shopper.Latitude = (double)jObject["results"][0]["geometry"]["location"]["lat"];
    //        shopper.Longitude = (double)jObject["results"][0]["geometry"]["location"]["lng"];
    //        return shopper;
    //    }
    //}
}
