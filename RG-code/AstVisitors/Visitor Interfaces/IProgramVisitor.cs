using RG_code.AST;

namespace RG_code
{
    public interface IProgramVisitor<out T>
    {
        public T Visit(Program node);
    }
}