using System.IO;

namespace BEngine.BSharp
{
    class Compiler
    {
        string FileTXT;
        public Compiler(string FileDirect)
        {
            FileTXT = File.ReadAllText(FileDirect);
        }
    }
}
