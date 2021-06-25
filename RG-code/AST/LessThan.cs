using Antlr4.Runtime;

namespace RG_code.AST
{
    public class LessThan : InfixBool
    {
        public LessThan(Ast lhs, Ast rhs, IToken information) : base(lhs,rhs, information)
        {

        }

        public override Ast Accept(IInfixBoolVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }
        public override string ToString()
        {
            
            return "Less Than " + base.ToString();
        }
    }
}