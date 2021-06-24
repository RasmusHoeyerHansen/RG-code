namespace RG_code.AST
{
    public interface ILoopVisitable<T> where T : Ast
    {
        IAst Accept(ILoopVisitor<T> visitor);
    }
}