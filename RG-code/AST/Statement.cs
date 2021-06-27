using Antlr4.Runtime;

namespace RG_code.AST
{
    public abstract class Statement : Ast
    {
        public Statement(IAst parent, IToken token) : base(parent, token)
        {
        }

        public Statement(IToken token) : base(token)
        {
        }
    }
}