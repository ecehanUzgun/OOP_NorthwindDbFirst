using OOP_NorthwindDbFirst.Concretes.Services;
using OOP_NorthwindDbFirst.Models;

namespace OOP_NorthwindDbFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region List
            //NorthwindContext db = new NorthwindContext();
            ////Category List
            //List<Category> categories = db.Categories.ToList();
            //foreach (Category category in categories)
            //{
            //    Console.WriteLine(category.CategoryName);
            //}
            //Console.WriteLine("**********************");
            ////Product List
            //List<Product> products = db.Products.ToList();
            //foreach (Product product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //} 
            #endregion
            string[] classes = { "Product", "Order", "Order Details", "Shipper", "Supplier", "Employee", "Customer", "Category" };

            string[] islemler = { "Create", "Read", "Update", "Delete", "Exit" };

            string kullaniciIslem = "";
            string kullaniciClass = "";

            while (true)
            {
                ListClasses();
                kullaniciClass = Console.ReadLine().ToLower();
                switch(kullaniciClass)
                {
                    case "category":
                    while (kullaniciIslem != "exit")
                    { 
                        CategoryService categoryService = new CategoryService();
                        ListIslemler();
                        kullaniciIslem = Console.ReadLine().ToLower();
                            switch (kullaniciIslem)
                            {
                                case "create":
                                Category category = new Category();
                                Console.WriteLine("Category Name:");
                                category.CategoryName = Console.ReadLine();
                                Console.WriteLine("Description:");
                                category.Description = Console.ReadLine();
                                string createCategory = categoryService.CreateCategory(category);
                                Console.WriteLine(createCategory);
                                break;
                                case "read":
                                    foreach (var category1 in categoryService.GetAllCategories())
                                    {
                                        Console.WriteLine($"{category1.CategoryName}");
                                    }
                                    Console.WriteLine("************************");
                                break;
                                case "update":
                                    Category guncellenecekKategori = new Category();
                                    Console.WriteLine("Category ID:");
                                    try 
                                    { 
                                        guncellenecekKategori.CategoryId = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Category Name:");
                                        guncellenecekKategori.CategoryName = Console.ReadLine();
                                        Console.WriteLine("Category Description:");
                                        guncellenecekKategori.Description = Console.ReadLine();

                                        string result = categoryService.UpdateCategory(guncellenecekKategori);
                                        Console.WriteLine(result);
                                    }
                                    catch (Exception ex) 
                                    {
                                        Console.WriteLine(ex.Message);
                                        kullaniciIslem = "update";
                                    }
                                break;
                                case "delete":
                                    Console.WriteLine("Category ID:");
                                    try
                                    {
                                        int categoryId = int.Parse(Console.ReadLine());
                                        string delete = categoryService.DeleteCategory(categoryId);
                                        Console.WriteLine(delete);
                                    }
                                    catch(Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        kullaniciIslem = "delete";
                                    }
                                break;
                                case "exit":
                                    Console.WriteLine("Ana Menü");
                                break;
                            }
                    }
                    kullaniciIslem = "";
                    break;
                }
            }
            void ListClasses()
            {
                Console.WriteLine("************************");
                for (int i=0; i<classes.Length; i++)
                {
                    Console.WriteLine(classes[i]);
                }
                Console.WriteLine("************************");
            }
            void ListIslemler()
            {
                Console.WriteLine("************************");
                for (int i = 0; i < islemler.Length; i++)
                {
                    Console.WriteLine(islemler[i]);
                }
                Console.WriteLine("************************");
            }
        }
    }
}
