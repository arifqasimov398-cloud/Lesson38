using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson38.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  int CategoryId { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int StockQuantity { get; set; }
    }
}

