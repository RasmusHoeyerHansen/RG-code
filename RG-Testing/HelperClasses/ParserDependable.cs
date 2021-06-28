using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;

namespace RG_testing.HelperClasses
{
    public class ParserDependable
    {
        protected RGCodeParser CreateParser(string fileName, string dirName)
        {
            Dictionary<string, string> symbolTable = new();

            string code = File.ReadAllText($"../../../Fixture programs/{dirName}/{fileName}");
            return CreateParser(code);
        }

        protected RGCodeParser CreateParser(string code)
        {
            AntlrInputStream inputStream = new(new StringReader(code));
            RGCodeLexer lexer = new(inputStream);
            CommonTokenStream tokenStream = new(lexer);
            return new RGCodeParser(tokenStream);
        }
    }
}