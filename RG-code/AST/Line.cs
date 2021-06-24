using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Line : Statement, ILineVisitable<Ast>
    {
        public Line(Ast from, IEnumerable<Ast> toChain, IToken information) : base (information)
        {
            FromPoint = from;
            from.Parent = this;
            Children.Add(from);
            foreach (Point point in toChain)
            {
                point.Parent = this;
                Children.Add(point);
            }
        }

        public Ast FromPoint { get; set; }
        public IEnumerable<Ast> ToChain { get; set; }
        public Ast Accept(ILineVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }
        
        public override string ToString()
        {
            
            return "Line node " + base.ToString();
        }
    }
}