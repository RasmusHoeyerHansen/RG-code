namespace RG_code.AST
{
    public interface IInfixBoolVisitable<T> where T : Ast
    {
        public T Accept(IInfixBoolVisitor<T> visitor);
    }
}