namespace AssemblerInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpr = new Interpreter();
            interpr.Interpret("LD r0 #12\nLD r1 #3\nADD r0 r1");
        }
    }
}
