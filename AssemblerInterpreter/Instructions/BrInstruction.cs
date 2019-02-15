using System;

namespace AssemblerInterpreter.Instructions
{
    class BrInstruction : IExecutableInstruction
    {
        public string InstructionArgsPattern => @"^([A-z|0-9]+)$";

        public void Execute(IEngine engine)
        {
            var entry = engine.CurrentEntry;
            var args = entry.Arguments;

            if (args.Count != 1)
                throw new ArgumentException(); //Исправить на корректное исключение

            engine.GotoLabel(args[0]);
        }
    }
}
