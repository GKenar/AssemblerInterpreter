namespace AssemblerInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new TextParser();
            var interpr = new Interpreter();
            interpr.Interpret(parser.ParseFromFile("Listing.txt"));
        }
    }
}
