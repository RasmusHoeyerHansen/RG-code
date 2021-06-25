namespace RG_code.AST
{
    public interface IPointVisitor<out T> : IMathVisitor<T>
    {
        public T Visit(Point node);
    }
}