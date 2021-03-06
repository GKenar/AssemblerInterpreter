﻿using System;
using System.Collections.Generic;
using AssemblerInterpreter.Instructions;

namespace AssemblerInterpreter
{
    class InterpreterEngine : IEngine
    {
        private readonly Dictionary<string, IExecutableInstruction> _instructions;
        private List<Entry> _entriesList;
        private int _ip;

        public IRegisters Registers { get; private set; }
        public Entry CurrentEntry => _entriesList[_ip];
        public bool InterpetationCompleted => _ip >= _entriesList.Count;

        public InterpreterEngine()
        {
            Registers = new Registers();
            _instructions = new Dictionary<string, IExecutableInstruction>();

            _instructions.Add("LD", new LoadInstruction());
            _instructions.Add("ADD", new AddInstruction());
            _instructions.Add("MOV", new MovInstruction());
            _instructions.Add("SUB", new SubInstruction());
            _instructions.Add("BR", new BrInstruction());
            _instructions.Add("BRGZ", new BrGzInstruction());
            _instructions.Add("CLEAR", new ClearInstruction());
            _instructions.Add("SYSCALL", new SyscallInstruction());

            _ip = 0;
        }

        public void LoadNewEntriesList(List<Entry> entriesList)
        {
            _entriesList = entriesList;

            Registers.ClearRegisters();
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

                instruction.Execute(this);
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
            throw new Exception(); //Нужно корректное исключение
        }

        public void GotoByPointer(int ip)
        {
            if (ip < 0)
                throw new ArgumentOutOfRangeException(nameof(ip));

            _ip = ip;
        }

        public string GetInstructionPattern(string instruction)
        {
            return _instructions[instruction]?.InstructionArgsPattern;
        }
    }
}
