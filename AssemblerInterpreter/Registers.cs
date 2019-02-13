namespace AssemblerInterpreter
{
    public class Registers : IRegisters
    {
        private readonly byte[] _bytesArray;

        public byte this[int x]
        {
            get { return _bytesArray[x]; }
            set { _bytesArray[x] = value; }
        }

        public Registers()
        {
            _bytesArray = new byte[15];
        }
    }
}
