using EditorProject.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EditorProject
{
  public partial class TextEditorForm : Form
  {
    private readonly LoginForm _loginForm;
    private readonly IDocumentHelper _documentHelper;
    private readonly IPrintManager _printManager;

    private int _index = 0;

    public TextEditorForm(LoginForm loginForm_, IDocumentHelper documentHelper_,
      IPrintManager printManager_)
    {
      InitializeComponent();

      _loginForm = loginForm_;
      _documentHelper = documentHelper_;
      _printManager = printManager_;

      this.IsMdiContainer = true;
    }

    private void NewToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var newDocument =  _documentHelper.CreateNewDocument();

      ShowDocument(newDocument);
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var existedDocument = _documentHelper.OpenDocument();

      if(existedDocument == null) { return; }

      ShowDocument(existedDocument);
    }

    private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ActiveMdiChild.Close();
    }

    private void TextEditorForm_Shown(object sender, EventArgs e)
    {
      _loginForm.Owner = this;

      _loginForm.ShowLoginForm();
    }

    private void ShowDocument(Form document_)
    {
      this.MdiChildren.Append(document_);

      document_.Owner = this;

      document_.MdiParent = this;

      if(string.IsNullOrEmpty(document_.Name))
      {
        ++_index;
        document_.Name = "Document" + _index.ToString() + ".txt";
        document_.Text = "Document " + _index.ToString();
      }

      document_.Show();
    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _documentHelper.Save(this.ActiveMdiChild);
    }

    private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _documentHelper.Save(this.ActiveMdiChild);
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void CasCadeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.LayoutMdi(MdiLayout.Cascade);
    }

    private void TileHorizentallyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void TileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.LayoutMdi(MdiLayout.TileVertical);
    }

    private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var richTextBox = _documentHelper.FindRichTextBox(this.ActiveMdiChild);
      if (richTextBox != null)
      {
        richTextBox.Undo();
        richTextBox.ClearUndo();
      }
    }

    private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var richTextBox = _documentHelper.FindRichTextBox(this.ActiveMdiChild);
      if (richTextBox != null)
      {
        richTextBox.Redo();
      }
    }

    private void CutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var richTextBox = _documentHelper.FindRichTextBox(this.ActiveMdiChild);
      if (richTextBox != null && richTextBox.SelectionLength > 0)
      {
        richTextBox.Cut();
      }
    }

    private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var richTextBox = _documentHelper.FindRichTextBox(this.ActiveMdiChild);
      if (richTextBox != null && richTextBox.SelectionLength > 0)
      {
        richTextBox.Copy();
      }
    }

    private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var richTextBox = _documentHelper.FindRichTextBox(this.ActiveMdiChild);
      if (richTextBox != null && Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
      {
        richTextBox.Paste();
      }
    }

    private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var richTextBox = _documentHelper.FindRichTextBox(this.ActiveMdiChild);
      if (richTextBox != null)
      {
        richTextBox.SelectAll();
      }
    }

    private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var richTextBox = _documentHelper.FindRichTextBox(this.ActiveMdiChild);
      if (richTextBox != null)
      {
        _printManager.Print(this.ActiveMdiChild.Name, richTextBox.Text);
      }
    }

    private void PrintViewToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var richTextBox = _documentHelper.FindRichTextBox(this.ActiveMdiChild);
      if (richTextBox != null)
      {
        _printManager.PrintView(this.ActiveMdiChild.Name, richTextBox.Text);
      }
    }
  }
}
