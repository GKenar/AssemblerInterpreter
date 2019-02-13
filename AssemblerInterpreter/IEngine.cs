namespace AssemblerInterpreter
{
    public interface IEngine
    {
        IRegisters Registers { get; }
        Entry CurrentEntry { get; }
        bool InterpetationCompleted { get; }
        void RunNextInstruction();
        void GotoLabel(string label);
        void GotoByPointer(int ip);
    }
}
