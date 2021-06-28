using System.Collections.Generic;
using RG_code.AstVisitors;

namespace RG_testing.HelperClasses
{
    public class ScopeDependable : AstDependable
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

    public class TypeDependable : ScopeDependable
    {
        protected override T CreateAst<T, Context>(string filename, string dirName)
        {
            
            return base.CreateAst<T, Context>(filename, dirName);
        }

        protected override T CreateAst<T, Context>(string codeExpression)
        {
            return base.CreateAst<T, Context>(codeExpression);
        }
    }
}