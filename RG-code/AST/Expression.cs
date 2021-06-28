using Antlr4.Runtime;

namespace RG_code.AST
{
    public abstract class Expression : Ast
    {
   

        public Expression(IToken information) : base(information)
        {
        }
    }
}