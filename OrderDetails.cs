using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4
{
    class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
