namespace RG_code.AST
{
    public interface IPointVisitor<out T> : IMathVisitor<T> where T : Ast
    {
        public T Visit(Point node);
    }
}