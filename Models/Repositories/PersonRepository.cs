using EditorProject.Models;
using EditorProject.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EditorProject.Services
{
  public class PersonRepository : IPersonRepository
  {
    private readonly EditorProjectDbContext _editorProjectDbContext;

    public PersonRepository(EditorProjectDbContext editorProjectDbContext_)
    {
      _editorProjectDbContext = editorProjectDbContext_;
    }

    public IEnumerable<Person> AllPeople => _editorProjectDbContext.People.ToList();

    public Person GetPersonByUsername(string username_) => 
      AllPeople.FirstOrDefault(p => p.Username.ToLower() == username_.ToLower());
  }
}
