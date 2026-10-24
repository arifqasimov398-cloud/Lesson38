using Lesson38.Data;
using Lesson38.Service;

namespace Lesson38
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(config.GetConnectionString("Default"))
                .Options;
            AppDbContext context = new AppDbContext(options);
            
            CategoryService categoryService = new CategoryService(context);
            ProductService productService = new ProductService(context);

            while (true)
            { 
                Console.WriteLine();
                Console.WriteLine("===== ANBAR PROQRAMI =====");
                Console.WriteLine("1 - Kateqoriya əlavə et");
                Console.WriteLine("2 - Kateqoriyalara bax");
                Console.WriteLine("3 - Kateqoriyanı yenilə");
                Console.WriteLine("4 - Kateqoriyanı sil");
                Console.WriteLine("5 - Məhsul əlavə et");
                Console.WriteLine("6 - Məhsullara bax");
                Console.WriteLine("7 - Məhsul axtar");
                Console.WriteLine("8 - Məhsulu yenilə");
                Console.WriteLine("9 - Məhsulu sil");
                Console.WriteLine("0 - Çıxış");
                Console.Write("Seçim: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Category category = new Category();

                    Console.Write("Kateqoriya adı: ");
                    category.Name = Console.ReadLine();

                    categoryService.AddCategory(category);
                    Console.WriteLine("Kateqoriya əlavə olundu.");
                }
                else if (choice == "2")
                {
                    var categories = categoryService.GetAllCategories();

                    foreach (var item in categories)
                    {
                        Console.WriteLine(item.Id + " - " + item.Name);
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Kateqoriyanın Id-si: ");
                    int id = int.Parse(Console.ReadLine());

                    var category = categoryService.GetCategory(id);

                    if (category == null)
                    {
                        Console.WriteLine("Kateqoriya tapılmadı.");
                    }
                    else
                    {
                        Console.Write("Yeni ad: ");
                        category.Name = Console.ReadLine();

                        categoryService.UpdateCategory(category);
                        Console.WriteLine("Kateqoriya yeniləndi.");
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("Kateqoriyanın Id-si: ");
                    int id = int.Parse(Console.ReadLine());

                    var category = categoryService.GetCategory(id);

                    if (category == null)
                    {
                        Console.WriteLine("Kateqoriya tapılmadı.");
                    }
                    else
                    {
                        categoryService.DeleteCategory(category);
                        Console.WriteLine("Kateqoriya silindi.");
                    }
                }
                else if (choice == "5")
                {
                    Product product = new Product();

                    Console.Write("Məhsulun adı: ");
                    product.Name = Console.ReadLine();

                    Console.Write("Qiymət: ");
                    product.Price = decimal.Parse(Console.ReadLine());

                    Console.Write("Anbardakı say: ");
                    product.StockQuantity = int.Parse(Console.ReadLine());

                    Console.WriteLine("Mövcud kateqoriyalar:");
                    var categories = categoryService.GetAllCategories();
                    foreach (var item in categories)
                    {
                        Console.WriteLine(item.Id + " - " + item.Name);
                    }

                    Console.Write("Kateqoriya Id-si: ");
                    product.CategoryId = int.Parse(Console.ReadLine());

                    var category = categoryService.GetCategory(product.CategoryId);

                    if (category == null)
                    {
                        Console.WriteLine("Belə kateqoriya yoxdur.");
                    }
                    else
                    {
                        product.IsActive = true;

                        productService.AddProduct(product);
                        Console.WriteLine("Məhsul əlavə olundu.");
                    }
                }
                else if (choice == "6")
                {
                    var products = productService.GetAllProducts();

                    foreach (var item in products)
                    {
                        var category = categoryService.GetCategory(item.CategoryId);

                        string status = item.IsActive ? "Aktiv" : "Deaktiv";

                        Console.WriteLine(item.Id + " | " + item.Name + " | " + item.Price + " AZN | " + item.StockQuantity + " ədəd | " + category.Name + " | " + status);
                    }
                }
                else if (choice == "7")
                {
                    Console.Write("Axtarılan söz: ");
                    string text = Console.ReadLine();

                    var products = productService.SearchProducts(text);

                    foreach (var item in products)
                    {
                        Console.WriteLine(item.Id + " | " + item.Name + " | " + item.Price + " AZN | " + item.StockQuantity + " ədəd");
                    }
                }
                else if (choice == "8")
                {
                    Console.Write("Məhsulun Id-si: ");
                    int id = int.Parse(Console.ReadLine());

                    var product = productService.GetProduct(id);

                    if (product == null)
                    {
                        Console.WriteLine("Məhsul tapılmadı.");
                    }
                    else
                    {
                        Console.Write("Yeni ad: ");
                        product.Name = Console.ReadLine();

                        Console.Write("Yeni qiymət: ");
                        product.Price = decimal.Parse(Console.ReadLine());

                        Console.Write("Yeni say: ");
                        product.StockQuantity = int.Parse(Console.ReadLine());

                        productService.UpdateProduct(product);
                        Console.WriteLine("Məhsul yeniləndi.");
                    }
                }
                else if (choice == "9")
                {
                    Console.Write("Məhsulun Id-si: ");
                    int id = int.Parse(Console.ReadLine());

                    var product = productService.GetProduct(id);

                    if (product == null)
                    {
                        Console.WriteLine("Məhsul tapılmadı.");
                    }
                    else
                    {
                        productService.DeleteProduct(product);
                        Console.WriteLine("Məhsul silindi.");
                    }
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Proqram bağlandı.");
                    break;
                }
                else
                {
                    Console.WriteLine("Yanlış seçim!");
                }
            }
        }
    }
}
