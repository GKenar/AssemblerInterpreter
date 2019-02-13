using System.Collections.Generic;

namespace AssemblerInterpreter
{
    public struct Entry
    {
        public EntryTypes EntryType;
        public string Value;
        public List<string> Arguments;
        public List<string> Registers;
    }
}
