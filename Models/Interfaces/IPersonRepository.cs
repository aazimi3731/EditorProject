using System.Collections.Generic;

namespace EditorProject.Models.Interfaces
{
  public interface IPersonRepository
  {
    #region Properties

    IEnumerable<Person> AllPeople { get; }

    #endregion

    #region Methods

    Person GetPersonByUsername(string username_);

    #endregion

  }
}
