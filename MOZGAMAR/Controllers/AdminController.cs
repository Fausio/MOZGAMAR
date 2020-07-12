using Domain;
using MOZGAMAR.Models;
using EFDBAcess.Repository;
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

        public List<SelectListItem> GetCategoty()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var item in _unitOfWork.GetRepositoryInstance<Category>().GetAllRecords().Where(x => x.IsActive == true))
            {
                selectListItems.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.Name });
            }

            return selectListItems;
        }

        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }



        #region Category
        public ActionResult Category()
        {
            List<Category> allcategories = _unitOfWork.GetRepositoryInstance<Category>().GetAllRecordsIQueryable().Where(x => x.IsActive == true).ToList();
            return View(allcategories);
        }
        public ActionResult AddCategory()
        {
            return UpdateOrSaveCategory(0);
        }
        public ActionResult UpdateOrSaveCategory(int Id)
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
        [HttpPost]
        public ActionResult UpdateOrSaveCategory(Category category)
        {
            if (category.CategoryId > 0)
            {
                category.IsActive = true;
                _unitOfWork.GetRepositoryInstance<Category>().Update(category);
            }
            else
            {
                _unitOfWork.GetRepositoryInstance<Category>().Add(category);
            }

            return RedirectToAction("Category");
        }
        #endregion


        #region Product
        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Product>().GetProduct());
        }
        public ActionResult CreateProduct()
        {
            return UpdateProduct(0);
        }
        public ActionResult UpdateProduct(int id)
        {
            ViewBag.GetCategoty = GetCategoty();

            Product product;
            if (id == 0)
            {
                product = new Product();
            }
            else
            {
                product = _unitOfWork.GetRepositoryInstance<Product>().GetFirstOrDefault(id);
            }

            return View("UpdateProduct", product);
        }
        [HttpPost]
        public ActionResult UpdateOrSaveProduct(Product product, HttpPostedFileBase fileBase)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductImage == null)
                {
                    string pic = null;
                    if (fileBase != null)
                    {
                        pic = System.IO.Path.GetFileName(fileBase.FileName);
                        string paht = System.IO.Path.Combine(Server.MapPath("~/ProducIMG/"), pic);

                        fileBase.SaveAs(paht);
                    }
                    product.ProductImage = pic;
                }
              
                if (product.ProductId > 0)
                {
                    product.ModifiedDate = DateTime.Now;
                    _unitOfWork.GetRepositoryInstance<Product>().Update(product);
                }
                else
                {
                    product.CreatedDate = DateTime.Now;
                    _unitOfWork.GetRepositoryInstance<Product>().Add(product);
                }

                return RedirectToAction("Product");
            }
            else
            {
                return RedirectToAction("CreateProduct", product);
            }


        }
        #endregion


    }
}