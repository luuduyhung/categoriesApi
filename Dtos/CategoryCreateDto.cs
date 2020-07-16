using System.ComponentModel.DataAnnotations;

namespace Category.Dtos
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}