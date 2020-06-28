﻿using MOZGAMAR.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOZGAMAR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string pesquisa, int? page)
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            return View(viewModel.CreateModel(pesquisa, 8, page));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}