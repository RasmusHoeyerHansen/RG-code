using Antlr4.Runtime;

namespace RG_code.AST
{
    public class LessThan : InfixBool
    {
        public LessThan(Ast lhs, Ast rhs, IToken information) : base(lhs, rhs, information)
        {
        }
        

        public override string ToString()
        {
            return "Less Than " + base.ToString();
        }
    }
}