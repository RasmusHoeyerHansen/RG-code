using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RG_code.AST;
using RG_code.AstVisitors;

namespace RG_testing.HelperClasses
{
    public class ScopeDependable : AstDependable
    {
        protected DeclarationChecker DclDeclarationChecker { get; set; }

        public ScopeDependable()
        {
            DclDeclarationChecker = new DeclarationChecker();
        }
        protected Stack<Scope<string, Declaration>> Scopes;
        protected override T CreateAst<T, Context>(string filename, string dirName)
        {
            var node = base.CreateAst<T, Context>(filename, dirName);
            DclDeclarationChecker.Visit((dynamic)node);
            Scopes = DclDeclarationChecker.ScopeStack;
            return node;
        }

        protected override T CreateAst<T, Context>(string codeExpression)
        {
            var node = base.CreateAst<T, Context>(codeExpression);
            
            DclDeclarationChecker.Visit((dynamic)node);
            Scopes = DclDeclarationChecker.ScopeStack;
            return (T)node;
        }
    }
}