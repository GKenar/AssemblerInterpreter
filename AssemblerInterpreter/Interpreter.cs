using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AssemblerInterpreter
{
    public sealed class Interpreter
    {
        private readonly IEngine _engine;

        public Interpreter()
        {
            _engine = new InterpreterEngine();
        }

        public void Interpret(IEnumerable<string> listing)
        {
            _engine.LoadNewEntriesList(TranslateToEntriesList(listing));

            while (!_engine.InterpetationCompleted)
            {
                _engine.RunNextInstruction();
            }
        }

        private List<Entry> TranslateToEntriesList(IEnumerable<string> linesList)
        {
            var entriesList = new List<Entry>();

            var regexInstruction = new Regex(@"^([A-z]+)(\s(.*)|$)");
            var regexLabel = new Regex(@"^([A-z|0-9]+):$");

            foreach (var line in linesList)
            {
                var regexInstrMatch = regexInstruction.Match(line);
                var regexLabelMatch = regexLabel.Match(line);

                var isInstruction = regexInstrMatch.Success;
                var isLabel = regexLabelMatch.Success;

                if (!isLabel && !isInstruction)
                    throw new Exception(); //Корректное исключение

                if (isInstruction)
                {
                    var instructionPattern = _engine.GetInstructionPattern(regexInstrMatch.Groups[1].Value);

                    if (instructionPattern == null)
                        throw new Exception(); //Корректное исключение

                    var regexArgsMatch = new Regex(instructionPattern).Match(regexInstrMatch.Groups[3].Value);

                    var argumentsList = new List<string>();
                    for (var i = 1; i < regexArgsMatch.Groups.Count; i++)
                    {
                        argumentsList.Add(regexArgsMatch.Groups[i].Value);
                    }

                    entriesList.Add(new Entry
                    {
                        Value = regexInstrMatch.Groups[1].Value,
                        EntryType = EntryTypes.Instruction,
                        Arguments = argumentsList
                    });
                }
                else
                {
                    entriesList.Add(new Entry
                    {
                        Value = regexLabelMatch.Groups[1].Value,
                        EntryType = EntryTypes.Label,
                        Arguments = null
                    });
                }

            }

            return entriesList;
        } 
    }
}
