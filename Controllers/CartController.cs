using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCandyStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(int? itemId = 1)
        {
            // Add to cart
//            List<GetProductsByCategoryId_Result> r = db.GetProductsByCategoryId(categoryId).ToList();

            // Return cart contents to View
            return View();
        }
    }
}