using MOZGAMAR.DAL;
using MOZGAMAR.Repository;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOZGAMAR.VIewModel
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _UnitOfWork = new GenericUnitOfWork();
        MOZGAMEREntities context = new MOZGAMEREntities();

        public IPagedList<Poduct> LiftOfproducts { get; set; }

        public HomeIndexViewModel CreateModel(string pesquisa, int pageSize, int? page)
        {
            SqlParameter[] sql = new SqlParameter[] { new SqlParameter("@search", pesquisa ?? (object)DBNull.Value) };
            IPagedList<Poduct> DataFilter = context.Database.SqlQuery<Poduct>("GEtBySerach @search", sql).ToList().ToPagedList(page ?? 1, pageSize);

            return new HomeIndexViewModel()
            {
                LiftOfproducts = DataFilter
            };
        }
    }
}

