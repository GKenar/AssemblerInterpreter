using System;

namespace AssemblerInterpreter.Instructions
{
    class AddInstruction : IExecutableInstruction
    {
        public void Execute(IRegisters memory, Entry entry)
        {
            var args = entry.Arguments;
            var regs = entry.Registers;

            if (args.Count != 0 || regs.Count != 2)
                throw new ArgumentException(); //Исправить на корректное исключение

            var reg1 = Convert.ToInt32(regs[0]);
            var reg2 = Convert.ToInt32(regs[1]);

            memory[reg1] = (byte)(memory[reg1] + memory[reg2]);
        }
    }
}
