namespace RG_code.AST
{
    public interface ILoopVisitor<out T>
    {
        T Visit(Loop node);
    }
}