namespace RG_code.AST
{
    public interface IIfVisitor<out T > : IBoolVisitor<T>
    {
        public T Visit(If node);
        public T Visit(IfElse node);
    }
}