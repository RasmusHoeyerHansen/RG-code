namespace RG_code.AST
{
    public interface ILoopVisitor<out T> : IBoolVisitor<T>where T : Ast
    {
        T Visit(Loop node);
    }
}