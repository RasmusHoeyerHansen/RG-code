using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Point : Expression
    {
        public Point(Ast xValue, Ast yValue, IToken information) : base(information)
        {
            XValue = xValue;
            YValue = yValue;
            Children.Add(XValue);
            Children.Add(YValue);

            foreach (IAst child in Children) child.Parent = this;
        }

        public Ast XValue { get; }

        public Ast YValue { get; }
        public override string ToString()
        {
            return "Point " + base.ToString();
        }
    }
}