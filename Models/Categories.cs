using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Category.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}