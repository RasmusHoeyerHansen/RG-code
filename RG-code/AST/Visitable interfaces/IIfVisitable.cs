namespace RG_code.AST
{
    public interface IIfVisitable<T> where T : Ast
    {
        public IAst Accept(IIfVisitor<T> visitor);
    }
}