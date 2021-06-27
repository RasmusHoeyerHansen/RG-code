using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Power : InfixMath
    {
        public Power(Ast expr, Ast exponent, IToken information) : base(expr, exponent, information)
        {
        }

        public override Ast Accept(IInfixMathVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }

        public override string ToString()
        {
            return "Power " + base.ToString();
        }
    }
}