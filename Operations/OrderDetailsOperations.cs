using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Operations
{
    class OrderDetailsOperations
    {
        //4. Get the details for a specific order ID
        public static dynamic GetOrderDetails(NorthwindContext db, int id)
        {
            var orderDetails = db.OrderDetails
                .Where(x => x.OrderId == id)
                .Include(o => o.Product)
                .Select(d => new { d.Product.Name, d.Product.UnitPrice, d.Quantity });

            return orderDetails;
        }

        //5. Get the details for a specific product ID
        public static dynamic GetProductDetails(NorthwindContext db, int id)
        {
            var productDetails = db.OrderDetails
                .Where(p => p.ProductId == id)
                .Include(oD => oD.Order)
                .Select(p => new { p.Order.OrderDate, p.UnitPrice, p.Quantity });
            return productDetails;
        }
    }
}
