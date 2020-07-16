using System.Collections.Generic;
using Category.Models;

namespace Category.Data
{
    public interface ICategoryRepo
    {
        bool SaveChanges();
        List<Categories> GetAll();
        Categories GetById(int id);
        List<Categories> GetByParentId(int parentId);
        void Create(Categories cat);
        void Update(Categories cat);
        // void Delete(Categories cat);
        void Delete(int id);
    }
}