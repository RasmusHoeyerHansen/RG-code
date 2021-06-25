using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Number : Expression, IMathVisitable<Ast>
    {
        public double Value { get; private set; }

        public Number(double value, IToken information) : base(information)
        {
            Value = value;
        }

        public Ast Accept(IMathVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }
        
        public override string ToString()
        {
            
            return "Number " + base.ToString();
        }
    }
}