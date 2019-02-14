using System;

namespace AssemblerInterpreter.Instructions
{
    public class LoadInstruction : IExecutableInstruction
    {
        public void Execute(IEngine engine)
        {
            var memory = engine.Registers;
            var entry = engine.CurrentEntry;

            var args = entry.Arguments;

            if(args.Count != 2)
                throw new ArgumentException(); //Исправить на корректное исключение

            var memoryCell = Convert.ToInt32(args[0]);
            var number = Convert.ToByte(args[1]);

            memory[memoryCell] = number;
        }
    }
}
