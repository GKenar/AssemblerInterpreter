namespace AssemblerInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpr = new Interpreter();
            interpr.Interpret(
                "LD r0 #12\n"+
                "LD r1 #3\n"+
                "ADD r0 r1\n"+
                "MOV r0 r5\n"+
                "SYSCALL r5");
        }
    }
}
