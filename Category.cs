using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4
{
    class Category
    {
        [Column("categoryId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
