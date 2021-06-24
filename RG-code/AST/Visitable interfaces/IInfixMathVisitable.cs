namespace RG_code.AST
{
    public interface IInfixMathVisitable<T> where T : Ast
    {
        public T Accept(IInfixMathVisitor<T> visitor);
    }
}