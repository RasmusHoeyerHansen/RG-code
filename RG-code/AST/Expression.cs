using Antlr4.Runtime;

namespace RG_code.AST
{
    public abstract class Expression : Ast
    {
        public Type Type { get; set; } = 0;

        public Expression(IAst parent, IToken information) : base(parent, information)
        {
        }
        public Expression(IToken information) : base(information)
        {
        }
        

    }
}