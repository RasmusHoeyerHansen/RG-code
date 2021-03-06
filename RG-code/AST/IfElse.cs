using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class IfElse : If
    {
        public IfElse(If ifStatement, IEnumerable<Ast> elseBody, IToken token)
            : base(ifStatement.Condition, ifStatement.Body, token)
        {
            ElseBody = elseBody;
            foreach (Ast ast in elseBody)
            {
                Children.Add(ast);
                ast.Parent = this;
            }
        }

        public IEnumerable<Ast> ElseBody { get; }

        public override string ToString()
        {
            return "If-else " + base.ToString();
        }
    }
}