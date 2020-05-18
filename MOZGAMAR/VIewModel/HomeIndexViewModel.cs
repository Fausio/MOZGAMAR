using MOZGAMAR.DAL;
using MOZGAMAR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOZGAMAR.VIewModel
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _UnitOfWork = new GenericUnitOfWork();

        public IEnumerable<Poduct> LiftOfproducts = new List<Poduct>();

        public HomeIndexViewModel CreateModel()
        {
            return new HomeIndexViewModel()
            {
                LiftOfproducts = _UnitOfWork.GetRepositoryInstance<Poduct>().GetAllRecords()
            };
        }
    }
}

