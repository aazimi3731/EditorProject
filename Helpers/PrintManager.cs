using EditorProject.Interfaces;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace EditorProject.Helpers
{
  public class PrintManager : IPrintManager
  {
    private StringReader _textToPrint;

    public void Print(string documentName_, string documentText_)
    {
      var print = new PrintDialog();
      print.AllowCurrentPage = true;
      print.AllowSomePages = true;
      print.AllowPrintToFile = true;

      var printDocument = CreatePrintDocument(documentName_, documentText_);

      print.Document = printDocument;

      if (print.ShowDialog() == DialogResult.OK)
      {
        printDocument.Print();
      }
    }

    public void PrintView(string documentName_, string documentText_)
    {
      var printView = new PrintPreviewDialog();
      printView.Name = documentName_;
      printView.ShowIcon = true;

      printView.Document = CreatePrintDocument(documentName_, documentText_);

      printView.ShowDialog();
    }

    private PrintDocument CreatePrintDocument(string documentName_, string documentText_)
    {
      var printDocument = new PrintDocument();
      printDocument.DocumentName = documentName_;
      printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

      _textToPrint = new StringReader(documentText_);

      return printDocument;
    }

    private void PrintPage(object sender, PrintPageEventArgs ev)
    {
      float linesPerPage = 0;
      float yPos = 0;
      int count = 0;
      float leftMargin = ev.MarginBounds.Left;
      float topMargin = ev.MarginBounds.Top;
      string line = null;

      var printFont = new Font("Arial", 10);

      // Calculate the number of lines per page.
      linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

      // Print each line of the text.
      while (count < linesPerPage &&
         ((line = _textToPrint.ReadLine()) != null))
      {
        yPos = topMargin + (count *
           printFont.GetHeight(ev.Graphics));
        ev.Graphics.DrawString(line, printFont, Brushes.Black,
           leftMargin, yPos, new StringFormat());
        count++;
      }

      // If more lines exist, print another page.
      if (line != null)
        ev.HasMorePages = true;
      else
        ev.HasMorePages = false;
    }
  }
}
