namespace RG_code.AST
{
    public interface ICurveVisitor<out T> : IPointVisitor<T>
        where T : Ast 
    {
        public T Visit(Curve node);
    }
}