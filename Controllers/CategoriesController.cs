using System;
using System.Collections.Generic;
using AutoMapper;
using Category.Data;
using Category.Dtos;
using Category.Models;
using Category.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Category.Controllers
{
    // api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Categories>> GetAllCategories()
        {
            var items = _service.GetCategories();
            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult<CategoryReadDto> GetCategoryById(int id)
        {
            var item = _service.GetCategory(id);
            if (item != null)
            {
                return Ok(_mapper.Map<CategoryReadDto>(item));

            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CategoryReadDto> CreateCategory(CategoryCreateDto payload)
        {
            var categoryModel = _mapper.Map<Categories>(payload);
            _service.CreateCategory(categoryModel);
            var categoryReadDto = _mapper.Map<CategoryReadDto>(categoryModel);
            return CreatedAtRoute(nameof(GetCategoryById), new { Id = categoryReadDto.Id }, categoryReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, CategoryUpdateDto payload)
        {
            var found = _service.GetCategory(id);
            if (found == null)
            {
                return NotFound();
            }
            _mapper.Map(payload, found);
            _service.UpdateCategory(_mapper.Map<Categories>(found));
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCategory(int id, JsonPatchDocument<CategoryUpdateDto> payload)
        {
            var found = _service.GetCategory(id);
            if (found == null)
            {
                return NotFound();
            }
            var categoryToPatch = _mapper.Map<CategoryUpdateDto>(found);
            payload.ApplyTo(categoryToPatch, ModelState);
            if (!TryValidateModel(categoryToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(categoryToPatch, found);
            _service.UpdateCategory(_mapper.Map<Categories>(found));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            // Console.WriteLine(id);
            var found = _service.GetCategory(id);
            if (found == null)
            {
                return NotFound();
            }
            // var deleteCat = _mapper.Map<Categories>(found);
            // _service.DeleteCategory(deleteCat);
            _service.DeleteCategory(id);
            return NoContent();
        }
    }
}
