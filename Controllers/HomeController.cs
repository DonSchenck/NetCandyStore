using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetCandyStore.Models;
using Newtonsoft.Json;
using RestSharp;

namespace NetCandyStore.Controllers
{
    public class HomeController : Controller
    {
        private CandiesDBEntities db = new CandiesDBEntities();
        public ActionResult Index()
        {
            try
            {
                // Get Category list
                // From database...
                //return View(db.ProductCategories.ToList());
                // From microservice...
                string categoriesMicroserviceURL = Environment.GetEnvironmentVariable("categoriesMicroserviceURL");
                categoriesMicroserviceURL = "http://getcategories-netcandystore.apps.cluster-yorklyn-8097.yorklyn-8097.sandbox902.opentlc.com/categories";
                var client = new RestClient(categoriesMicroserviceURL);
                var response = client.Execute(new RestRequest());
                var listOfCategories = JsonConvert.DeserializeObject<IEnumerable<ProductCategory>>(response.Content);
                return View(listOfCategories);
            } catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "NetCandyStore:dec14.1";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}