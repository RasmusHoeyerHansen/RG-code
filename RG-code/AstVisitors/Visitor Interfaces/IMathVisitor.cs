namespace RG_code.AST
{
    public interface IMathVisitor<out T> : IInfixMathVisitor<T>
    {
        public T Visit(Number node);
    }
}