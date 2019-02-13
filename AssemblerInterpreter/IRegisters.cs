namespace AssemblerInterpreter
{
    public interface IRegisters
    {
        byte this[int x] { get; set; }
        void ClearRegisters();
    }
}
