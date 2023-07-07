using System.Windows.Forms;

namespace EditorProject.Interfaces
{
  public interface IDocumentHelper
  {
    Form CreateNewDocument();

    Form OpenDocument();

    void Save(Form document_);

    RichTextBox FindRichTextBox(Form document_);
  }
}
