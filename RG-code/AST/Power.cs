using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Power : InfixMath
    {
        public Power(Ast expr, Ast exponent, IToken information) : base(expr, exponent, information)
        {
        }

        public override string ToString()
        {
            return "Power " + base.ToString();
        }
    }
}