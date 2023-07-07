using Microsoft.EntityFrameworkCore;

namespace EditorProject.Models
{
  public class EditorProjectDbContext : DbContext
  {
    public EditorProjectDbContext(DbContextOptions<EditorProjectDbContext> options)
      : base(options)
    {
    }

    public DbSet<Person> People { get; set; }
  }
}
