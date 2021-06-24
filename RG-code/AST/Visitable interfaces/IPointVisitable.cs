namespace RG_code.AST
{
    public interface IPointVisitable<T> where T : Ast
    {
        public T Accept(IPointVisitor<T> visitor);

    }
}