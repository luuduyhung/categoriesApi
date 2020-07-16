using System.ComponentModel.DataAnnotations;

namespace Category.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}