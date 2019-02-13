namespace AssemblerInterpreter.Instructions
{
    public interface IExecutableInstruction
    {
        void Execute(IRegisters memory, Entry entry); //Был результат
    }
}
