using System;
using System.Collections.Generic;
using System.Linq;
using Category.Models;

namespace Category.Data
{
    public class SqlCategoryRepo : ICategoryRepo
    {
        private readonly CategoryContext _context;

        public SqlCategoryRepo(CategoryContext context)
        {
            _context = context;
        }
        public void Create(Categories cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException(nameof(cat));
            }
            _context.Categories.Add(cat);
        }

        // public void Delete(Categories cat)
        // {
        //     if (cat == null)
        //     {
        //         throw new ArgumentNullException(nameof(cat));
        //     }
        //     _context.Categories.Remove(cat);
        // }
        public void Delete(int id)
        {
            var found = _context.Categories.Find(id);
            _context.Categories.Remove(found);
        }

        public virtual List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Categories GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public List<Categories> GetByParentId(int id)
        {
            return _context.Categories.Where(c => c.ParentId == id).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Categories cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException(nameof(cat));
            }
            var found = _context.Categories.FirstOrDefault(c => c.Id == cat.Id);
            found.Name = cat.Name;
            found.ParentId = cat.ParentId;
        }
    }
}