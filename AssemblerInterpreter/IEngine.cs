namespace AssemblerInterpreter
{
    interface IEngine
    {
        IRegisters Registers { get; }
        bool InterpetationCompleted { get; }
        void RunNextInstruction();
        void GotoLabel(string label);
        void GotoByPointer(int ip);
    }
}
