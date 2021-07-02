namespace RG_code.AST
{
    public interface ILineVisitor<out T> 
    {
        public T Visit(Line node);
    }
}