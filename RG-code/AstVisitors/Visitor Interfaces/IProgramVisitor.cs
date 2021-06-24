using RG_code.AST;

namespace RG_code
{
    public interface IProgramVisitor<out T> where T : Ast
    {
        public T Visit(Program node);
    }
}