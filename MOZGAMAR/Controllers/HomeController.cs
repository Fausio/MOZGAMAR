using Domain;
using EFDBAcess;
using EFDBAcess.Repository;
using MOZGAMAR.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOZGAMAR.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext dbcontext = new ApplicationDbContext();
        public ActionResult Index(string pesquisa, int? page)
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            return View(viewModel.CreateModel(pesquisa, 8, page));
        }

        public ActionResult AddProductToMyCart(int id)
        {
            List<ProductItem> Mycart;  
            if (Session["Mycart"] == null)
            {
               Mycart = new List<ProductItem>();
            }
            else
            {
               Mycart = (List<ProductItem>)Session["Mycart"];
            }
            var product = dbcontext.Product.Find(id);

            Mycart.Add(new ProductItem() { Product = product, QuantityOfProductItem = 1 });

            Session["Mycart"] = Mycart;
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromMyCart(int id)
        {
            var Mycart = (List<ProductItem>)Session["Mycart"];
          
            foreach (var item in Mycart)
            {
                if (item.Product.ProductId == id)
                {
                    Mycart.Remove(item);
                    break;
                }
            }

            Session["Mycart"] = Mycart;
            return RedirectToAction("Index");
        }
    }
}