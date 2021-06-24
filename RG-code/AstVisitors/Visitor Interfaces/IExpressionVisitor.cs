namespace RG_code.AST
{
    public interface IExpressionVisitor<out T> : IMathVisitor<T>, IBoolVisitor<T>, IPointVisitor<T> where T : Ast
    {
        public T Visit(Expression node);
    }
}