using System.Collections.Generic;

namespace EditorProject.Interfaces
{
  public interface IPersonService
  {
    #region Properties

    #endregion

    #region Methods

    IEnumerable<Person> AllPeople();

    Person GetPersonByUsername(string username_);

    #endregion

  }
}
