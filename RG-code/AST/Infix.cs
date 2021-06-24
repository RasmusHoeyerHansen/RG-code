using Antlr4.Runtime;

namespace RG_code.AST
{
    public abstract class Infix : Expression
    {
        public Infix(IAst parent, IToken information) : base(parent, information)
        {
        }
        public Infix(IToken information) : base(information)
        {
        }
    }
}