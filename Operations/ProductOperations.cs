using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Operations
{
    class ProductOperations
    {
        //6. Get a single product by ID
        public dynamic GetProduct(NorthwindContext db, int id)
        {
            var product = db.Products
                .Where(x => x.Id == id)
                .Include(oD => oD.OrderDetails)
                .Select(p => new { p.OrderDetails.Quantity, p.OrderDetails.Discount, p.Name, p.UnitPrice, CategoryName = p.Category.Name });

            return product;
        }

        //7. Get a list of products that contains a substring
        public dynamic GetProductsBySubstring(NorthwindContext db, string sub)
        {
            var products = db.Products
                .Where(x => x.Name.Contains(sub))
                .Include(c => c.Category)
                .Select(p => new { p.Name, CategoryName = p.Category.Name });

            return products;
        }

        //8. Get products by category ID
        public dynamic GetProductsByCategoryId(NorthwindContext db, int id)
        {
            var products = db.Products
                .Where(x => x.Category.Id == id)
                .Select(p => new { p.Name, CategoryName = p.Category.Name });

            return products;
        }
    }
}
