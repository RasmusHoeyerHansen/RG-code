using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RG_code.AST;
using RG_code.AstVisitors;

namespace RG_testing.HelperClasses
{
    public class ScopeDependable : AstDependable
    {
        protected ScopeBuilder DclScopeBuilder { get; set; }

        public ScopeDependable()
        {
            DclScopeBuilder = new ScopeBuilder();
        }
        protected Stack<Scope<string, Declaration>> Scopes;
        protected override T CreateAst<T, Context>(string filename, string dirName)
        {
            var node = base.CreateAst<T, Context>(filename, dirName);
            DclScopeBuilder.Visit((dynamic)node);
            Scopes = DclScopeBuilder.ScopeStack;
            return node;
        }

        protected override T CreateAst<T, Context>(string codeExpression)
        {
            var node = base.CreateAst<T, Context>(codeExpression);
            
            DclScopeBuilder.Visit((dynamic)node);
            Scopes = DclScopeBuilder.ScopeStack;
            return (T)node;
        }
    }
}