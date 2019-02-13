using System;

namespace AssemblerInterpreter.Instructions
{
    class MovInstruction : IExecutableInstruction
    {
        public void Execute(IEngine engine)
        {
            var memory = engine.Registers;
            var entry = engine.CurrentEntry;

            var regs = entry.Registers;

            if (regs.Count != 2)
                throw new ArgumentException(); //Исправить на корректное исключение

            var reg1 = Convert.ToInt32(regs[0]);
            var reg2 = Convert.ToInt32(regs[1]);

            memory[reg2] = memory[reg1];
        }
    }
}
