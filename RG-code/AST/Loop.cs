using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Loop : Statement, ILoopVisitable<Ast>
    {
        public Loop(Ast condition, IEnumerable<Ast> body, IToken token) : base(token)
        {
            Condition = condition;
            IEnumerable<Ast> enumerable = body as Ast[] ?? body.ToArray();
            Body = enumerable;
            Children.Add(condition);
            condition.Parent = this;
            foreach (Ast ast in enumerable)
            {
                ast.Parent = this;
                Children.Add(ast);
            }
        }

        public Ast Condition { get; set; }
        public IEnumerable<Ast> Body { get; }

        public IAst Accept(ILoopVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }

        public override string ToString()
        {
            return "Loop " + base.ToString();
        }
    }
}