namespace RG_code.AST
{
    public interface IMovementVisitor<out T> : ILineVisitor<T>, ICurveVisitor<T>
    {

    }
}