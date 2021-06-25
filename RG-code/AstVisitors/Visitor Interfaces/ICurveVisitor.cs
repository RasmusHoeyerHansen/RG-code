namespace RG_code.AST
{
    public interface ICurveVisitor<out T> : IPointVisitor<T>
    {
        public T Visit(Curve node);
    }
}