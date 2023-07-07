using EditorProject.Interfaces;
using EditorProject.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EditorProject.Services
{
  public class PersonService : IPersonService
  {
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personReository_)
    {
      _personRepository = personReository_;
    }

    public IEnumerable<Person> AllPeople() => _personRepository.AllPeople;

    public Person GetPersonByUsername(string username_) => 
      _personRepository.GetPersonByUsername(username_);
  }
}
