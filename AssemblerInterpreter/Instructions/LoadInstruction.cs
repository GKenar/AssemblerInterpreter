using System;

namespace AssemblerInterpreter.Instructions
{
    public class LoadInstruction : IExecutableInstruction
    {
        public void Execute(IRegisters memory, Entry entry)
        {
            var args = entry.Arguments;
            var regs = entry.Registers;

            if(args.Count != 1 || regs.Count != 1)
                throw new ArgumentException(); //Исправить на корректное исключение

            var memoryCell = Convert.ToInt32(regs[0]);
            var number = Convert.ToByte(args[0]);

            memory[memoryCell] = number;
        }
    }
}
