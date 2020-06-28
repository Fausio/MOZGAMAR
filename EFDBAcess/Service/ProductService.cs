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
                return genericUnitOfWork.DBEntity.Product.ToList();
            else
            {
                return genericUnitOfWork.DBEntity.Database.SqlQuery<Product>(
                                                                            @"SELECT  p.*
                                                                             FROM	Products AS p
                                                                             LEFT JOIN Categories AS C ON  C.CategoryId = p.CategoryId 
                                                                             WHERE p.Name like '%'+@search+'%'  OR c.Name like '%'+@search+'%'
                                                                             ",
              new SqlParameter("search", search )).ToList();
            }
        } 
    }
}
