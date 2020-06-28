using EFDBAcess;
using Domain;
using EFDBAcess.Repository;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBAcess.Service;

namespace MOZGAMAR.VIewModel
{
    public class HomeIndexViewModel
    { 
        ProductService ProductServices = new ProductService();
        public IPagedList<Product> LiftOfProducts { get; set; }

        public HomeIndexViewModel CreateModel(string pesquisa, int pageSize, int? page)
        {
            IPagedList<Product> DataFilter = ProductServices.GetProductAndCaregoryByName(pesquisa).ToPagedList(page ?? 1, pageSize);
            return new HomeIndexViewModel()
            {
                LiftOfProducts = DataFilter
            };
        }
    }
}

