using System;

namespace AssemblerInterpreter.Instructions
{
    class SyscallInstruction : IExecutableInstruction
    {
        public void Execute(IEngine engine)
        {
            var memory = engine.Registers;
            var entry = engine.CurrentEntry;

            var regs = entry.Registers;

            if (regs.Count != 1)
                throw new ArgumentException(); //Исправить на корректное исключение

            Console.WriteLine(memory[Convert.ToInt32(regs[0])]);
        }
    }
}
