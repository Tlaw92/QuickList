    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuickList.Data;
using QuickList.Models;
using QuickList.Services;

namespace QuickList.Controllers
{
    public class GroceryItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroceryItemsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET: GroceryItems/ItemsSearch 
        //GET: 

        public ActionResult SearchProduct()
        {
            return View();
        }

        public async Task<IActionResult> BosieEggs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BosieEggs(string product, string city, int number_days)
        {
            WebRequest request = WebRequest.Create("https://grocerybear.com/getitems");
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";
            request.Headers["api-key"] = "A5B8EE637FA5E82184A2E094444B3016F0A71FB3D11257807D68B470C1A258A2";
            JObject json = new JObject();

            json.Add("city", city);
            json.Add("product", product);
            json.Add("num_days", number_days);

            //string jsonString = json.ToString();
            string jsonString = JsonConvert.SerializeObject(json);

            StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();

            WebResponse response = request.GetResponse();

            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            string responseFromServer = streamReader.ReadToEnd();
            //Is to parse this responseFromServer string into ProductOutPut Model Class

            List<ProductOutput> items = JsonConvert.DeserializeObject<List<ProductOutput>>(responseFromServer);
            streamReader.Close();
            response.Close();

            Console.WriteLine(responseFromServer);
            return View(items);
        }

        public async Task<IActionResult> AddToList(string product, string city, int number_days)
        {
            WebRequest request = WebRequest.Create("https://grocerybear.com/getitems");
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";
            request.Headers["api-key"] = "A5B8EE637FA5E82184A2E094444B3016F0A71FB3D11257807D68B470C1A258A2";
            JObject json = new JObject();

            json.Add("city", city);
            json.Add("product", product);
            json.Add("num_days", number_days);

            //string jsonString = json.ToString();
            string jsonString = JsonConvert.SerializeObject(json);

            StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();

            WebResponse response = request.GetResponse();

            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            string responseFromServer = streamReader.ReadToEnd();
            //Is to parse this responseFromServer string into ProductOutPut Model Class

            List<ProductOutput> items = JsonConvert.DeserializeObject<List<ProductOutput>>(responseFromServer);
            streamReader.Close();
            response.Close();

            Console.WriteLine(responseFromServer);
            return View(items); //RedirectTo Boise eggs view
        }
        //public async task<iactionresult> boiseEggs()
        //{
        //    var client = new restclient("https://grocerybear.com/getitems");
        //    client.timeout = -1;
        //    var request = new restrequest(method.post);
        //    request.addheader("api-key", "a5b8ee637fa5e82184a2e094444b3016f0a71fb3d11257807d68b470c1a258a2");
        //    request.addheader("content-type", "application/json");
        //    request.addparameter("application/json", "{\"city\":\"boise\", \"product\":\"eggs\", \"num_days\": 7}", parametertype.requestbody);
        //    irestresponse response = client.execute(request);
        //    console.writeline(response.content);
        //}



        // GET: GroceryItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroceryItems.ToListAsync());
        }

        // GET: GroceryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryItems = await _context.GroceryItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (groceryItems == null)
            {
                return NotFound();
            }

            return View(groceryItems);
        }

        // GET: GroceryItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroceryItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ProductId,RealCost")] GroceryItems groceryItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groceryItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groceryItems);
        }

        // GET: GroceryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryItems = await _context.GroceryItems.FindAsync(id);
            if (groceryItems == null)
            {
                return NotFound();
            }
            return View(groceryItems);
        }

        // POST: GroceryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ProductId,RealCost")] GroceryItems groceryItems)
        {
            if (id != groceryItems.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groceryItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroceryItemsExists(groceryItems.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(groceryItems);
        }

        // GET: GroceryItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryItems = await _context.GroceryItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (groceryItems == null)
            {
                return NotFound();
            }

            return View(groceryItems);
        }

        // POST: GroceryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groceryItems = await _context.GroceryItems.FindAsync(id);
            _context.GroceryItems.Remove(groceryItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroceryItemsExists(int id)
        {
            return _context.GroceryItems.Any(e => e.ItemId == id);
        }


        //private string GetGeoCodingURL(Shopper shopper)
        //{
        //    return $"https://maps.googleapis.com/maps/api/geocode/json?components=postal_code%3A+{shopper.ZipCode}%7Ccountry%3USA&key="
        //        + APIKeys.GOOGLE_API_KEY;
        //}

        //public async Task<Shopper> GetGeoCoding(Shopper shopper)
        //{
        //    string apiURL = GetGeoCodingURL(shopper);

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(apiURL);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicationException/json"));

        //        HttpResponseMessage response = await client.GetAsync(apiURL);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string data = await response.Content.ReadAsStringAsync();
        //            JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);
        //            JToken results = jsonResults["results"][0];
        //            JToken location = results["geometry"]["location"];

        //            shopper.Latitude = (double)location["lat"];
        //            shopper.Longitude = (double)location["lng"];
        //        }
        //    }

        //    return shopper;
        //}
    }
}
