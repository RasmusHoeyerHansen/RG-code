namespace RG_code.AST
{
    public interface IMathVisitor<out T> : IInfixMathVisitor<T> where  T : Ast
    {
        public T Visit(Number node);
    }
}