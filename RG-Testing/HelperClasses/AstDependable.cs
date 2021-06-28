using System.Collections;
using System.Collections.Generic;
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
            return (T)builder.Visit(cstContext);
        }

        protected virtual Ast CreateAst<T, Context>(string codeExpression)
            where Context : ParserRuleContext
            where T : Ast
        {
            ParserRuleContext cstContext = CreateContext<Context>(codeExpression);
            AstBuilderVisitor<T> builder = new();
            return builder.Visit(cstContext);
        }
    }

    public class DeclarationDependable : AstDependable
    {
        protected Stack<Scope> Scopes;
        protected override T CreateAst<T, Context>(string filename, string dirName)
        {
            var node = base.CreateAst<T, Context>(filename, dirName);
            var dclChecker = new DeclarationChecker();
            dclChecker.Visit((dynamic)node);
            Scopes = dclChecker.ScopeStack;
            return node;
        }

        protected override T CreateAst<T, Context>(string codeExpression)
        {
            var node = base.CreateAst<T, Context>(codeExpression);
            var dclChecker = new DeclarationChecker();
            dclChecker.Visit((dynamic)node);
            Scopes = dclChecker.ScopeStack;
            return (T)node;
        }
    }
}