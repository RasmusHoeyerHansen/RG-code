using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Curve : Movement
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

        public Ast FromPoint { get;  }
        public IEnumerable<Ast> ToChain { get; }
        public Ast Angle { get; }


        public override string ToString()
        {
            return "Curve " + base.ToString();
        }
    }
}