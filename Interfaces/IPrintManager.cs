using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorProject.Interfaces
{
  public interface IPrintManager
  {
    void Print(string documentName_, string documentText_);

    void PrintView(string documentName_, string documentText_);
  }
}
