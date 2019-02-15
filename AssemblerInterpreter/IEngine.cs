using System.Collections.Generic;
using AssemblerInterpreter.Instructions;

namespace AssemblerInterpreter
{
    public interface IEngine
    {
        IRegisters Registers { get; }
        Entry CurrentEntry { get; }
        bool InterpetationCompleted { get; }
        void LoadNewEntriesList(List<Entry> entriesList);
        void RunNextInstruction();
        void GotoLabel(string label);
        void GotoByPointer(int ip);
        string GetInstructionPattern(string instruction);
    }
}
