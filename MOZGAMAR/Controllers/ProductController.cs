using Domain;
using EFDBAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBAcess.Service;
using Microsoft.Ajax.Utilities;

namespace MOZGAMAR.Controllers
{
    public class ProductController : Controller
    {
        private ProductService ps = new ProductService();
        public ActionResult Product(int id)
        {
            ViewBag.Top4 = ps.GetTop4Produc();
            return View(ps.GetProductById(id));
        }
    }
}