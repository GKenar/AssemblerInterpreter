using System;

namespace AssemblerInterpreter.Instructions
{
    class BrGzInstruction : IExecutableInstruction
    {
        public string InstructionArgsPattern => @"^([A-z|0-9]+) r(\d+)$";

        public void Execute(IEngine engine)
        {
            var memory = engine.Registers;
            var entry = engine.CurrentEntry;

            var args = entry.Arguments;

            if (args.Count != 2)
                throw new ArgumentException(); //Исправить на корректное исключение

            if (memory[Convert.ToInt32(args[1])] > 0)
            {
                engine.GotoLabel(args[0]);
            }
        }
    }
}
