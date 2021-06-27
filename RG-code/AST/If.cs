using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class If : Ast, IIfVisitable<Ast>
    {
        public If(Ast condition, IEnumerable<Ast> body, IToken token) : base(token)
        {
            Condition = condition;
            Children.Add(condition);
            IEnumerable<Ast> enumerable = body as Ast[] ?? body.ToArray();
            Body = enumerable;
            foreach (Ast ast in enumerable)
            {
                Children.Add(ast);
                ast.Parent = this;
            }
        }

        public Ast Condition { get; }
        public IEnumerable<Ast> Body { get; }

        public IAst Accept(IIfVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }

        public override string ToString()
        {
            return "If " + base.ToString();
        }
    }
}