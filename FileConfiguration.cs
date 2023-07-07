using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EditorProject
{
  public class FileConfiguration
  {
    public string RootDir { get; set; }

    private const string myRelativePath = nameof(Program) + ".cs";

    public FileConfiguration()
    {
      var pathName = GetSourceFilePathName();
      RootDir = pathName.Substring(0, pathName.Length - myRelativePath.Length);
    }

    private static string GetSourceFilePathName([CallerFilePath] string callerFilePath = null) => callerFilePath ?? "";
  }
}
