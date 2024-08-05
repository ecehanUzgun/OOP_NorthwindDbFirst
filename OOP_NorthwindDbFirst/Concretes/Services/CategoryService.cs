using OOP_NorthwindDbFirst.Abstracts;
using OOP_NorthwindDbFirst.Abstracts.Interfaces;
using OOP_NorthwindDbFirst.Models;

namespace OOP_NorthwindDbFirst.Concretes.Services
{
    internal class CategoryService : ICategoryRepository
    {
        private NorthwindContext _db;
        public CategoryService() 
        {
            _db = new NorthwindContext();
        }

        public string CreateCategory(Category category)
        {
            try
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return "Category added";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteCategory(int categoryId)
        {
            Category deletedCategory = FindCategory(categoryId);
            if (deletedCategory != null) 
            {
                _db.Categories.Remove(deletedCategory);
                _db.SaveChanges();
                return "Kategori silindi.";
            }
            else 
            {
                return "Kategori bulunamadı.";
            }
        }

        public Category FindCategory(int categoryId)
        {
            Category category = _db.Categories.Find(categoryId);
            if(category != null)
            {
                return category;
            }
            else
            {
                return category;
            }
        }

        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public string UpdateCategory(Category category)
        {
            try
            {
                Category updated = FindCategory(category.CategoryId);
                if (updated != null)    
                {
                    updated.CategoryName = category.CategoryName;
                    updated.Description = category.Description;

                    _db.SaveChanges();
                    return "Kategori Güncellendi.";
                }
                else
                {
                    return "Güncellenecek kategori bulunamadı";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
