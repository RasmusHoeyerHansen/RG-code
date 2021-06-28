using System.Collections.Generic;
using System.ComponentModel;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Line : Statement
    {
        public Line(Ast from, IEnumerable<Ast> toChain, IToken information) : base(information)
        {
            FromPoint = from;
            from.Parent = this;
            Children.Add(from);
            ToChain = toChain;
            foreach (Point point in toChain)
            {
                point.Parent = this;
                Children.Add(point);
            }
        }

        public Ast FromPoint { get; }
        public IEnumerable<Ast> ToChain { get; }

        public override string ToString()
        {
            return "Line " + base.ToString();
        }
    }
}