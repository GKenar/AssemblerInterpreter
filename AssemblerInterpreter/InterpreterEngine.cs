using System;
using System.Collections.Generic;
using AssemblerInterpreter.Instructions;

namespace AssemblerInterpreter
{
    class InterpreterEngine : IEngine
    {
        private readonly Dictionary<string, IExecutableInstruction> _instructions;
        private readonly List<Entry> _entriesList;
        private int _ip;

        public IRegisters Registers { get; private set; }
        public bool InterpetationCompleted => _ip >= _entriesList.Count;

        public InterpreterEngine(List<Entry> entriesList)
        {
            _entriesList = entriesList;

            Registers = new Registers();
            _instructions = new Dictionary<string, IExecutableInstruction>();

            _instructions.Add("LD", new LoadInstruction());
            _instructions.Add("ADD", new AddInstruction());

            _ip = 0;
        }

        public void RunNextInstruction()
        {
            var currentEntry = _entriesList[_ip];

            if (currentEntry.EntryType == EntryTypes.Instruction)
            {
                var instruction = _instructions[currentEntry.Value];

                if (instruction == null)
                    throw new Exception(); //Нужно корректное исключение

                instruction.Execute(Registers, currentEntry);
            }

            _ip++;
        }

        public void GotoLabel(string label)
        {
            for (var ip = 0; ip < _entriesList.Count; ip++)
            {
                if (_entriesList[ip].EntryType == EntryTypes.Label &&
                    _entriesList[ip].Value == label)
                {
                    GotoByPointer(ip);
                    return;
                }
            }
        }

        public void GotoByPointer(int ip)
        {
            if (ip < 0)
                throw new ArgumentOutOfRangeException(nameof(ip));

            _ip = ip;
        }
    }
}
