using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Plus : InfixMath
    {
        public Plus(Ast lhs, Ast rhs, IToken token) : base(lhs, rhs, token)
        {
        }

        public override string ToString()
        {
            return "Plus " + base.ToString();
        }
    }
}