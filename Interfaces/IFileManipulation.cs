namespace EditorProject.Interfaces
{
  public interface IFileManipulation
  {
    bool Save(string documentName_, string documentText_);

    string OpenFile();
  }
}
