namespace RG_code.AST
{
    public interface IDeclarationVisitor<out T> : IAssignmentVisitor<T>, IIdVisitor<T> where T : Ast
    {
        public T Visit(Declaration node);

    }
}