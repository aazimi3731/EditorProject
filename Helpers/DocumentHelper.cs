using EditorProject.Interfaces;
using EditorProject.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EditorProject.Helpers
{
  public class DocumentHelper : IDocumentHelper
  {
    private FormWindowState LastWindowState = FormWindowState.Minimized;

    private readonly IFileManipulation _fileManipulation;

    public DocumentHelper(IFileManipulation fileManipulation_)
    {
      _fileManipulation = fileManipulation_;
    }

    public Form CreateNewDocument()
    {
      var newDocument = new Form();

      SetDocumentProperties(newDocument, "");

      newDocument.Name = string.Empty;

      return newDocument;
    }

    public Form OpenDocument()
    {
      var filePath = _fileManipulation.OpenFile();

      if(string.IsNullOrEmpty(filePath))
      {
        return null;
      }

      var newDocument = new Form();

      var text = File.ReadAllText(filePath);

      var fileName = Path.GetFileName(filePath);

      newDocument.Name = fileName;
      newDocument.Text = fileName;

      SetDocumentProperties(newDocument, text.Replace("\r", ""));

      return newDocument;
    }

    public void Save(Form document_)
    {
      var richTextBox = FindRichTextBox(document_);
      var textBoxText = FindTextBox(document_, "Text");

      if (richTextBox != null)
      {
        var IsSaved = _fileManipulation.Save(document_.Name, richTextBox.Text);

        if(IsSaved)
        {
          document_.FormClosing -= BeforeClosingDocument;

          textBoxText.Text = richTextBox.Text;
          document_.FormClosing += BeforeClosingDocument;
        }
      }
    }

    public RichTextBox FindRichTextBox(Form document_)
    {
      if (document_ != null && document_.Controls.Count > 0)
      {
        foreach (var child in document_.Controls)
        {
          if (child is RichTextBox richTextBox)
          {
            return richTextBox;
          }
        }
      }

      return null;
    }

    private void SetDocumentProperties(Form document_, string text_)
    {
      document_.StartPosition = FormStartPosition.WindowsDefaultBounds;

      document_.Icon = (Icon)Resources.newDocument;

      document_.ClientSize = new Size(800, 450);
      document_.Dock = DockStyle.Fill;

      document_.ResumeLayout(false);
      document_.PerformLayout();

      var richTextBox = new RichTextBox();
      if (!string.IsNullOrEmpty(text_))
      {
        richTextBox.Text = text_;
      }
      richTextBox.Dock = DockStyle.Fill;
      document_.Controls.Add(richTextBox);

      var textBox = new TextBox();
      textBox.Hide();
      textBox.Text = text_;
      textBox.Name = "Text"; 
      document_.Controls.Add(textBox);

      document_.FormClosing += BeforeClosingDocument;
      document_.Resize += DocumentResize;
    }

    private void BeforeClosingDocument(object sender, FormClosingEventArgs e)
    {
      if(sender is Form document_) 
      {
        var richTextBox = FindRichTextBox(document_);
        var textBoxText = FindTextBox(document_, "Text");
        if (richTextBox != null && !string.Equals(richTextBox.Text.ToString(),
          textBoxText.Text, StringComparison.OrdinalIgnoreCase))
        {
          var result = MessageBox.Show($"Do you want to save your changes?", "Save Changes",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

          if (result == DialogResult.Yes)
          {
            _fileManipulation.Save(document_.Name, richTextBox.Text);
          }
        }
      }
    }

    private void DocumentResize(object sender, EventArgs e)
    {
      if (sender is Form document_)
      {
        // When window state changes
        if (document_.WindowState != LastWindowState)
        {
          LastWindowState = document_.WindowState;

          document_.ShowIcon = true;
          document_.ControlBox = true;
          if (document_.WindowState == FormWindowState.Maximized)
          {
            document_.ShowIcon = false;
            document_.ControlBox = false;
          }
        }
      }
    }

    private TextBox FindTextBox(Form document_, string type)
    {
      if (document_ != null && document_.Controls.Count > 0)
      {
        foreach (var child in document_.Controls)
        {
          if (child is TextBox textBox && 
            string.Equals(textBox.Name, type, StringComparison.InvariantCultureIgnoreCase))
          {
            return textBox;
          }
        }
      }

      return null;
    }
  }
}
