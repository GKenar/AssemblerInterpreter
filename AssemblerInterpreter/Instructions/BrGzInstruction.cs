using System;

namespace AssemblerInterpreter.Instructions
{
    class BrGzInstruction : IExecutableInstruction
    {
        public void Execute(IEngine engine)
        {
            var entry = engine.CurrentEntry;

            var args = entry.Arguments;
            var regs = entry.Registers;

            if (args.Count != 1 || regs.Count != 1)
                throw new ArgumentException(); //Исправить на корректное исключение

            if (Convert.ToInt32(regs[0]) > 0)
            {
                engine.GotoLabel(args[0]);
            }
        }
    }
}
