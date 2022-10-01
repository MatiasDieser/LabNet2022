using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.PracticaLINQ.Entities;

namespace Lab.PracticaLINQ.Logic
{
    public class ProductsLogic : BaseLogic,ICommonMethods<Products>
    {
        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }
        public List<Products> GetNonStockProducts()
        {
            var stockQuery = context.Products.Where(p => p.UnitsInStock.Value == 0).
                             OrderBy(p => p.ProductName).
                             Select(p => p);
            
            return stockQuery.ToList();
        }
        public List<Products> GetStockedProducts()
        {
            var stockQuery = from products in context.Products
                        where products.UnitsInStock > 0 &&
                        products.UnitPrice > 3
                        select products;
            
            return stockQuery.ToList();
        }
        public List<Products> GetProductByID()
        {
            var productQuery = from product in context.Products
                               where product.ProductID == 789
                               select product;

            return productQuery.ToList();
        }
        public List<Products> GetOrderedProducts()
        {
            var productQuery = context.Products.
                             OrderBy(p => p.ProductName).
                             Select(p => p);

            return productQuery.ToList();
        }
        public List<Products> GetProductsByStock()
        {
            var productQuery = from product in context.Products
                               orderby product.UnitsInStock descending
                               select product;

            return productQuery.ToList();
        }
        public List<Products> GetAssociatedCategories()
        {
            var productQuery = from products in context.Products
                                  join categories in context.Categories on
                                  products.CategoryID equals categories.CategoryID
                                  orderby products.ProductID ascending
                                  select products;

            return productQuery.ToList();
        }
        public List<Products> GetFirstProduct()
        {
            var productQuery = context.Products.Select(p => p).Take(1);

            return productQuery.ToList();
        }
    }
}
