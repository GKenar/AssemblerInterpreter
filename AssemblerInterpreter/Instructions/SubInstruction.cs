using System;

namespace AssemblerInterpreter.Instructions
{
    class SubInstruction : IExecutableInstruction
    {
        public string InstructionArgsPattern => @"^r(\d+) r(\d+)$";

        public void Execute(IEngine engine)
        {
            var memory = engine.Registers;
            var entry = engine.CurrentEntry;

            var args = entry.Arguments;

            if (args.Count != 2)
                throw new ArgumentException(); //Исправить на корректное исключение

            var reg1 = Convert.ToInt32(args[0]);
            var reg2 = Convert.ToInt32(args[1]);

            memory[reg1] = (byte)(memory[reg1] - memory[reg2]);
        }
    }
}
