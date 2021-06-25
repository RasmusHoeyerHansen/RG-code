namespace RG_code.AST
{
    public interface ILoopVisitor<out T> : IBoolVisitor<T>
    {
        T Visit(Loop node);
    }
}