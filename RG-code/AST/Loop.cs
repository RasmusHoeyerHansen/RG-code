using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Loop : Statement
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

        public Ast Condition { get;}
        public IEnumerable<Ast> Body { get; }

        public override string ToString()
        {
            return "Loop " + base.ToString();
        }
    }
}