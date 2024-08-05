using OOP_NorthwindDbFirst.Models;

namespace OOP_NorthwindDbFirst.Abstracts.Interfaces
{
    internal interface ICategoryRepository
    {
        //CRUD
        //CREATE
        string CreateCategory(Category category);
        //READ
        List<Category> GetAllCategories();
        //UPDATE
        string UpdateCategory(Category category);
        //Find
        Category FindCategory(int categoryId);
        //Delete
        string DeleteCategory(int categoryId);
    }
}
