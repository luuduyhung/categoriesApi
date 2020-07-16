using System.Collections.Generic;
using Category.Data;
using Category.Dtos;
using Category.Models;

namespace Category.Services.Interfaces
{
    public interface ICategoryService : ICategoryRepo
    {
        List<CategoryReadDto> GetCategories();
        CategoryReadDto GetCategory(int id);
        void CreateCategory(Categories cat);
        void UpdateCategory(Categories cat);
        // void DeleteCategory(Categories cat);
        void DeleteCategory(int id);
    }
}

