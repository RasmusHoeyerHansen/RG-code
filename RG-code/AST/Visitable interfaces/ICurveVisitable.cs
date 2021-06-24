namespace RG_code.AST
{
    public interface ICurveVisitable<T> where T : Ast
    {
        public T Accept(ICurveVisitor<T> visitor);
    }
}