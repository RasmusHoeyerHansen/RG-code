namespace RG_code.AST
{
    public interface IDeclarationVisitable<T> where T : Ast
    {
        public T Accept(IDeclarationVisitor<T> visitor);
    }
}