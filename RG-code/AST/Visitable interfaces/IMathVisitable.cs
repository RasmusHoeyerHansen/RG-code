namespace RG_code.AST
{
    public interface IMathVisitable<out T> where T : Ast
    {
        public T Accept(IMathVisitor<Ast> visitor);
    }
}