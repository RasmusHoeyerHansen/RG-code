namespace RG_code.AST
{
    public interface IIfVisitor<out T > : IBoolVisitor<T> where T : Ast
    {
        public T Visit(If node);
        public T Visit(IfElse node);
    }
}