using Bolib.com.webui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolib.com.webui.Data
{
    public class CategoryRepository
    {
        private static List<Category> _categories = null;
        static CategoryRepository()
        {
            _categories = new List<Category>
            {
                new Category { CategoryId=1001, CategoryName = "Historic", Description = "So impressive." },
                new Category { CategoryId=1002, CategoryName = "Drama", Description = "So emotional." },
                new Category { CategoryId=1003, CategoryName = "Action", Description = "So excited." },
                new Category { CategoryId=1004, CategoryName = "Horror", Description = "So horrible." }
            };

        }
        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
        public static void AddCategory(Category category)
        {
            _categories.Add(category);
        }
        public static Category GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == id);
        }
    }
}
