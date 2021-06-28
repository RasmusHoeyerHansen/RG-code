using Antlr4.Runtime;

namespace RG_code.AST
{
    public abstract class Statement : Ast
    {

        public Statement(IToken token) : base(token)
        {
        }
    }
}