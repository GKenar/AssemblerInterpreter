namespace AssemblerInterpreter.Instructions
{
    public interface IExecutableInstruction
    {
        string InstructionArgsPattern { get; }
        void Execute(IEngine engine); //Был результат
    }
}
