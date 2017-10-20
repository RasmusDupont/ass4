using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment4.Operations
{
    class CategoryOperations
    {
        //9. Get category by ID
        public static dynamic GetCategory(NorthwindContext db, int id)
        {
            var category = db.Categories
                .Where(x => x.Id == id);
            //.Select(c => c);

            return category;
        }

        //10. Get all categories
        public static dynamic GetAllCategories(NorthwindContext db)
        {
            var categories = db.Categories.Select(x => new { x.Id, x.Name, x.Description });

            return categories;
        }

        //11. Add new category
        public static dynamic AddCategory(NorthwindContext db, string name, string description)
        {
            var category = new Category { Name = "new object", Description = "This is new" };
            db.Categories.Add(category);
            db.SaveChanges();

            return category;
        }

        //12. Update category
        public static bool UpdateCategory(NorthwindContext db, int id, string name)
        {
            try
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == 11);
                if (category != null) category.Name = name;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //13. Delete category
        public static bool DeleteCategory(NorthwindContext db, int id)
        {
            try
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == id);
                db.Categories.Remove(category);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
