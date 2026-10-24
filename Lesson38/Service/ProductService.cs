using Lesson38.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson38.Service
{
    public class ProductService(AppDbContext db)
    {
        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
        public Product GetProduct(int id)
        {
            return db.Products.Find(id);
        }
        public List<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public List<Product> SearchProducts(string text)
        {
            return db.Products.Where(p => p.Name.Contains(text)).ToList();
        }
    }
}
 