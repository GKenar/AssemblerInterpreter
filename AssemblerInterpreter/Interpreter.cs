using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AssemblerInterpreter
{
    public sealed class Interpreter
    {
        private IEngine _engine;

        public void Interpret(List<string> listing)
        {
            var entriesList = TranslateToEntriesList(listing);

            _engine = new InterpreterEngine(entriesList);

            while (!_engine.InterpetationCompleted)
            {
                _engine.RunNextInstruction();
            }
        }

        private List<Entry> TranslateToEntriesList(IEnumerable<string> linesList)
        {
            var entriesList = new List<Entry>();

            var regexInstruction = new Regex(@"^([A-z]+)($|\s)");
            var regexLabel = new Regex(@"^([A-z|0-9]+):$");
            var regexRegister = new Regex(@"\sr(\d+)");
            var regexArgument = new Regex(@"(\s#|\s)(\d+|[A-Z|0-9]+)");

            foreach (var line in linesList)
            {
                var regexInstrMatch = regexInstruction.Match(line);
                var regexLabelMatch = regexLabel.Match(line);
                var regexRegMatch = regexRegister.Matches(line);
                var regexArgMatch = regexArgument.Matches(line);

                var isInstruction = regexInstrMatch.Success;
                var isLabel = regexLabelMatch.Success;
                var argumentsList = (from Match arg in regexArgMatch select arg.Groups[2].Value).ToList();
                var registersList = (from Match reg in regexRegMatch select reg.Groups[1].Value).ToList();

                if(!isLabel && !isInstruction)
                    throw new Exception(); //Корректное исключение

                entriesList.Add(new Entry
                {
                    Value = isInstruction ? regexInstrMatch.Groups[1].Value : regexLabelMatch.Groups[1].Value,
                    EntryType = isInstruction ? EntryTypes.Instruction : EntryTypes.Label,
                    Registers = registersList,
                    Arguments = argumentsList
                });
            }

            return entriesList;
        } 
    }
}
