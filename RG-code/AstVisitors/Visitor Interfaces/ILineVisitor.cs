namespace RG_code.AST
{
    public interface ILineVisitor<out T> : IPointVisitor<T>
    {
        public T Visit(Line node);
    }
}