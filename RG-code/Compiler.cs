using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using RG_code.AST;
using RG_code.AstVisitors;

namespace RG_code
{
    internal class Compiler
    {
        private static void Main(string[] args)
        {
            string fileLoc = args.Length != 0 ? args[0] : $"../../../testFile.rg";
            string sourceFileText = File.ReadAllText(fileLoc);

            AntlrInputStream inputStream = new(new StringReader(sourceFileText));
            RGCodeLexer lexer = new(inputStream);
            CommonTokenStream tokenStream = new(lexer);
            RGCodeParser parser = new(tokenStream);


            RGCodeParser.ProgramContext cst = parser.program();

            Program ast = (Program) new AstBuilderVisitor<Ast>().VisitProgram(cst);

            //PrettyPrinter printer = new PrettyPrinter();
            //ast.Accept(printer);

            DeclarationChecker checker = new();
            checker.Visit(ast);
            PrintErrors("Declaration errors: ", checker.Errors);


            ExpressionUsageChecker exprChecker = new(checker.ScopeStack);
            exprChecker.Visit(ast);
            PrintErrors("Expression errors: ", exprChecker.Errors);
        }

        private static void PrintErrors(IEnumerable<TypeError> errs)
        {
            foreach (TypeError err in errs) Console.WriteLine(err);

            Console.WriteLine("");
        }

        private static void PrintErrors(string errorType, IEnumerable<TypeError> errs)
        {
            Console.WriteLine(errorType);
            PrintErrors(errs);
        }
    }
}