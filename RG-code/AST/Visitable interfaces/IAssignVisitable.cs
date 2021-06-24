namespace RG_code.AST
{
    public interface IAssignVisitable<T> where T : Ast
    {
        public T Accept(IAssignmentVisitor<T> visitor);
    }
}