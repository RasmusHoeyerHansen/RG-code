namespace RG_code.AST
{
    public interface ILineVisitable<T> where T : Ast
    {
        public T Accept(ILineVisitor<T> visitor);
    }
}