using RG_code.AstVisitors;

namespace RG_testing.HelperClasses
{
    public class TypeDependable : ScopeDependable
    {
        protected ExpressionUsageChecker TypeChecker { get; set; }

        public TypeDependable()
        {
            TypeChecker = new ExpressionUsageChecker(DclScopeBuilder.ScopeStack);
        }

        protected override T CreateAst<T, Context>(string filename, string dirName)
        {
            
            T ast = base.CreateAst<T, Context>(filename, dirName);
            return (T) TypeChecker.Visit((dynamic)ast);
        }

        protected override T CreateAst<T, Context>(string codeExpression)
        {
            T ast = base.CreateAst<T, Context>(codeExpression);
            TypeChecker.Visit((dynamic)ast);
            return ast;
        }
    }
}