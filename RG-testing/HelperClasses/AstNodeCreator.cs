using Antlr4.Runtime;
using RG_code.AST;
using RG_code.AstVisitors;

namespace RG_testing.HelperClasses
{
    public class AstNodeCreator<T, Context> : ContextCreator
    {
        protected Ast CreateAst<T, Context>(string filename, string dirName)
            where Context : ParserRuleContext
            where T : Ast
        {
            ParserRuleContext cstContext = CreateContext<Context>(filename, dirName);
            AstBuilderVisitor<T> builder = new();
            return builder.Visit(cstContext);
        }

        protected Ast CreateAst<T, Context>(string codeExpression)
            where Context : ParserRuleContext
            where T : Ast
        {
            ParserRuleContext cstContext = CreateContext<Context>(codeExpression);
            AstBuilderVisitor<T> builder = new();
            return builder.Visit(cstContext);
        }
    }
}