namespace RG_code.AST
{
    public interface IIdVisitable<T> where T : Ast
    {
        public T Accept(IIdVisitor<T> visitor);
    }
}