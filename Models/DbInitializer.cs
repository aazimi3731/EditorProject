using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace EditorProject.Models
{
    public class DbInitializer
  {
    public static void Seed(IServiceScope serviceScope_)
    {
      var context = serviceScope_.ServiceProvider.GetRequiredService<EditorProjectDbContext>();

      if (!context.People.Any())
      {
        context.People.AddRange
        (
            new Person { FirstName = "John", LastName = "Robinson", Age = 23, Username = "robinsonj", Password = "john123" },
            new Person { FirstName = "Mary", LastName = "Ross", Age = 34, Username = "rossm", Password = "mary123" },
            new Person { FirstName = "Bob", LastName = "Keller", Age = 18, Username = "kellerb", Password = "bob123" },
            new Person { FirstName = "Helen", LastName = "Wick", Age = 43, Username = "wickh", Password = "helen123" },
            new Person { FirstName = "Andrew", LastName = "Hunt", Age = 26, Username = "hunta", Password = "andrew123" }
        );
      }

      context.SaveChanges();
    }
  }
}
