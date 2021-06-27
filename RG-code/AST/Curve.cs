using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Curve : Statement, ICurveVisitable<Ast>
    {
        public Curve(Ast fromPoint, IEnumerable<Ast> toChain, Ast angle, IToken information) : base(information)
        {
            FromPoint = fromPoint;
            ToChain = toChain;
            Angle = angle;
            Children.Add(fromPoint);
            Children.Add(angle);
            foreach (Ast point in toChain)
            {
                Children.Add(point);
                point.Parent = this;
            }
        }

        public Ast FromPoint { get; set; }
        public IEnumerable<Ast> ToChain { get; set; }
        public Ast Angle { get; set; }

        public Ast Accept(ICurveVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }

        public override string ToString()
        {
            return "Curve " + base.ToString();
        }
    }
}