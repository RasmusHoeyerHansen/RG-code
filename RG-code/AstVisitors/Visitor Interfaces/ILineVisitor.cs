namespace RG_code.AST
{
    public interface ILineVisitor<out T> : IPointVisitor<T> where T : Ast
    {
        public T Visit(Line node);
    }
}