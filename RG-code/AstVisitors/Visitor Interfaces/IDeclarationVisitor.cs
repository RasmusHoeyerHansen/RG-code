namespace RG_code.AST
{
    public interface IDeclarationVisitor<out T> : IAssignmentVisitor<T>, IIdVisitor<T>
    {
        public T Visit(Declaration node);

    }
}