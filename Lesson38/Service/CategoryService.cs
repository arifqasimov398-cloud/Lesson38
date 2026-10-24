using Lesson38.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson38.Service
{
    public class CategoryService(AppDbContext db)
    {
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
        }
        public void DeleteCategory(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }
        public Category GetCategory(int id)
        {
            return db.Categories.Find(id);
        }
        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }
    }

}