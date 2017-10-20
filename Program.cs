using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //1
                var order = db.Orders.Where(x => x.Id == 10248)
                    .Include(o => o.OrderDetails)
                    .ThenInclude(d => d.Product)
                    .ThenInclude(p => p.Category);
                //2
                var shipName = db.Orders.Where(x => x.ShipName == "Hanari Carnes")
                    .Select( o => new { o.Id, o.ShippedDate, o.ShipName, o.ShipCity })
                    .Where(r => r.ShippedDate != null);
                //3
                var orders = db.Orders
                    .Select(o => new { o.Id, o.ShippedDate, o.ShipName, o.ShipCity })
                    .Where(r => r.ShippedDate != null);
                //4
                var orderDetails = db.OrderDetails
                    .Where(x => x.OrderId == 10248)
                    .Include(o => o.Product)
                    .Select(d => new {d.Product.Name, d.Product.UnitPrice, d.Quantity});
                //5
                var productDetails = db.OrderDetails
                    .Where(p => p.ProductId == 10)
                    .Include(oD => oD.Order)
                    .Select(p => new {p.Order.OrderDate, p.UnitPrice, p.Quantity});
                //6
                var product = db.Products
                    .Where(x => x.Id == 10)
                    .Include(oD => oD.OrderDetails)
                    .Select(p => new { p.OrderDetails.Quantity, p.OrderDetails.Discount, p.Name, p.UnitPrice, CategoryName = p.Category.Name });
                //7
                var productSubstring = db.Products
                    .Where(x => x.Name.Contains("Chef"))
                    .Include(c => c.Category)
                    .Select(p => new { p.Name, CategoryName = p.Category.Name });
                //8
                var productsByCategoryId = db.Products
                    .Where(x => x.Category.Id == 8)
                    .Select(p => new { p.Name, CategoryName = p.Category.Name });
                //9 - CREATE
                //var category = new Category { Name = "new object", Description = "This is new" };
                //db.Categories.Add(category);
                //10 - READ
                //var categories = db.Categories.Select(x => new {x.Id, x.Name, x.Description});
                //11 - UPDATE
                //var category = db.Categories.FirstOrDefault(x => x.Id == 11);
                //if (category != null) category.Name = "2017 Testing";
                //12- DELETE
                //db.Categories.Remove(category);
                //var order = db.Orders.FirstOrDefault(x => x.Id == 10248);

                db.SaveChanges();
            }
        }
    }
}
