using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Minus : InfixMath
    {
        public Minus(Ast lhs, Ast rhs, IToken token) : base(lhs, rhs, token)
        {
        }
        

        public override string ToString()
        {
            return "Minus " + base.ToString();
        }
    }
}