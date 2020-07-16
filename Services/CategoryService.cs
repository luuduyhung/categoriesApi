using System;
using System.Collections.Generic;
using AutoMapper;
using Category.Data;
using Category.Dtos;
using Category.Models;
using Category.Services.Interfaces;

namespace Category.Services
{
    public class CategoryService : SqlCategoryRepo, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(CategoryContext ctx, IMapper mapper) : base(ctx)
        {
            _mapper = mapper;
        }

        public void CreateCategory(Categories cat)
        {
            base.Create(cat);
            base.SaveChanges();
        }

        // public void DeleteCategory(Categories cat)
        // {
        //     Console.WriteLine($"{cat.Id} {cat.Name} {cat.ParentId}");
        //     base.Delete(cat);
        //     base.SaveChanges();
        // }
        public void DeleteCategory(int id)
        {
            base.Delete(id);
            base.SaveChanges();
        }

        public List<CategoryReadDto> GetCategories()
        {
            var rawCategories = base.GetAll();
            var categories = new List<CategoryReadDto>();
            foreach (var cat in rawCategories)
            {
                categories.Add(parseCategory(cat));
            }
            return categories;
        }
        public CategoryReadDto GetCategory(int id)
        {
            var found = base.GetById(id);
            if (found == null) return null;
            return _mapper.Map<CategoryReadDto>(parseCategory(found));
        }

        public void UpdateCategory(Categories cat)
        {
            base.Update(cat);
            base.SaveChanges();
        }

        private CategoryReadDto parseCategory(Categories category)
        {
            var categoryDto = _mapper.Map<CategoryReadDto>(category);
            var childrens = base.GetByParentId(category.Id);
            if (childrens.Count != 0)
            {
                var dtoChild = new List<CategoryReadDto>();
                foreach (var child in childrens)
                {
                    dtoChild.Add(parseCategory(child));
                }
                categoryDto.Children = dtoChild;
            }
            return categoryDto;
        }
    }
}