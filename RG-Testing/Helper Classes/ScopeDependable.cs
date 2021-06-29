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
        protected Stack<Scope> Scopes;
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

    public class TypeDependable : ScopeDependable
    {
        private ExpressionUsageChecker TypeChecker { get; set; }

        public TypeDependable()
        {
            TypeChecker = new ExpressionUsageChecker(DclChecker.ScopeStack);
        }

        protected override T CreateAst<T, Context>(string filename, string dirName)
        {
            
            T ast = base.CreateAst<T, Context>(filename, dirName);
            return (T) TypeChecker.Visit((dynamic)ast);
        }

        protected override T CreateAst<T, Context>(string codeExpression)
        {
            T ast = base.CreateAst<T, Context>(codeExpression);
            return (T) TypeChecker.Visit((dynamic)ast);
        }
    }
}