using Antlr4.Runtime;

namespace RG_code.AST
{
    public class GreaterThan : InfixBool
    {
        public GreaterThan(Ast lhs, Ast rhs, IToken token ) : base(lhs, rhs, token)
        {
        }

        public override Ast Accept(IInfixBoolVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }
        
        public override string ToString()
        {
            
            return "Greater Than node " + base.ToString();
        }
    }
}