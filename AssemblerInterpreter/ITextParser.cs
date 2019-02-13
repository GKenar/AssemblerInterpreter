using System.Collections.Generic;
using System.IO;

namespace AssemblerInterpreter
{
    public interface ITextParser
    {
        List<string> Parse(string text);
        List<string> Parse(Stream stream);
        List<string> ParseFromFile(string path);
    }
}
