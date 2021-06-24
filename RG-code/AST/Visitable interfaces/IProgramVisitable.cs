namespace RG_code.AST
{
    public interface IProgramVisitable<T> where T : Ast
    {
        public T Accept(IProgramVisitor<T> visitor);
    }
}