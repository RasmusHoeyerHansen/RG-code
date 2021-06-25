namespace RG_code.AST
{
    public interface IIdVisitor<out T>
    {
        public T Visit(NameReference node);
    }
}