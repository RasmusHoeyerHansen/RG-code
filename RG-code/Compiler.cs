using System;
using System.IO;
using Antlr4.Runtime;
using RG_code.AST;
using RG_code.AstVisitors;

namespace RG_code
{
    class Compiler
    {
        static void Main(string[] args)
        {
            string fileLoc = args.Length != 0 ? args[0] : $"../../../testFile.rg";
            string sourceFileText = File.ReadAllText(fileLoc);
            
            AntlrInputStream inputStream = new AntlrInputStream(new StringReader(sourceFileText));
            RGCodeLexer lexer = new RGCodeLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            RGCodeParser parser = new RGCodeParser(tokenStream);
            
            
            RGCodeParser.ProgramContext cst = parser.program();
            
            Program ast = (Program) new AstBuilderVisitor<Ast>().VisitProgram(cst);
            
            //PrettyPrinter printer = new PrettyPrinter();
            //ast.Accept(printer);

            DeclarationChecker checker = new DeclarationChecker();
            ast.Accept(checker);
            Console.WriteLine(checker.GetErrorText());

            ExpressionUsageChecker exprChecker = new ExpressionUsageChecker(checker.ScopeStack);
            ast.Accept(exprChecker);
            Console.WriteLine(exprChecker.GetErrorText());


        }
    }
}