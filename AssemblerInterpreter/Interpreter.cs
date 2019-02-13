using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AssemblerInterpreter
{
    public sealed class Interpreter
    {
        private readonly ITextParser _textParser;
        private IEngine _engine;

        public Interpreter()
        {
            _textParser = new TextParser();
        }

        public void Interpret(string text)
        {
            var linesList = _textParser.Parse(text);
            var entriesList = TranslateToEntriesList(linesList);

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
            var regexLabel = new Regex(@"^([A-z]+:)$");
            var regexRegister = new Regex(@"r(\d*)");
            var regexNumber = new Regex(@"#(\d*)");

            foreach (var line in linesList)
            {
                var regexInstrMatch = regexInstruction.Match(line);
                var regexLabelMatch = regexLabel.Match(line);
                var regexRegMatch = regexRegister.Matches(line);
                var regexNumMatch = regexNumber.Matches(line);

                var isInstruction = regexInstrMatch.Success;
                var argumentsList = (from Match arg in regexNumMatch select arg.Groups[1].Value).ToList();
                var registersList = (from Match reg in regexRegMatch select reg.Groups[1].Value).ToList();

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
