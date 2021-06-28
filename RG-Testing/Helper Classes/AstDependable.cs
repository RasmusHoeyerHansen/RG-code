using System.Collections;
using Antlr4.Runtime;
using RG_code.AST;
using RG_code.AstVisitors;

namespace RG_testing.HelperClasses
{
    public class AstDependable : ContextDependable
    {
        protected virtual T CreateAst<T, Context>(string filename, string dirName)
            where Context : ParserRuleContext
            where T : Ast
        {
            ParserRuleContext cstContext = CreateContext<Context>(filename, dirName);
            AstBuilderVisitor<T> builder = new();
            return (T) builder.Visit(cstContext);
        }

        protected virtual T CreateAst<T, Context>(string codeExpression)
            where Context : ParserRuleContext
            where T : Ast
        {
            ParserRuleContext cstContext = CreateContext<Context>(codeExpression);
            AstBuilderVisitor<T> builder = new();
            return (T)builder.Visit(cstContext);
        }
    }
}