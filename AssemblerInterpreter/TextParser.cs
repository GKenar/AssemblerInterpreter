using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AssemblerInterpreter
{
    public class TextParser : ITextParser
    {
        public List<string> Parse(string text)
        {
            if(text == null)
                throw new ArgumentNullException(nameof(text));

            var byteArray = Encoding.ASCII.GetBytes(text);
            using (var memoryStream = new MemoryStream(byteArray, false))
            {
                return Pars(memoryStream);
            }
        }

        public List<string> Parse(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            return Pars(stream);
        }

        public List<string> ParseFromFile(string path)
        {
            var linesList = new List<string>();

            using (var streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    linesList.Add(streamReader.ReadLine());
                }
            }
            return linesList;
        }

        private static List<string> Pars(Stream stream)
        {
            var streamReader = new StreamReader(stream);
            var linesList = new List<string>();

            while (!streamReader.EndOfStream)
            {
                linesList.Add(streamReader.ReadLine());
            }
            return linesList;
        } 
    }
}
