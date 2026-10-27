using Microsoft.EntityFrameworkCore;

namespace Bai3_ASP.Models
{
    public class AppDbContext: DbContext
    {
   public DbSet<Product> Products { get; set; } = null!;
    }
}
