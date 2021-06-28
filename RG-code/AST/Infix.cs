using Antlr4.Runtime;

namespace RG_code.AST
{
    public abstract class Infix : Expression
    {

        public Infix(IToken information) : base(information)
        {
        }
    }
}