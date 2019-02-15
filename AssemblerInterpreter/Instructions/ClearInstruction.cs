using System;

namespace AssemblerInterpreter.Instructions
{
    class ClearInstruction : IExecutableInstruction
    {
        public string InstructionArgsPattern => @"";

        public void Execute(IEngine engine)
        {
            var memory = engine.Registers;

            memory.ClearRegisters();
        }
    }
}
