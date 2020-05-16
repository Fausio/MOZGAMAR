using Microsoft.Ajax.Utilities;
using MOZGAMAR.DAL;
using MOZGAMAR.Models;
using MOZGAMAR.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOZGAMAR.Controllers
{
    public class AdminController : Controller
    {

        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Category()
        {
            List<Category> allcategories = _unitOfWork.GetRepositoryInstance<Category>().GetAllRecordsIQueryable().Where(x => x.ISDelete == false).ToList();
            return View(allcategories);
        }

        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }


        public ActionResult UpdateCategory(int Id)
        {
            CategoryDetails cd;
            if (Id != 0 & Id > 0)
            {
                cd = JsonConvert.DeserializeObject<CategoryDetails>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Category>().GetFirstOrDefault(Id)));
            }
            else
            {
                cd = new CategoryDetails();
            }

            return View("UpdateCategory", cd);

        }

}
}