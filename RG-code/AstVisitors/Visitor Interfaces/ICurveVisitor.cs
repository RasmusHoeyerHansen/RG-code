namespace RG_code.AST
{
    public interface ICurveVisitor<out T>
    {
        public T Visit(Curve node);
    }
}