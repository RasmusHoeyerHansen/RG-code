namespace RG_code.AST
{
    public interface IDeclarationVisitable<T>
    {
        public T Accept(IDeclarationVisitor<T> visitor);
    }
}