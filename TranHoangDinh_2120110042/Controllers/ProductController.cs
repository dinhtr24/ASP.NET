using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranHoangDinh_2120110042.Context;

namespace TranHoangDinh_2120110042.Controllers
{
    public class ProductController : Controller
    {
        ElectronicEntities db = new ElectronicEntities();
        // GET: Product
        public ActionResult Detail(int id)
        {
            return View(db.Products.Find(id));
        }

        public ActionResult AllProduct(int id)
        {
            var lstProduct = db.Products.Where(x=>x.CategoryId == id).ToList();
            return View(lstProduct);
        }
    }
}