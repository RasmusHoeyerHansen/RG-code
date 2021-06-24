using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Equals : InfixBool
    {
        public Equals(Ast lhs, Ast rhs, IToken token) : base(lhs, rhs, token)
        {
        }

        public override Ast Accept(IInfixBoolVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }
        public override string ToString()
        {
            
            return "Equals node " + base.ToString();
        }
    }
}