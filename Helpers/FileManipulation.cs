using EditorProject.Interfaces;
using System.IO;
using System.Windows.Forms;
using System;

namespace EditorProject.Helpers
{
  public class FileManipulation : IFileManipulation
  {
    private readonly string _rootDir;

    public FileManipulation(FileConfiguration configuration_)
    {
      _rootDir = "WorkingDir"; //configuration_.RootDir + "WorkingDir";
    }

    public bool Save(string documentName_, string documentText_)
    {
      if (!string.IsNullOrEmpty(_rootDir))
      {
        var fileName = _rootDir + "\\" + documentName_;
        using (var saveFileDialog = new SaveFileDialog())
        {
          saveFileDialog.InitialDirectory = _rootDir;
          saveFileDialog.FileName = documentName_;
          saveFileDialog.AddExtension = true;
          saveFileDialog.Filter = "All files (*.*)|*.*";

          try
          {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
              fileName = saveFileDialog.FileName;
            }
            else if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
              MessageBox.Show($"The document was not saved.", "Not Save File", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

              return false;
            }
          } 
          catch(Exception e)
          {
            System.Diagnostics.Debug.WriteLine($"Something was happend while saving the file: {e.Message}");
            return false;
          }

          File.WriteAllText(fileName, documentText_);

          return true;
        }
      }

      return false;
    }

    public string OpenFile()
    {
      using (var openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = _rootDir;

        try
        {
          if (openFileDialog.ShowDialog() == DialogResult.OK)
          {
            return openFileDialog.FileName;
          }
        }
        catch (Exception e)
        {
          System.Diagnostics.Debug.WriteLine($"Something was happend while opening file: {e.Message}");
          return string.Empty;
        }
      }

      return string.Empty;
    }
  }
}
