using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RG_code.AST;
using RG_code.AstVisitors;

namespace RG_testing.HelperClasses
{
    public class ScopeDependable : AstDependable
    {
        protected DeclarationChecker DclChecker { get; set; }

        public ScopeDependable()
        {
            DclChecker = new DeclarationChecker();
        }
        protected Stack<Scope<string, Declaration>> Scopes;
        protected override T CreateAst<T, Context>(string filename, string dirName)
        {
            var node = base.CreateAst<T, Context>(filename, dirName);
            DclChecker.Visit((dynamic)node);
            Scopes = DclChecker.ScopeStack;
            return node;
        }

        protected override T CreateAst<T, Context>(string codeExpression)
        {
            var node = base.CreateAst<T, Context>(codeExpression);
            
            DclChecker.Visit((dynamic)node);
            Scopes = DclChecker.ScopeStack;
            return (T)node;
        }
    }
}