namespace RG_code.AST
{
    public interface IIdVisitor<out T> where T : Ast
    {
        public T Visit(NameReference node);
    }
}