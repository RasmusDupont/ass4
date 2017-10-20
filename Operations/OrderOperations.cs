using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Operations
{
    class OrderOperations
    {
        //1. Get a single order by ID
        public static dynamic GetOrderById(NorthwindContext db, int id)
        {
            var order = db.Orders.Where(x => x.Id == id)
                .Include(o => o.OrderDetails)
                .ThenInclude(d => d.Product)
                .ThenInclude(p => p.Category);

            return order;
        }

        //2. Get order by shipping name
        public static dynamic GetOrderByShippingName(NorthwindContext db, string name)
        {
            var order = db.Orders.Where(x => x.ShipName == name)
                .Select(o => new { o.Id, o.ShippedDate, o.ShipName, o.ShipCity })
                .Where(r => r.ShippedDate != null);

            return order;
        }

        //3. List all orders
        public static dynamic GetAllOrders(NorthwindContext db)
        {
            var orders = db.Orders
                .Select(o => new { o.Id, o.ShippedDate, o.ShipName, o.ShipCity })
                .Where(r => r.ShippedDate != null);

            return orders;
        }
    }
}
