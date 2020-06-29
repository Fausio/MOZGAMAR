using Domain;
using EFDBAcess.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBAcess.Service
{
    public class ProductService
    { 
        private GenericUnitOfWork genericUnitOfWork = new GenericUnitOfWork();
       
        public List<Product> GetProductAndCaregoryByName(string search)
        {
            if (search == null)
                return genericUnitOfWork.DBEntity.Product.OrderByDescending(x => x.CreatedDate).ToList();
            else
            {
                return genericUnitOfWork.DBEntity.Database.SqlQuery<Product>(
                                                                            @"SELECT  p.*
                                                                             FROM	Products AS p
                                                                             LEFT JOIN Categories AS C ON  C.CategoryId = p.CategoryId 
                                                                             WHERE p.Name like '%'+@search+'%'  OR c.Name like '%'+@search+'%'
                                                                             ORDER BY CreatedDate DESC
                                                                             ",
              new SqlParameter("search", search )).ToList();
            }
        }

        public List<Product> GetTop4Produc()
        {
            return genericUnitOfWork.DBEntity.Product.OrderByDescending(x => x.CreatedDate).Take(4).ToList();
        }

        public Product GetProductById(int id)
        {
            return genericUnitOfWork.DBEntity.Product.Find(id);
        }
    }
}
