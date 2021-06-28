using Antlr4.Runtime;

namespace RG_code.AST
{
    public class GreaterThan : InfixBool
    {
        public GreaterThan(Ast lhs, Ast rhs, IToken token) : base(lhs, rhs, token)
        {
        }


        public override string ToString()
        {
            return "Greater Than " + base.ToString();
        }
    }
}