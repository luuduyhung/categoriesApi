using Category.Models;
using Microsoft.EntityFrameworkCore;

namespace Category.Data
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> opt) : base(opt)
        {

        }
        public DbSet<Categories> Categories { get; set; }
    }
}