using System.Collections.Generic;
using Category.Models;

namespace Category.Dtos
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<CategoryReadDto> Children { get; set; }
    }
}